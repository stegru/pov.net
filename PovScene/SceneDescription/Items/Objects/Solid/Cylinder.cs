namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using Output;
    using Values;

    [BlockElement(Keyword.Cylinder)]
    public class Cylinder : SolidObject, IBlobItem
    {
        [ObjectParameter]
        [GroupNext]
        public Vector BasePoint { get; set; }
        [ObjectParameter]
        [GroupNext]
        public Vector CapPoint { get; set; }
        [ObjectParameter]
        public Float Radius { get; set; }
        
        [FlagElement(Keyword = Keyword.Open)]
        public bool Open { get; set; }

        public Cylinder(Vector basePoint = default(Vector), Vector capPoint = default(Vector),
            Float radius = default(Float), bool open = false)
        {
            this.BasePoint = basePoint;
            this.CapPoint = capPoint;
            this.Radius = radius;
            this.Open = open;
        }
    }
}