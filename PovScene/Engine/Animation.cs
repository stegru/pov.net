﻿namespace PovScene.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using SceneDescription;
    using SceneDescription.Values;
    using Util;

    /// <summary>Create animated scenes.</summary>
    /// <remarks>
    /// This renders a scene once per frame, changing the <see cref="Clock"/> and <see cref="CurrentFrame"/> for each
    /// frame. When each frame is being generated, the <see cref="SceneElement.Animate"/> event is fired for every scene
    /// item.
    /// </remarks>
    public class Animation
    {
        private readonly Povray povray;
        
        public Scene Scene { get; }
        /// <summary>Number of frames.</summary>
        public int Length { get; }
        
        /// <summary>Currently rendered frame.</summary>
        public int CurrentFrame { get; private set; }
        
        /// <summary>The clock identifier.</summary>
        /// <remarks>
        /// This increments on each frame, starting at <see cref="InitialClock"/> for the first frame,
        /// and <see cref="FinalClock"/> for the last frame.
        /// </remarks>
        public Float Clock { get; private set; }
        /// <summary>The clock start value (at frame 0).</summary>
        public Float InitialClock { get; set; } = 0;
        /// <summary>The clock value at the last frame.</summary>
        public Float FinalClock { get; set; } = 1;

        /// <summary>First frame to render.</summary>
        public int StartFrame { get; set; } = 0;
        /// <summary>Last frame to render.</summary>
        public int EndFrame { get; set; } = -1;
        /// <summary>Frame number increment.</summary>
        public int FrameIncrement { get; set; } = 1;
        
        /// <summary>Set to true to include existing frames that where not rendered in the current run.</summary>
        public bool IncludeExisting { get; set; }

        /// <summary>Adjust the clock so it's one less increment (as per povray's Cyclic_Animation).</summary>
        public bool Cyclic { get; set; }
        
        /// <summary>Reverse the movie at the end.</summary>
        public bool DoubleBack { get; set; }
        /// <summary>With DoubleBack, don't add the start and end frame twice.</summary>
        public bool DoubleBackRemoveEnds { get; set; }
        
        public PovrayOptions Options;

        /// <summary>
        /// Creates an instance.
        /// </summary>
        /// <param name="scene">The scene to render.</param>
        /// <param name="length">The number of frames.</param>
        /// <param name="povray">The renderer.</param>
        /// <param name="options">Povray options.</param>
        public Animation(Scene scene, int length, Povray povray = null, PovrayOptions options = null)
        {
            this.Length = length;
            this.Scene = scene;
            this.povray = povray ?? new Povray();
            this.Options = new PovrayOptions(scene.PovrayOptions).Copy();
            this.Options.SetOptions(options);
        }

        /// <summary>
        /// Gets the format of the frame file.
        /// The format will look something like "baseFilename-frame%04d.ext"
        /// </summary>
        /// <param name="baseFilename">Start of the filename.</param>
        /// <param name="extension">The file extension.</param>
        /// <param name="ffmpeg">True to format for ffpmeg, otherwise for string.Format.</param>
        /// <param name="wildcard">Use a '*' instead of a numeric placeholder.</param>
        /// <returns></returns>
        private string GetFrameFormat(string baseFilename, string extension, bool ffmpeg = false, bool wildcard = false)
        {
            int digits = Math.Max(this.Length.ToString().Length, 4);
            string placeholder;

            if (wildcard)
            {
                placeholder = "*";
            }
            else
            {
                placeholder = ffmpeg
                    ? "%0" + digits + "d"
                    : "{0:D" + digits + "}";
            }

            return string.Format("{0}-frame{1}.{2}", baseFilename, placeholder, extension);
        }

        /// <summary>
        /// Generate the scene files for each frame.
        /// </summary>
        /// <param name="baseFilename">Path of the generated scene files, without the .pov extension.</param>
        /// <param name="options">Base options to use.</param>
        /// <returns>Frame-specific options for each frame.</returns>
        public PovrayOptions[] GenerateSceneFiles(string baseFilename, PovrayOptions options)
        {
            string filenameFormat = this.GetFrameFormat(baseFilename, "pov");
            this.CurrentFrame = -1;
            
            if (this.StartFrame < 0)
            {
                this.StartFrame = 0;
            }

            if (this.StartFrame >= this.Length)
            {
                this.StartFrame = this.Length - 1;
            }

            if (this.EndFrame < 0 || this.EndFrame >= this.Length)
            {
                this.EndFrame = this.Length - 1;
            }
            
            this.Clock = this.InitialClock;
            
            this.Scene.StartAnimation(this);
        
            List<PovrayOptions> frames = new List<PovrayOptions>(this.Length);
            while (this.NextFrame())
            {
                string povFile = string.Format(filenameFormat, this.CurrentFrame);
                
                PovrayOptions frameOptions = new PovrayOptions(options);
                frameOptions.Animation.Clock = this.Clock;
                frameOptions.FileOutput.OutputFileName = Path.ChangeExtension(povFile, "png");
                frameOptions.SceneParsing.InputFileName = povFile;
                frames.Add(frameOptions);
                
                this.Scene.PovVersion = this.povray.Version;
                this.Scene.WriteFile(frameOptions.SceneParsing.InputFileName, frameOptions.FileOutput.OutputFileName);
            }

            this.CurrentFrame = -1;
            return frames.ToArray();
        }

        /// <summary>
        /// Move to the next frame
        /// </summary>
        /// <returns>true if the frame is within the animation length.</returns>
        private bool NextFrame()
        {
            if (this.CurrentFrame > this.EndFrame)
            {
                return false;
            }
            
            if (this.CurrentFrame == -1)
            {
                this.CurrentFrame = this.StartFrame;
            }
            else
            {
                this.CurrentFrame += this.FrameIncrement;
            }

            double length = this.Length - (this.Cyclic ? 0 : 1);
            this.Clock = this.CurrentFrame / length *
                         (this.FinalClock - this.InitialClock) + this.InitialClock;

            return this.CurrentFrame <= this.EndFrame;
        }

        /// <summary>
        /// Renders scene files.
        /// </summary>
        /// <returns>The frame image files.</returns>
        public string[] RenderFramesAsync(string baseFilename, IEnumerable<PovrayOptions> frameOptions)
        {
            List<string> frameImages = new List<string>();
            List<Action> tasks = new List<Action>();
            
            foreach (PovrayOptions frame in frameOptions)
            {
                tasks.Add(() => this.povray.Render(frame));
                frameImages.Add(frame.FileOutput.OutputFileName);
            }
            
            Parallel.Invoke(new ParallelOptions {MaxDegreeOfParallelism = 1}, tasks.ToArray());
            
            if (this.DoubleBack)
            {
                string imageExtension = Path.GetExtension(frameImages[0])?.Substring(1);
                string filenameFormat = this.GetFrameFormat(baseFilename, imageExtension);
                
                // Repeat the frames, in reverse order.
                int frame = this.Length;

                IEnumerable<string> repeatFrames = frameImages.ToList();
                
                if (this.DoubleBackRemoveEnds)
                {
                    repeatFrames = repeatFrames.Skip(1).SkipLast(1);
                }

                foreach (string frameImage in repeatFrames.Reverse())
                {
                    string newFile = string.Format(filenameFormat, frame);

                    string args = $"-s -f {frameImage} {newFile}";
                    Process.Start("ln", args)?.WaitForExit();

                    frameImages.Add(newFile);
                    frame++;
                }
            }

            return frameImages.ToArray();
        }

        
        public string[] RenderFrames(string baseFilename, IEnumerable<PovrayOptions> frameOptions)
        {
            return this.RenderFramesAsync(baseFilename, frameOptions).ToArray();
        }

        /// <summary>
        /// Renders the animated scene to a movie.
        /// </summary>
        /// <param name="outputFile">The movie file</param>
        /// <param name="ffmpegGlobalOptions">Global options for ffmpeg.</param>
        /// <param name="ffmpegInfileOptions">"infile" options for ffmpeg.</param>
        /// <param name="ffmpegOutfileOptions">"outfile" options for ffmpeg.</param>
        /// <returns>The movie file</returns>
        public string RenderMovie(string outputFile, string ffmpegGlobalOptions = null,
            string ffmpegInfileOptions = null, string ffmpegOutfileOptions = null)
        {
            List<string> ffmpegOptions = new List<string>();
            
            string baseFilename = Path.ChangeExtension(outputFile, null);
            if (baseFilename == outputFile)
            {
                outputFile += ".mp4";
            }

            PovrayOptions[] frames = this.GenerateSceneFiles(baseFilename, this.Options);
            
            string[] frameImages = this.RenderFrames(baseFilename, frames);

            string imageExtension = Path.GetExtension(frames[0].FileOutput.OutputFileName)?.Substring(1);
            
            bool sparse = this.IncludeExisting || this.FrameIncrement != 1;
            string imageFormat = this.GetFrameFormat(baseFilename, imageExtension, true, sparse);

            if (!string.IsNullOrEmpty(ffmpegGlobalOptions))
            {
                ffmpegOptions.Add(ffmpegGlobalOptions);
            } 

            ffmpegOptions.Add("-y");
            if (sparse)
            {
                ffmpegOptions.Add("-pattern_type glob");
            }
            
            if (!string.IsNullOrEmpty(ffmpegInfileOptions))
            {
                ffmpegOptions.Add(ffmpegInfileOptions);
            } 
            
            ffmpegOptions.Add("-i " + imageFormat);
            if (!sparse)
            {
                ffmpegOptions.Add("-frames " + frameImages.Length);
            }

            if (!string.IsNullOrEmpty(ffmpegOutfileOptions))
            {
                ffmpegOptions.Add(ffmpegOutfileOptions);
            }

            ffmpegOptions.Add(outputFile);
            string commandLine = string.Join(' ', ffmpegOptions);            
            
            Console.WriteLine("FFMPEG: ffmpeg {0}", commandLine);
            Process process = Process.Start("ffmpeg", commandLine);
            process?.WaitForExit();

            return outputFile;
        }
        
        
    }
}
