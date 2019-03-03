namespace PovScene.SceneDescription
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Engine;
    using Items;
    using Items.ObjectModifiers;
    using Libraries;
    using Output;
    using Util;
    using Values;

    /// <summary>
    /// A Scene.
    /// </summary>
    public class Scene : SceneElement
    {
        public bool Animating => this.Animation != null;
        public Animation Animation { get; private set; }

        /// <summary>The output scene description file.</summary>
        public string OutputFile { get; internal set; }
        /// <summary>The output image to use when referring to a dependent scene.</summary>
        public string OutputImageFile { get; internal set; }
        /// <summary>Scenes whose output this scene depends on.</summary>
        public Collection<Scene> DependentScenes = new Collection<Scene>();
        
        /// <summary>Raised when the scene file has been generated.</summary>
        public event EventHandler<EventArgs> Generated;
        
        public PovRandom Random { get; } = new PovRandom();

        [Output(Order = int.MinValue, ContentEnd = ";")]
        public Directive VersionDirective => new Directive(Keyword.Version, new Float(this.PovVersion).ToString());

        [Ignore]
        public IncludeFiles Include { get; } = new IncludeFiles();
        
        [Output]
        protected DirectiveCollection IncludeDirectives { get; set; }

        [Output]
        protected Directive DefaultDirective => this.DefaultTexture == null ? null : Directive.Default(this.DefaultTexture);

        public Texture DefaultTexture { get; set; }

        [Output]
        [Init]
        public GlobalSettings GlobalSettings { get; set; }


        [Output]
        public Camera Camera { get; set; }

        [Output]
        public Collection<SceneItem> Items { get; } = new Collection<SceneItem>();

        public double PovVersion { get; set; }

        public PovrayOptions PovrayOptions { get; set; } = new PovrayOptions();

        protected readonly Vector X = Vector.X;
        protected readonly Vector Y = Vector.Y;
        protected readonly Vector Z = Vector.Z;

        public Scene()
        {
        }

        public void StartAnimation(Animation animation)
        {
            this.Animation = animation;
        }

        /// <summary>
        /// Generate the scene file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="outputImageFile"></param>
        public void WriteFile(string path, string outputImageFile)
        {
            this.OutputFile = path;
            this.OutputImageFile = outputImageFile;
            
            string output = this.Write();
            File.WriteAllText(path, output);

            this.Generated?.Invoke(this, new EventArgs());
        }

        public string Write()
        {
            this.IncludeDirectives = new DirectiveCollection();
            
            SceneWriter output = new SceneWriter();
            ElementContext sceneContext = new ElementContext(null, this);            
            sceneContext.LoadChildren(true);
            
            ElementContext context = sceneContext.Children.FirstOrDefault(c => c.Element == this.IncludeDirectives);
            foreach (string includeFile in this.Include.Files)
            {
                this.IncludeDirectives.Directives.Add(Directive.Include(includeFile));
            }
            context?.LoadChildren();

            this.GenerateDependentScenes();

            sceneContext.Write(output);
            return output.ToString();
        }

        private static int dependencyDepth = 0;
        
        /// <summary>
        /// Generate the scenes that this scene depends on.
        /// </summary>
        protected void GenerateDependentScenes()
        {
            try
            {
                dependencyDepth++;
                Scene blank = null;
                if (dependencyDepth > 4)
                {
                    blank = new Scene
                    {
                        Camera = new Camera(1, 0)
                    };
                }
                
                foreach (Scene scene in this.DependentScenes)
                {
                    (blank ?? scene).WriteFile(scene.OutputFile, scene.OutputImageFile);
                }
            }
            finally
            {
                dependencyDepth--;
            }

        }

        /// <summary>
        /// Add another scene as a dependency of this one.
        /// </summary>
        /// <param name="scene"></param>
        public void AddDependentScene(Scene scene)
        {
            string imageExt = Path.GetExtension(this.OutputImageFile);
            if (string.IsNullOrEmpty(imageExt))
            {
                imageExt = ".png";
            }

            //if (scene.OutputFile == null)
            {
                scene.OutputFile = string.Format("{0}-{1}.pov", this.OutputFile, scene.Id);
            }

            //if (scene.OutputImageFile == null)
            {
                scene.OutputImageFile = string.Format("{0}{1}", scene.OutputFile, imageExt);
            }

            this.DependentScenes.Add(scene);
        }

        public TSceneItem Add<TSceneItem>(TSceneItem item)
            where TSceneItem : SceneItem
        {
            this.Items.Add(item);
            return item;
        }
    }

    public class IncludeFiles
    {
        internal HashSet<string> Files { get; } = new HashSet<string>();

        private bool Inc(string incFile, bool? add = null)
        {
            switch (add)
            {
                case null:
                    return this.Files.Contains(incFile);
                case true:
                    return this.Files.Add(incFile);
                default:
                    return this.Files.Remove(incFile);
            }
        }

        /// <summary>Include colors.inc</summary>
        public bool Colors
        {
            get => this.Inc(Library.ColorsInc.Filename);
            set => this.Inc(Library.ColorsInc.Filename, value);
        }
        
        /// <summary>Include textures.inc</summary>
        public bool Textures
        {
            get => this.Inc(Library.TexturesInc.Filename);
            set => this.Inc(Library.TexturesInc.Filename, value);
        }
        
        /// <summary>Include glass.inc</summary>
        public bool Glass
        {
            get => this.Inc("glass.inc");
            set => this.Inc("glass.inc", value);
        }
        
        /// <summary>Include rad_def.inc</summary>
        public bool RadDef
        {
            get => this.Inc("rad_def.inc");
            set => this.Inc("rad_def.inc", value);
        }
        
        public void Add(string incfile)
        {
            this.Files.Add(incfile);
        }
    }
}