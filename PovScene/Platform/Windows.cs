namespace PovScene.Platform
{
    using System;
    using System.IO;
    using Microsoft.Win32;

    /// <summary>
    /// Windows specific code. Call via OS.Current, not directly.
    /// </summary>
    public class Windows : OS
    {
        /// <inheritdoc />
        /// The font path on Windows is not required.
        public override string FontPath { get; } = null;

        /// <inheritdoc />
        public override string PovrayBinary { get; }
    

        internal Windows()
        {
            if (!OS.IsWindows)
            {
                throw new InvalidOperationException("The Windows class only works on Windows.");
            }
            
            // Get the location of pvengine.exe
            // TODO: Support other versions than v3.7
            string homePath =
                Registry.GetValue(@"HKEY_CURRENT_USER\Software\POV-Ray\v3.7\Windows", "Home", null) as string
                ?? @"C:\Program Files\POV-Ray\v3.7";

            string exe = Environment.Is64BitOperatingSystem ? "pvengine64.exe" : "pvengine.exe";
            string exePath = Path.Combine(homePath, "bin", exe);
            this.PovrayBinary = exePath;
            
            Console.WriteLine("EXE:" + this.PovrayBinary);
        }
    }
}