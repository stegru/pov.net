namespace PovScene.SceneDescription.Values
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Libraries;
    using Util;

    public struct Color : IValue, IRenderNotify, IIdentifiable
    {
        public string Identifier { get; set; }
        public Library IdentifierLibrary { get; set; }

        public bool HasValue => this.Identifier != null
                                || this.Red.HasValue || this.Green.HasValue || this.Blue.HasValue
                                || this.Filter.HasValue || this.Transmit.HasValue;

        public Color(Float red, Float green, Float blue = default(Float))
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Filter = default(Float);
            this.Transmit = default(Float);
            this.StandardRgb = false;
            this.Identifier = null;
            this.IdentifierLibrary = null;

        }

        public Color(Float red, Float green, Float blue, Float filter) : this(red, green, blue)
        {
            this.Filter = filter;
        }

        public Color(Float red, Float green, Float blue, Float filter, Float transmit) : this(red, green, blue, filter)
        {
            this.Transmit = transmit;
        }

        public Color(Float rgb = default(Float)) : this(rgb, rgb, rgb)
        {
        }

        internal Color(string identifier) : this()
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                return;
            }

            // #rgb #rrggbb
            if (identifier[0] == '#')
            {
                if (identifier.Length == 4)
                {
                    this.Red = Math.Round(new string(identifier[1], 2).FromHex() / 255.0, 2);
                    this.Green = Math.Round(new string(identifier[2], 2).FromHex() / 255.0, 2);
                    this.Blue = Math.Round(new string(identifier[3], 2).FromHex() / 255.0, 2);
                }
                else
                {
                    identifier += "000000";
                    this.Red = Math.Round(identifier.Substring(1, 2).FromHex() / 255.0, 2);
                    this.Green = Math.Round(identifier.Substring(3, 2).FromHex() / 255.0, 2);
                    this.Blue = Math.Round(identifier.Substring(5, 2).FromHex() / 255.0, 2);
                }
            }
            else
            {
                this.Identifier = identifier;
            }
        }

        public Color(Color baseColor, Float filter = default(Float), Float transmit = default(Float))
        {
            this.Red = baseColor.Red;
            this.Green = baseColor.Green;
            this.Blue = baseColor.Blue;
            this.Identifier = baseColor.Identifier;
            this.IdentifierLibrary = baseColor.IdentifierLibrary;
            this.StandardRgb = baseColor.StandardRgb;

            this.Filter = filter.HasValue ? filter : baseColor.Filter;
            this.Transmit = transmit.HasValue ? transmit : baseColor.Filter;
        }

        public bool StandardRgb { get; set; }

        public Float Red { get; set;}

        public Float Green { get; set;}

        public Float Blue { get; set;}

        public Float Filter { get; set;}

        public Float Transmit { get; set;}
        
        public static implicit operator (Float, Float, Float)(Color color)
        {
            return (color.Red, color.Green, color.Blue);
        }
        public static implicit operator Color((Float r, Float g, Float b) rgb)
        {
            return new Color(rgb.r, rgb.g, rgb.b);
        }
        public static implicit operator Color((Float r, Float g, Float b, Float f) rgbf)
        {
            return new Color(rgbf.r, rgbf.g, rgbf.b, rgbf.f);
        }
        public static implicit operator Color((Float r, Float g, Float b, Float f, Float t) rgbft)
        {
            return new Color(rgbft.r, rgbft.g, rgbft.b, rgbft.f, rgbft.t);
        }
        public static implicit operator Color(string text)
        {
            return Color.FromString(text);
        }
        public static implicit operator Color(Vector vector)
        {
            return new Color(vector.x, vector.y, vector.z);
        }

        public static implicit operator Color(Float f)
        {
            return new Color(f, f, f, f, f);
        }

        public static implicit operator Color(double f)
        {
            return new Color(f, f, f, f, f);
        }

        public static Color operator *(Color c1, Float f)
        {
            return new Color(
                c1.Red * f,
                c1.Green * f,
                c1.Blue * f,
                c1.Filter * f,
                c1.Transmit * f
            );
        }
        public static Color operator *(Float f, Color c1)
        {
            return c1 * f;
        }
        public static Color operator /(Color c1, Float f)
        {
            return new Color(
                (c1.Red / f),
                (c1.Green / f),
                (c1.Blue / f),
                (c1.Filter / f),
                (c1.Transmit / f)
            );
        }
        public static Color operator /(Float f, Color c1)
        {
            return c1 / f;
        }

        public static Color FromString(string str)
        {
            return new Color(str);
        }

        public static Color Rgb(Float red, Float green, Float blue)
        {
            return new Color(red, green, blue);
        }

        public static Color Rgbf(Float red, Float green, Float blue, Float filter)
        {
            return new Color(red, green, blue, filter);
        }

        public static Color Rgbt(Float red, Float green, Float blue, Float transmit)
        {
            return new Color(red, green, blue, default(Float), transmit);
        }

        public static Color Rgbft(Float red, Float green, Float blue, Float filter, Float transmit)
        {
            return new Color(red, green, blue, filter, transmit);
        }

        /// <summary>
        /// Returns a color with only the RGB components.
        /// </summary>
        /// <param name="color"></param>
        public static Color ToRgb(Color color)
        {
            return new Color(color.Red, color.Green, color.Blue);
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Identifier == null)
            {
                List<Float> values = new List<Float>();
                Keyword keyword = Keyword.Rgb;
                values.Add(this.Red);
                values.Add(this.Green);
                values.Add(this.Blue);

                if (this.Filter.HasValue)
                {
                    values.Add(this.Filter);
                    if (this.Transmit.HasValue)
                    {
                        keyword = Keyword.Rgbft;
                        values.Add(this.Transmit);
                    }
                    else
                    {
                        keyword = Keyword.Rgbf;
                    }
                }
                else if (this.Transmit.HasValue)
                {
                    keyword = Keyword.Rgbt;
                    values.Add(this.Transmit);
                }

                if (this.StandardRgb)
                {
                    switch (keyword)
                    {
                        case Keyword.Rgb:
                            keyword = Keyword.Srgb;
                            break;
                        case Keyword.Rgbf:
                            keyword = Keyword.Srgbf;
                            break;
                        case Keyword.Rgbt:
                            keyword = Keyword.Srgbt;
                            break;
                        case Keyword.Rgbft:
                            keyword = Keyword.Srgbft;
                            break;
                    }
                }

                sb.Append(KeywordAttribute.ToString(keyword))
                    .Append(" <")
                    .AppendJoin(", ", values.Select(v => Math.Round(v.Value, 3)))
                    .Append(">");
            }
            else
            {
                // Use the identifier, with the new values added
                sb.Append(this.Identifier).Append(' ');

                void Add(Keyword k, Float v)
                {
                    if (v.HasValue)
                    {
                        sb.Append(KeywordAttribute.ToString(k))
                            .Append(' ')
                            .Append(v)
                            .Append(' ');
                    }
                }

                Add(Keyword.Red, this.Red);
                Add(Keyword.Green, this.Green);
                Add(Keyword.Blue, this.Blue);
                Add(Keyword.Filter, this.Filter);
                Add(Keyword.Transmit, this.Transmit);
            }

            return sb.ToString().Trim();
        }

        public void RenderNotify(ElementContext context)
        {
            if (this.Identifier != null)
            {
                context.Scene.Include.Colors = true;
            }
        }
    }
}