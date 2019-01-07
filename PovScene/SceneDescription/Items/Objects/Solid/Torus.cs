namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using Output;
    using Values;

    [BlockElement(Keyword.Torus)]
    public class Torus : SolidObject
    {
        [ObjectParameter]
        [GroupNext]
        public Float MajorRadius { get; set; }
        
        [ObjectParameter]
        public Float MinorRadius { get; set; }
        
        [ValueElement(PovVersion = 3.8)]
        public SpindleModes SpindleMode { get; set; }

        [FlagElement(Keyword.Sturm)]
        public bool Sturm { get; set; }
        
        public Torus()
        {
        }

        public Torus(Float majorRadius, Float minorRadius, SpindleModes spindleMode = SpindleModes.Undefined)
        {
            this.MajorRadius = majorRadius;
            this.MinorRadius = minorRadius;
            this.SpindleMode = spindleMode;
        }

        public enum SpindleModes
        {
            [Keyword(Keyword.Undefined)]
            Undefined,
            [Keyword(Keyword.Difference)]
            Difference,
            [Keyword(Keyword.Intersection)]
            Intersection,
            [Keyword(Keyword.Merge)]
            Merge,
            [Keyword(Keyword.Union)]
            Union
        } 
    }    
}
