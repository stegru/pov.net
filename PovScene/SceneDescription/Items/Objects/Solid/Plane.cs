namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using System.Runtime.CompilerServices;
    using Output;
    using Values;

    [BlockElement(Keyword.Plane)]
    public class Plane : SolidObject
    {
        [ObjectParameter]
        [GroupNext]
        public Vector Axis { get; set; }
        
        [ObjectParameter]
        public Float Distance { get; set; }

        public Plane(Axis normal, Float distance = default(Float))
            : this((Vector) normal, distance)
        {
        }

        public Plane(Vector normal = default(Vector), Float distance = default(Float))
        {            
            this.Axis = normal;
            this.Distance = distance.HasValue ? distance : 0;
        }
    }
}
