namespace PovScene.SceneDescription
{
    using System.IO;
    using Output;
    using Util;
    using Values;

    /// <summary>
    /// A reference to an image file.
    /// </summary>
    public class PovImage : SceneElement
    {
        [ValueElement(GroupNext = true)]
        public Keyword BitmapType { get; set; } = Keyword.Undefined;

        [StringElement]
        public string ImagePath { get; set; }
 
        [ValueElement(Keyword.Gamma)]
        public Float Gamma { get; set; }
        
        [ValueElement(Keyword.Premultiplied)]
        public bool? Premultiplied { get; set; }
        
        public static implicit operator PovImage(string path)
        {
            return new FileImage(path);
        }
    }

    /// <summary>
    /// An image file.
    /// </summary>
    public class FileImage : PovImage
    {
        public FileImage()
        {
        }

        public FileImage(string path)
        {
            this.ImagePath = path;
        }
    }

    /// <summary>
    /// An image that is created from a scene.
    /// </summary>
    public class SceneImage : FileImage, IRenderNotify
    {
        private Scene scene;

        public SceneImage(Scene scene)
        {
            this.scene = scene;
        }

        public void RenderNotify(ElementContext context)
        {
            if (this.scene == context.Scene)
            {
                this.scene = this.scene.Copy();
            }
            context.Scene.AddDependentScene(this.scene);
            this.ImagePath = this.scene.OutputImageFile;
        }
    }
}