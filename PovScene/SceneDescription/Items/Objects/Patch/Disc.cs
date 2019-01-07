namespace PovScene.SceneDescription.Items.Objects.Patch
{
    using Output;
    using Values;

    [BlockElement(Keyword.Disc)]
    public class Disc : SceneObject
    {
        [ObjectParameter]
        [GroupNext]
        public Vector Center { get; set; }
        
        [ObjectParameter]
        [GroupNext]
        public Vector Normal { get; set; }
        
        [ObjectParameter]
        [GroupNext]
        public Float Radius { get; set; }

        [ObjectParameter]
        public Float HoleRadius { get; set; }

        public Disc(Vector center = default(Vector), Vector normal = default(Vector), Float radius = default(Float), Float holeRadius = default(Float))
        {
            this.Center = center;
            this.Normal = normal;
            this.Radius = radius;
            this.HoleRadius = holeRadius;
        }
    }
}