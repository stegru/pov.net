namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using Output;
    using Values;

    [BlockElement(Keyword.Media)]
    public class Media : SceneElement
    {
        [ValueElement] public string Identifier { get; }
        
        [ValueElement(Keyword.Absorption)] public Color Absorption { get; set; }
        [ValueElement(Keyword.Emission)] public Color Emission { get; set; }
        [ValueElement(Keyword.Scattering)] public Float Scattering { get; set; }
        
        [ValueElement(Keyword.AaLevel)] public Float AaLevel { get; set; }
        [ValueElement(Keyword.AaThreshold)] public Float AaThreshold { get; set; }
        [ValueElement(Keyword.Jitter)] public Float Jitter { get; set; }
        
        [ValueElement(Keyword.Confidence)] public Float Confidence { get; set; }
        [ValueElement(Keyword.Intervals)] public Float Intervals { get; set; }
        [ValueElement(Keyword.Method)] public Float Method { get; set; }
        [ValueElement(Keyword.Ratio)] public Float Ratio { get; set; }
        [ValueElement(Keyword.Samples)] public Float Samples { get; set; }
        [ValueElement(Keyword.Variance)] public Float Variance { get; set; }        
    }

    [BlockElement(Keyword.Scattering)]
    public class Scattering : SceneElement
    {
        [ObjectParameter]
        [GroupNext]
        public ScatteringType Type { get; set; }
        
        [ObjectParameter]
        public Color Color { get; set; }
        
        [ValueElement(Keyword.Eccentricity)] public Float Eccentricity { get; set; }
        [ValueElement(Keyword.Extinction)] public Float Extinction { get; set; }
    }

    public enum ScatteringType
    {
        Isotrpoic = 1,
        MieHaze = 2,
        MieMurky = 3,
        Rayleigh = 4,
        HenyeyGreenstein = 5
    }
}















