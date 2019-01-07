namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using Libraries;
    using Output;
    using Values;

    [BlockElement(Keyword.Interior)]
    public class Interior : ItemModifier, IIdentifiable
    {
        [ValueElement] public string Identifier { get; set; }
        [Ignore] public Library IdentifierLibrary { get; set; }

        [ValueElement(Keyword.Caustics)] public Float Caustics { get; set; }
        [ValueElement(Keyword.Dispersion)] public Float Dispersion { get; set; }
        [ValueElement(Keyword.DispersionSamples)] public int? DispersionSamples { get; set; }
        [ValueElement(Keyword.FadeColor)] public Color FadeColor { get; set; }
        [ValueElement(Keyword.FadeDistance)] public Float FadeDistance { get; set; }
        [ValueElement(Keyword.FadePower)] public Float FadePower { get; set; }
        [ValueElement(Keyword.Ior)] public Float Ior { get; set; }
        
        [Output]
        [Init]
        public Media Media { get; set; }

        
    }
}