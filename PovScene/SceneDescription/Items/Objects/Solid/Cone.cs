namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using Output;
    using Values;

    [BlockElement(Keyword.Cone)]
    public class Cone : SolidObject
    {
        [ObjectParameter(Required = false)]
        [GroupNext]
        public Vector Base { get; set; }

        [ObjectParameter]
        public Float BaseRadius { get; set; }

        [ObjectParameter]
        [GroupNext]
        public Vector Cap { get; set; }

        [ObjectParameter]
        public Float CapRadius { get; set; }

        public Cone(Vector @base = default(Vector), Float baseRadius = default(Float),
            Vector cap = default(Vector), Float capRadius = default(Float))
        {
            this.Base = @base;
            this.BaseRadius = baseRadius;
            this.Cap = cap;
            this.CapRadius = capRadius;
        }
    }
}