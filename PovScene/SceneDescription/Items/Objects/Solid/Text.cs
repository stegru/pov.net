namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using System.IO;
    using Output;
    using Platform;
    using Values;

    [BlockElement(Keyword.Text)]
    public class TextObject : SolidObject
    {

        [GroupNext]
        [ValueElement]
        protected Keyword FontType => Keyword.Ttf;

        [StringElement]
        protected string FontPath { get; set; }

        [Ignore]
        public string FontName
        {
            get => this.FontPath;
            set { this.FontPath = this.FindFontPath(value) ?? value; }
        }

        [StringElement]
        public string Text { get; set; }
        
        [ValueElement(ContentEnd = ",", Required = true, GroupNext = true)]
        public Float Thickness { get; set; }
        
        [ValueElement(Required = true)]
        public Vector Offset { get; set; }

        public TextObject()
        {
        }

        public TextObject(string fontName, string text, Float thickness, Vector offset)
        {
            this.FontName = fontName;
            this.Text = text;
            this.Thickness = thickness;
            this.Offset = offset;
        }
        
        /// <summary>
        /// Searches within the font directory for the full path of a font file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The full path to the font file, or null.</returns>
        private string FindFontPath(string file, string searchPath = null)
        {
            string path = Path.Combine(searchPath ?? string.Empty, file);
            if (File.Exists(path))
            {
                return path;
            }

            if (searchPath == null)
            {
                return OS.Current.FontPath == null ? null : this.FindFontPath(file, OS.Current.FontPath);
            }

            foreach (string directory in Directory.EnumerateDirectories(searchPath))
            {
                path = this.FindFontPath(file, directory);
                if (path != null)
                {
                    return path;
                }
            }

            return null;
        }

        
    }
}