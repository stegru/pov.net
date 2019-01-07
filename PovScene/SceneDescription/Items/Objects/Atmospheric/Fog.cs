namespace PovScene.SceneDescription.Items.Objects.Atmospheric
{
    using Output;
    using Values;

    [BlockElement(Keyword.Fog, OnlyWithContent = false)]
    public class Fog : SceneItem
    {
        public bool GroundFog { get; set; }
        [ValueElement(Keyword.FogType)] protected int FogType => this.GroundFog ? 2 : 1;
        [ValueElement(Keyword.Distance)] public Float Distance { get; set; }
        [ValueElement(Keyword.Color)] public Color Color { get; set; }
        [ValueElement(Keyword.Turbulence, Float = true)] public Vector Turbulence { get; set; }
        [ValueElement(Keyword.TurbDepth)] public Float Turb_depth { get; set; }
        [ValueElement(Keyword.Omega)] public Float Omega { get; set; }
        [ValueElement(Keyword.Lambda)] public Float Lambda { get; set; }
        [ValueElement(Keyword.Octaves)] public Float Octaves { get; set; }
        [ValueElement(Keyword.FogOffset)] public Float FogOffset { get; set; }
        [ValueElement(Keyword.FogAlt)] public Float FogAlt { get; set; }
        [ValueElement(Keyword.Up, Direction = true)] public Vector Up { get; set; }
    }
}