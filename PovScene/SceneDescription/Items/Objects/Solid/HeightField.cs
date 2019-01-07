namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using Output;
    using Values;

    [BlockElement(Keyword.HeightField)]
    public class HeightField : SolidObject
    {
        [Output]
        public PovImage Image { get; set; }
        
        [FlagElement(Keyword.Smooth)]
        public bool Smooth { get; set; }
        
        [ValueElement(Keyword.WaterLevel)]
        public Float WaterLevel { get; set; }
        
        [ValueElement(Keyword.Hierarchy)]
        public bool? Hierarchy { get; set; }

        public HeightField()
        {
        }

        public HeightField(PovImage image = null, bool? smooth = null, Float waterLevel = default(Float))
        {
            this.Image = image;
            if (smooth != null)
            {
                this.Smooth = (bool)smooth;
            }

            this.WaterLevel = waterLevel;
        }
    }
}