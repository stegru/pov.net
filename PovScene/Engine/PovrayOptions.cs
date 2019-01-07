namespace PovScene.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using Platform;
    using SceneDescription.Values;
    using Util;

    /// <summary>
    /// Options for povray.
    /// </summary>
    public class PovrayOptions
    {
        private readonly Dictionary<string, object> storage = new Dictionary<string, object>();

        /// <summary>Animation related options.</summary>
        public AnimationOptions Animation { get; }
        /// <summary>Display related options.</summary>
        public DisplayOutputOptions DisplayOutput { get; }
        /// <summary>File output related options.</summary>
        public FileOutputOptions FileOutput { get; }
        /// <summary>Output related options.</summary>
        public GeneralOutputOptions GeneralOutput { get; }
        /// <summary>Scene parsing related options.</summary>
        public SceneParsingOptions SceneParsing { get; }
        /// <summary>Shell command related options.</summary>
        public ShellCommandOptions ShellCommand { get; }
        /// <summary>Text output related options.</summary>
        public TextOutputOptions TextOutput { get; }
        /// <summary>Tracing related options.</summary>
        public TracingOptions Tracing { get; }

        public PovrayOptions()
        {
            this.Animation = new AnimationOptions(this.storage);
            this.DisplayOutput = new DisplayOutputOptions(this.storage);
            this.FileOutput = new FileOutputOptions(this.storage);
            this.GeneralOutput = new GeneralOutputOptions(this.storage);
            this.SceneParsing = new SceneParsingOptions(this.storage);
            this.ShellCommand = new ShellCommandOptions(this.storage);
            this.TextOutput = new TextOutputOptions(this.storage);
            this.Tracing = new TracingOptions(this.storage);
        }

        /// <summary>
        /// Creates an instance, using the values of another instance.
        /// </summary>
        /// <param name="original">The instance to copy values from.</param>
        public PovrayOptions(PovrayOptions original)
            : this()
        {
            this.SetOptions(original);
        }

        /// <summary>
        /// Copy the options from another instance onto this.
        /// </summary>
        /// <param name="otherOptions"></param>
        public void SetOptions(PovrayOptions otherOptions)
        {
            if (otherOptions != null)
            {
                foreach (KeyValuePair<string, object> item in otherOptions.storage)
                {
                    this.storage[item.Key] = item.Value;
                }
            }
        }

        /// <summary>
        /// Generates the ini file text for this object.
        /// </summary>
        /// <returns>The values of the settings, in ini file format.</returns>
        public override string ToString()
        {
            Regex re = new Regex(@"([a-z])([A-Z])", RegexOptions.Compiled);

            StringBuilder output = new StringBuilder();
            foreach (KeyValuePair<string,object> option in this.storage)
            {
                string key = re.Replace(option.Key, "$1_$2");
                output.AppendLine(key + "=" + option.Value);
            }

            return output.ToString();
        }

        public string WriteFile()
        {
            string file = string.Format("pov-{0:X}.ini", new Random().Next());
            string path = Path.Combine(OS.Current.TempDir, file);
            File.WriteAllText(path, this.ToString());
            return path;
        }

        public abstract class OptionsBase
        {
            private readonly Dictionary<string, object> storage;

            protected OptionsBase(Dictionary<string, object> storage)
            {
                this.storage = storage;
            }

            protected object GetValue([CallerMemberName] string valueName = "")
            {
                return this.storage.TryGetValue(valueName, out object value) ? value : null;
            }

            protected object SetValue(object value, [CallerMemberName] string valueName = "")
            {
                return this.storage[valueName] = value;
            }
        }

        // @formatter:off
        public class AnimationOptions : OptionsBase {
            internal AnimationOptions(Dictionary<string, object> storage) : base(storage) { }
            public Float Clock { get => (Float) this.GetValue(); set => this.SetValue(value); }                          
            public bool CyclicAnimation { get => (bool) this.GetValue(); set => this.SetValue(value); }               
            public bool FieldRender { get => (bool) this.GetValue(); set => this.SetValue(value); }                   
            public Float FinalClock { get => (Float) this.GetValue(); set => this.SetValue(value); }                    
            public int FinalFrame { get => (int) this.GetValue(); set => this.SetValue(value); }                    
            public int FrameStep { get => (int) this.GetValue(); set => this.SetValue(value); }                     
            public Float InitialClock { get => (Float) this.GetValue(); set => this.SetValue(value); }                  
            public int InitialFrame { get => (int) this.GetValue(); set => this.SetValue(value); }                  
            public bool OddField { get => (bool) this.GetValue(); set => this.SetValue(value); }                      
            public Float SubsetEndFrame { get => (Float) this.GetValue(); set => this.SetValue(value); }               
            public Float SubsetStartFrame { get => (Float) this.GetValue(); set => this.SetValue(value); }             
        }
        public class DisplayOutputOptions : OptionsBase {
            internal DisplayOutputOptions(Dictionary<string, object> storage) : base(storage) { }
            public bool Display { get => (bool) this.GetValue(); set => this.SetValue(value); }                        
            public string DisplayGamma { get => (string) this.GetValue(); set => this.SetValue(value); }                  
            public bool DrawVistas { get => (bool) this.GetValue(); set => this.SetValue(value); }                    
            public bool PauseWhenDone { get => (bool) this.GetValue(); set => this.SetValue(value); }                
            public int PreviewEndSize { get => (int) this.GetValue(); set => this.SetValue(value); }               
            public int PreviewStartSize { get => (int) this.GetValue(); set => this.SetValue(value); }             
            public bool Verbose { get => (bool) this.GetValue(); set => this.SetValue(value); }                        
        }
        public class FileOutputOptions : OptionsBase {
            internal FileOutputOptions(Dictionary<string, object> storage) : base(storage) { }
            public int BitsPerColor { get => (int) this.GetValue(); set => this.SetValue(value); }                 
            public int Compression { get => (int) this.GetValue(); set => this.SetValue(value); }                    
            public bool Dither { get => (bool) this.GetValue(); set => this.SetValue(value); }                         
            public Enum DitherMethod { get => (Enum) this.GetValue(); set => this.SetValue(value); }                  
            public Enum FileGamma { get => (Enum) this.GetValue(); set => this.SetValue(value); }                     
            public bool GrayscaleOutput { get => (bool) this.GetValue(); set => this.SetValue(value); }               
            public bool OutputAlpha { get => (bool) this.GetValue(); set => this.SetValue(value); }                   
            public string OutputFileName { get => (string) this.GetValue(); set => this.SetValue(value); }               
            public Enum OutputFileType { get => (Enum) this.GetValue(); set => this.SetValue(value); }               
            public bool OutputToFile { get => (bool) this.GetValue(); set => this.SetValue(value); }                 
        }
        public class GeneralOutputOptions : OptionsBase {
            internal GeneralOutputOptions(Dictionary<string, object> storage) : base(storage) { }
            public bool ContinueTrace { get => (bool) this.GetValue(); set => this.SetValue(value); }                 
            public bool CreateContinueTraceLog { get => (bool) this.GetValue(); set => this.SetValue(value); }      
            public string CreateIni { get => (string) this.GetValue(); set => this.SetValue(value); }                     
            public Float EndColumn { get => (Float) this.GetValue(); set => this.SetValue(value); }                     
            public Float EndRow { get => (Float) this.GetValue(); set => this.SetValue(value); }                        
            public int Height { get => (int) this.GetValue(); set => this.SetValue(value); }                         
            public int MaxImageBufferMemory { get => (int) this.GetValue(); set => this.SetValue(value); }        
            public Float StartColumn { get => (Float) this.GetValue(); set => this.SetValue(value); }                   
            public Float StartRow { get => (Float) this.GetValue(); set => this.SetValue(value); }                      
            public int Width { get => (int) this.GetValue(); set => this.SetValue(value); }                          
        }
        public class SceneParsingOptions : OptionsBase {
            internal SceneParsingOptions(Dictionary<string, object> storage) : base(storage) { }
            public string Declare { get => (string) this.GetValue(); set => this.SetValue(value); }                        
            public string IncludeHeader { get => (string) this.GetValue(); set => this.SetValue(value); }                 
            public string IncludeIni { get => (string) this.GetValue(); set => this.SetValue(value); }                    
            public string InputFileName { get => (string) this.GetValue(); set => this.SetValue(value); }                
            public string LibraryPath { get => (string) this.GetValue(); set => this.SetValue(value); }                   
            public Float Version { get => (Float) this.GetValue(); set => this.SetValue(value); }                        
        }
        public class ShellCommandOptions : OptionsBase {
            internal ShellCommandOptions(Dictionary<string, object> storage) : base(storage) { }
            public string FatalErrorCommand { get => (string) this.GetValue(); set => this.SetValue(value); }            
            public string FatalErrorReturn { get => (string) this.GetValue(); set => this.SetValue(value); }             
            public string PostFrameCommand { get => (string) this.GetValue(); set => this.SetValue(value); }             
            public string PostFrameReturn { get => (string) this.GetValue(); set => this.SetValue(value); }              
            public string PostSceneCommand { get => (string) this.GetValue(); set => this.SetValue(value); }             
            public string PostSceneReturn { get => (string) this.GetValue(); set => this.SetValue(value); }              
            public string PreFrameCommand { get => (string) this.GetValue(); set => this.SetValue(value); }              
            public string PreFrameReturn { get => (string) this.GetValue(); set => this.SetValue(value); }               
            public string PreSceneCommand { get => (string) this.GetValue(); set => this.SetValue(value); }              
            public string PreSceneReturn { get => (string) this.GetValue(); set => this.SetValue(value); }               
        }
        public class TextOutputOptions : OptionsBase {
            internal TextOutputOptions(Dictionary<string, object> storage) : base(storage) { }
            public bool AllConsole { get => (bool) this.GetValue(); set => this.SetValue(value); }                    
            public string AllFile { get => (string) this.GetValue(); set => this.SetValue(value); }                       
            public bool AppendFile { get => (bool) this.GetValue(); set => this.SetValue(value); }                    
            public bool DebugConsole { get => (bool) this.GetValue(); set => this.SetValue(value); }                  
            public string DebugFile { get => (string) this.GetValue(); set => this.SetValue(value); }                     
            public bool FatalConsole { get => (bool) this.GetValue(); set => this.SetValue(value); }                  
            public string FatalFile { get => (string) this.GetValue(); set => this.SetValue(value); }                     
            public bool RenderConsole { get => (bool) this.GetValue(); set => this.SetValue(value); }                 
            public string RenderFile { get => (string) this.GetValue(); set => this.SetValue(value); }                    
            public bool StatisticConsole { get => (bool) this.GetValue(); set => this.SetValue(value); }              
            public string StatisticFile { get => (string) this.GetValue(); set => this.SetValue(value); }                 
            public bool WarningConsole { get => (bool) this.GetValue(); set => this.SetValue(value); }                
            public string WarningFile { get => (string) this.GetValue(); set => this.SetValue(value); }                   
            public int WarningLevel { get => (int) this.GetValue(); set => this.SetValue(value); }                  
        }
        public class TracingOptions : OptionsBase {
            internal TracingOptions(Dictionary<string, object> storage) : base(storage) { }
            public bool Antialias { get => (bool) this.GetValue(); set => this.SetValue(value); }                      
            public int AntialiasDepth { get => (int) this.GetValue(); set => this.SetValue(value); }                
            public Float AntialiasGamma { get => (Float) this.GetValue(); set => this.SetValue(value); }                
            public Float AntialiasThreshold { get => (Float) this.GetValue(); set => this.SetValue(value); }            
            public Float BspBaseAccessCost { get => (Float) this.GetValue(); set => this.SetValue(value); }             
            public Float BspChildAccessCost { get => (Float) this.GetValue(); set => this.SetValue(value); }            
            public Float BspISectCost { get => (Float) this.GetValue(); set => this.SetValue(value); }                  
            public int BspMaxDepth { get => (int) this.GetValue(); set => this.SetValue(value); }                   
            public Float BspMissChance { get => (Float) this.GetValue(); set => this.SetValue(value); }                 
            public bool Bounding { get => (bool) this.GetValue(); set => this.SetValue(value); }                       
            public int BoundingMethod { get => (int) this.GetValue(); set => this.SetValue(value); }                
            public int BoundingThreshold { get => (int) this.GetValue(); set => this.SetValue(value); }             
            public bool HighReproducibility { get => (bool) this.GetValue(); set => this.SetValue(value); }           
            public bool Jitter { get => (bool) this.GetValue(); set => this.SetValue(value); }                         
            public Float JitterAmount { get => (Float) this.GetValue(); set => this.SetValue(value); }                  
            public bool LightBuffer { get => (bool) this.GetValue(); set => this.SetValue(value); }                   
            public int Quality { get => (int) this.GetValue(); set => this.SetValue(value); }                        
            public string RadiosityFileName { get => (string) this.GetValue(); set => this.SetValue(value); }            
            public bool RadiosityFromFile { get => (bool) this.GetValue(); set => this.SetValue(value); }            
            public bool RadiosityToFile { get => (bool) this.GetValue(); set => this.SetValue(value); }              
            public bool RadiosityVainPretrace { get => (bool) this.GetValue(); set => this.SetValue(value); }        
            public bool RemoveBounds { get => (bool) this.GetValue(); set => this.SetValue(value); }                  
            public int RenderBlockSize { get => (int) this.GetValue(); set => this.SetValue(value); }              
            public int RenderBlockStep { get => (int) this.GetValue(); set => this.SetValue(value); }              
            public int RenderPattern { get => (int) this.GetValue(); set => this.SetValue(value); }                 
            public int SamplingMethod { get => (int) this.GetValue(); set => this.SetValue(value); }                
            public bool SplitUnions { get => (bool) this.GetValue(); set => this.SetValue(value); }                   
            public bool VistaBuffer { get => (bool) this.GetValue(); set => this.SetValue(value); }                   
            public int WorkThreads { get => (int) this.GetValue(); set => this.SetValue(value); }                   
        }        
        // @formatter:on
    }
}