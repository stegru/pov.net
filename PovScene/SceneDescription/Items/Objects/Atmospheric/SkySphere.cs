namespace PovScene.SceneDescription.Items.Objects.Atmospheric
{
    using ObjectModifiers;
    using Output;
    using Values;

    [BlockElement(Keyword.SkySphere)]
    public class SkySphere : SceneItem
    {
        [ValueElement(Keyword.Emission)]
        public Color Emission { get; set; }
        
        [Output(After = nameof(Emission))]
        public Pigment Pigment { get; set; }
    }
}