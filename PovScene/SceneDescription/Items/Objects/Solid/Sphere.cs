namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using Output;
    using Values;

    [BlockElement(Keyword.Sphere)]
    public class Sphere : SolidObject, IBlobItem, IIsoContainer
    {
        [ObjectParameter]
        [GroupNext]
        public Vector Center { get; set; }
        
        [ObjectParameter]
        public Float Radius { get; set; }

        /// <summary>
        /// hhhh
        /// </summary>
        public Sphere()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="center"><see cref="Center"/></param>
        /// <param name="radius"></param>
        public Sphere(Vector center = default(Vector), Float radius = default(Float))
        {
            this.Center = center;
            this.Radius = radius;
        }
        
        
    }    
}
