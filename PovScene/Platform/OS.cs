namespace PovScene.Platform
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    /// <summary>
    /// The base of OS Specific code.
    /// </summary>
    public abstract class OS
    {
        /// <summary>The instance of the OS specific for the current platform.</summary>
        public static OS Current;

        /// <summary>true if the current OS is Linux.</summary>
        public static bool IsLinux { get; }

        /// <summary>true if the current OS is Windows.</summary>
        public static bool IsWindows { get; }
        

        static OS()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                IsLinux = true;
                Current = new Linux();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                IsWindows = true;
                Current = new Windows();
            }
        }

        /// <summary>The path where the true-type font files are located.</summary>
        public abstract string FontPath { get; }
        
        /// <summary>Povray executable path.</summary>
        public abstract string PovrayBinary { get; }

        public virtual string TempDir => "/tmp";

        /// <summary>Starts a process.</summary>
        /// <param name="filename">Path of the executable.</param>
        /// <param name="args">Arguments for the invocation.</param>
        public Task<int> Run(string filename, params string[] args)
        {
            string argString = string.Join(' ', args);
            
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo(filename, argString),
                EnableRaisingEvents = true
            };

            TaskCompletionSource<int> processComplete = new TaskCompletionSource<int>();

            void Exited(object sender, EventArgs eventArgs)
            {
                if (sender is Process p)
                {
                    processComplete.TrySetResult(p.ExitCode);
                    p.Exited -= Exited;
                    p.Dispose();
                }
            }
            
            process.Exited += Exited;

            process.Start();

            return processComplete.Task;
        }
    }
}