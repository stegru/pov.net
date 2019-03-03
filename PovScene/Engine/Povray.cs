namespace PovScene.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Platform;
    using SceneDescription;

    /// <summary>
    /// Controls the povray renderer.
    /// </summary>
    public class Povray
    {
        /// <summary>The executable path.</summary>
        public string Executable { get; set; } = OS.Current.PovrayBinary;

        /// <summary>Povray version to target.</summary>
        public double Version { get; } = 3.7;

        /// <summary>Renders a scene file.</summary>
        /// <param name="options">Povray options.</param>
        /// <param name="povFile">Povray scene file.</param>
        /// <param name="output">Output filename</param>
        public bool Render(PovrayOptions options, string povFile, string output = null)
        {
            options.FileOutput.OutputFileName = output;
            options.SceneParsing.InputFileName = povFile;
            
            return this.Render(options);
        }

        /// <summary>Starts povray using the given options.</summary>
        /// <param name="options">Povray options.</param>
        public bool Render(PovrayOptions options)
        {
            if (options.SceneParsing.InputFileName == null)
            {
                throw new ArgumentException("No input file", nameof(options.SceneParsing.InputFileName));
            }
            
            if (options.FileOutput.OutputFileName == null)
            {
                options.FileOutput.OutputFileName = Path.ChangeExtension(options.SceneParsing.InputFileName, "png");
            }

            string iniFile = options.WriteFile();
            
            List<string> args = new List<string>
            {
                iniFile
            };

            if (OS.IsWindows)
            {
                args.Add("/NORESTORE");
                if (!options.DisplayOutput.PauseWhenDone)
                {
                    args.Add("/EXIT");
                }
            }


            bool result = this.Render(args.ToArray());
            File.Delete(iniFile);
            return result;
        }

        /// <summary>Start povray using the given ini file.</summary>
        /// <returns></returns>
        private bool Render(params string[] args)
        {
            Task<int> task = OS.Current.Run(this.Executable, args);
            task.Wait();
            return task.Result == 0;

        }
        
        /// <summary>Renders a scene.</summary>
        /// <param name="options">Povray options, overriding the values that are set in the scene (if any).</param>
        /// <param name="scene">The scene to render.</param>
        /// <returns></returns>
        public bool Render(Scene scene, PovrayOptions options = null)
        {
            // Duplicate the scene's options, and copy the provided values.
            PovrayOptions mergedOptions = new PovrayOptions(scene.PovrayOptions);
            mergedOptions.SetOptions(options);
            
            // Write the scene file.
            if (string.IsNullOrEmpty(mergedOptions.SceneParsing.InputFileName))
            {
                mergedOptions.SceneParsing.InputFileName = "pov.pov";
            }

            scene.PovVersion = this.Version;            
        
            scene.WriteFile(mergedOptions.SceneParsing.InputFileName, mergedOptions.FileOutput.OutputFileName);

            if (scene.DependentScenes.Count > 0)
            {
                foreach (PovrayOptions dependent in this.GetDependentScenes(scene, options))
                {
                    dependent.DisplayOutput.PauseWhenDone = false;
                    this.Render(dependent);
                }
            }

            bool result = this.Render(mergedOptions);
            
            if (options != null)
            {
                // Copy the output file onto the provided options.
                options.FileOutput.OutputFileName = mergedOptions.FileOutput.OutputFileName;
            }

            return result;
        }

        /// <summary>
        /// Get the rendering options for the scenes that a scene depends upon.
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        internal IEnumerable<PovrayOptions> GetDependentScenes(Scene scene, PovrayOptions options)
        {
            foreach (Scene dependentScene in scene.DependentScenes)
            {
                PovrayOptions opt = new PovrayOptions(scene.PovrayOptions);
                opt.SetOptions(options);
                opt.SetOptions(dependentScene.PovrayOptions);
                opt.SceneParsing.InputFileName = dependentScene.OutputFile;
                opt.FileOutput.OutputFileName = dependentScene.OutputImageFile;

                foreach (PovrayOptions child in this.GetDependentScenes(dependentScene, opt))
                {
                    yield return child;
                }
                
                yield return opt;
            }            
        }


        /// <summary>Renders a scene.</summary>
        /// <param name="scene">The scene to render.</param>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height. 0 to use the width at a ratio of 4:3</param>
        /// <param name="options">Povray options, overriding the values that are set in the scene (if any).</param>
        /// <returns></returns>
        public bool Render(Scene scene, int width, int height = 0, PovrayOptions options = null)
        {
            PovrayOptions modifiedOptions = new PovrayOptions(options);
            modifiedOptions.GeneralOutput.Width = width;
            modifiedOptions.GeneralOutput.Height = height == 0 ? (int)(width * 0.75) : height;
            return this.Render(scene, modifiedOptions);
        }

    }
}