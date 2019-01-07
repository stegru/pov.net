namespace PovScene.Platform
{
    using System;

    /// <summary>
    /// Linux specific code. Call via OS.Current, not directly.
    /// </summary>
    public class Linux : OS
    {
        /// <inheritdoc />
        public override string FontPath => "/usr/share/fonts/truetype";

        /// <inheritdoc />
        public override string PovrayBinary => "povray";

        internal Linux()
        {
            if (!OS.IsLinux)
            {
                throw new InvalidOperationException("The Linux class only works on Linux.");
            }
        }
    }
}