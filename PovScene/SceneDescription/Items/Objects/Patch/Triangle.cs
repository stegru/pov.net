namespace PovScene.SceneDescription.Items.Objects.Patch
{
    using Output;
    using Values;

    [BlockElement(Keyword.Triangle)]
    public class Triangle : SceneObject
    {
        [ObjectParameter]
        [GroupNext]
        public Vector Corner1 { get; set; }
        
        [ObjectParameter]
        [GroupNext]
        public Vector Corner2 { get; set; }
        
        [ObjectParameter]
        [GroupNext]
        public Vector Corner3 { get; set; }

        public Triangle()
        {
        }

        public Triangle(Vector corner1, Vector corner2, Vector corner3)
        {
            this.Corner1 = corner1;
            this.Corner2 = corner2;
            this.Corner3 = corner3;
        }
    }
}