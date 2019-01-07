namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using Output;
    using Values;

    [BlockElement(Keyword.Box)]
    public class Box : SolidObject, IIsoContainer
    {
        [ObjectParameter]
        [GroupNext]
        public Vector Corner1 { get; set; }
        [ObjectParameter]
        public Vector Corner2 { get; set; }

        public Box(Vector corner1 = default(Vector), Vector corner2 = default(Vector))
        {
            this.Corner1 = corner1;
            this.Corner2 = corner2;
        }
    }

    
}