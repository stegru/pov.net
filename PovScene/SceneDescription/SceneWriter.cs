namespace PovScene.SceneDescription
{
    using System.Text;

    /// <summary>
    /// Writes things to a scene file.
    /// </summary>
    public class SceneWriter
    {
        private StringBuilder output = new StringBuilder();
        private int indentLevel = 0;
        private string indentation = "";

        /// <summary>Current length of the scene file.</summary>
        public int Length
        {
            get => this.output.Length;
            set => this.output.Length = value;
        }

        /// <summary>Current level of indentation.</summary>
        public int IndentLevel
        {
            get => this.indentLevel;
            set
            {
                this.indentLevel = value; 
                this.indentation = new string(' ', this.indentLevel * 2);
            }
        }


        public override string ToString()
        {
            return this.output.ToString();
        }

        /// <summary>Increase the indentation level.</summary>
        /// <param name="newLine"></param>
        /// <returns>this</returns>
        public SceneWriter Indent(bool newLine = false)
        {
            this.IndentLevel++;
            if (newLine)
            {
                this.AppendLine();
            }

            return this;
        }

        /// <summary>Decrease the indentation level.</summary>
        /// <param name="newLine"></param>
        /// <returns>this</returns>
        public SceneWriter Unindent(bool newLine = false)
        {
            while (this.output.Length > 0 && char.IsWhiteSpace(this.output[this.output.Length - 1]))
            {
                this.output.Length--;
            }

            this.IndentLevel--;

            if (newLine)
            {
                this.AppendLine();
            }
            
            return this;
        }

        /// <summary>Determine if a space is required, between two characters.</summary>
        /// <param name="prev">First character</param>
        /// <param name="next">Next character</param>
        /// <returns>true if the two characters should be spaced.</returns>
        private bool WantSpace(char prev, char next)
        {
            if (next == ',' || next == '>')
            {
                return false;
            }
            if (prev == ',' || prev == '<')
            {
                return true;
            }

            if (char.IsWhiteSpace(prev) || char.IsWhiteSpace(prev))
            {
                return false;
            }

            if (char.IsLetterOrDigit(prev) && char.IsLetterOrDigit(next))
            {
                return true;
            }

            if (prev == '"')
            {
                return false;
            }

            if (next == '{')
            {
                return true;
            }

            return true;
        }

        /// <summary>Roll-back all whitespace at the end.</summary>
        public void Unspace()
        {
            for (;
                this.output.Length > 0 && char.IsWhiteSpace(this.output[this.output.Length - 1]);
                this.output.Length--)
            {
            }
        }

        /// <summary>Append some text.</summary>
        /// <param name="text">The text.</param>
        /// <param name="space">true to at a space in front, null to auto-detect.</param>
        /// <returns>this.</returns>
        public SceneWriter Append(string text, bool? space = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return this;
            }


            if (this.output.Length > 0)
            {
                if (space == false)
                {
                    this.Unspace();
                }
                char lastChar = this.output.Length > 0 ? this.output[this.output.Length - 1] : '\0';

                if (space ?? this.WantSpace(lastChar, text[0]))
                {
                    this.output.Append(' ');
                }
            }
            this.output.Append(text);
            
            if (text[0] == '}')
            {
                this.AppendLine();
            }


            return this;
        }

        /// <summary>Append a line.</summary>
        /// <returns>this.</returns>
        public SceneWriter AppendLine()
        {
            this.output.AppendLine().Append(this.indentation);
            return this;
        }

        /// <summary>Gets a sub-string from the buffer.</summary>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns>The sub-string/</returns>
        public string SubString(int startIndex, int length = -1)
        {
            if (length == -1)
            {
                length = this.output.Length - startIndex;
            }
            return this.output.ToString(startIndex, length);
        }
    }
}