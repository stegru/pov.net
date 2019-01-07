namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using Output;
    using Values;

    [BlockElement(Keyword.Isosurface)]
    public class Isosurface : SolidObject
    {
        [ObjectParameter]
        public Function Function { get; set; }
        
        [ObjectElement(Keyword.ContainedBy)]
        public IIsoContainer ContainedBy { get; set; }

        [ValueElement(Keyword.Threshold)] public Float Threshold { get; set; }

        [ValueElement(Keyword.Accuracy)] public Float Accuracy { get; set; }

        [ValueElement(Keyword.MaxGradient)] public Float MaxGradient { get; set; }

        public Float EvaluateP0 { get; set; }
        public Float EvaluateP1 { get; set; }
        public Float EvaluateP2 { get; set; }

        [ValueElement(Keyword.Evaluate, IsCollection = true, CollectionJoin = ",")]
        protected Float[] EvaluateOutput =>
            (this.EvaluateP0.HasValue || this.EvaluateP1.HasValue || this.EvaluateP2.HasValue)
                ? new Float[] {this.EvaluateP0, this.EvaluateP1, this.EvaluateP2}
                : null;

        [FlagElement(Keyword.Open)]
        public bool Open { get; set; }

        [FlagElement(Keyword.AllIntersections)]
        public bool AllIntersections { get; set; }
        
        [ValueElement(Keyword.MaxTrace)]
        public int MaxTrace { get; set; }
        
        [ValueElement(Keyword.Polarity, PovVersion = 3.8)]
        public bool? Polarity { get; set; }
        
        public Isosurface()
        {
        }
    }

    public interface IIsoContainer : IValue
    {
    }    
}
