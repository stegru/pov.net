namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using System;
    using Libraries;
    using Output;
    using Values;

    [BlockElement(Keyword.Finish)]
    public class Finish : TextureModifier, IIdentifiable
    {
        [ValueElement]
        public string Identifier { get; set; }

        [Ignore]
        public Library IdentifierLibrary { get; set; }

        [ValueElement(Keyword.Diffuse)]
        protected string DiffuseOutput => (this.DiffuseAlbedo || this.Diffuse.HasValue)
            ? (this.DiffuseAlbedo ? KeywordAttribute.ToString(Keyword.Albedo) + " " : string.Empty) +
              this.Diffuse.ToString()
            : null;


        [ValueElement(Keyword.Phong)]
        protected string PhongOutput => (this.PhongAlbedo || this.Phong.HasValue)
            ? (this.PhongAlbedo ? KeywordAttribute.ToString(Keyword.Albedo) + " " : string.Empty) +
              this.Phong.ToString()
            : null;

        [ValueElement(Keyword.Specular)]
        protected string SpecularOutput => (this.SpecularAlbedo || this.Specular.HasValue)
            ? (this.SpecularAlbedo ? KeywordAttribute.ToString(Keyword.Albedo) + " " : string.Empty) +
              this.Specular.ToString()
            : null;

        public Float Diffuse { get; set; }
        public bool DiffuseAlbedo { get; set; }
        public Float Phong { get; set; }
        public bool PhongAlbedo { get; set; }
        public Float Specular { get; set; }
        public bool SpecularAlbedo { get; set; }

        [ValueElement(Keyword.Fresnel)]
        public Float Fresnel { get; set; }

        [ValueElement(Keyword.Ambient, Rgb = true, Float = true)]
        public Color Ambient { get; set; }

        [ValueElement(Keyword.Emission, Float = true)]
        public Color Emission { get; set; }

        [ValueElement(Keyword.Brilliance)]
        public Float Brilliance { get; set; }

        [ValueElement(Keyword.PhongSize)]
        public Float PhongSize { get; set; }

        [ValueElement(Keyword.Roughness)]
        public Float Roughness { get; set; }

        [ValueElement(Keyword.Metallic)]
        public Float Metallic { get; set; }

        [ValueElement(Keyword.Crand)]
        public Float Crand { get; set; }

        [FlagElement(Keyword.ConserveEnergy)]
        public bool ConserveEnergy { get; set; }

        [FlagElement(Keyword.UseAlpha)]
        public bool UseAlpha { get; set; }

        [Output]
        public FinishReflection Reflection { get; set; } = new FinishReflection();

        [Output]
        public Iridescence Irid { get; set; } = new Iridescence();

        public Finish()
        {
        }

        public Finish(Finish finish)
        {
            if (finish.Identifier != null)
            {
                this.Identifier = finish.Identifier;
                this.IdentifierLibrary = finish.IdentifierLibrary;
            }
            else
            {
                throw new ArgumentException("Provide a Finish with an identifier");
            }
        }
    }

    [BlockElement(Keyword.Irid)]
    public class Iridescence : SceneElement
    {
        [ObjectParameter]
        public Float Amount { get; set; }

        [ValueElement(Keyword.Thickness)]
        public Float Thickness { get; set; }

        [ValueElement(Keyword.Turbulence)]
        public Float Turbulence { get; set; }
    }

    [BlockElement(Keyword.Reflection)]
    public class FinishReflection : SceneElement
    {
        [ObjectParameter(Float = true, Required = false)]
        public Color ColorMin { get; set; }

        [ObjectParameter(Float = true)]
        public Color Color { get; set; }

        [ValueElement(Keyword.Fresnel)]
        public Float Fresnel { get; set; }

        [ValueElement(Keyword.Falloff)]
        public Float Falloff { get; set; }

        [ValueElement(Keyword.Exponent)]
        public Float Exponent { get; set; }

        [ValueElement(Keyword.Metallic)]
        public Float Metallic { get; set; }

        public FinishReflection()
        {
        }

        public FinishReflection(Color color)
        {
            this.Color = color;
        }

        public FinishReflection(Color minColor, Color maxColor)
        {
            this.ColorMin = minColor;
            this.Color = maxColor;
        }

        public static implicit operator FinishReflection(Color color)
        {
            return new FinishReflection(color);
        }

        public static implicit operator FinishReflection(Float amount)
        {
            return new FinishReflection(amount);
        }

        public static implicit operator FinishReflection(double amount)
        {
            return new FinishReflection((Float) amount);
        }

    }

    public class FlagValue : SceneElement
    {
        [FlagElement]
        public bool Flag { get; set; }

        [ValueElement]
        public IValue Value { get; set; }
    }
}