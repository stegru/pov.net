namespace PovScene.SceneDescription.Items
{
    using Output;
    using Values;


    [BlockElement(Keyword.Camera)]
    public class Camera : SceneItem
    {
        [ValueElement]
        public Keyword CameraType { get; set; }

        [ValueElement(Keyword.Location)]
        public Vector Location { get; set; }
        
        [ValueElement(Keyword.LookAt)]
        public Vector LookAt { get; set; }

        [ValueElement(Keyword.Angle, IsCollection = true)]
        protected Float[] Angle => this.AngleHorizontal.HasValue || this.AngleVertical.HasValue
            ? (this.AngleVertical.HasValue
                ? new[] {this.AngleHorizontal, this.AngleVertical}
                : new[] {this.AngleHorizontal})
            : null;


        public Float AngleHorizontal { get; set; }
        public Float AngleVertical { get; set; }


        [ValueElement(Keyword.Right, Direction = true)]
        public Vector Right { get; set; }
        
        [ValueElement(Keyword.Up, Direction = true)]
        public Vector Up { get; set; }
        
        [ValueElement(Keyword.Confidence)]
        public Float Confidence { get; set; }
        
        [ValueElement(Keyword.FocalPoint)]
        public Vector FocalPoint { get; set; }
        
        [ValueElement(Keyword.Sky, Direction = true)]
        public Vector Sky { get; set; }
        
        [ValueElement(Keyword.Variance)]
        public Float Variance { get; set; }

        [ValueElement(Keyword.BlurSamples, IsCollection = true, CollectionJoin = ",")]
        protected int?[] BlurSamplesOutput { get; set; } = {null, null};

        public int? BlurSamplesMin { get => this.BlurSamplesOutput[0]; set => this.BlurSamplesOutput[0] = value; }
        public int? BlurSamples { get => this.BlurSamplesOutput[1]; set => this.BlurSamplesOutput[1] = value; }
        
        
        public Camera()
        {
        }

        public Camera(Vector location) : this(location, (0, 0, 0))
        {
        }

        public Camera(Vector location, Vector lookAt)
        {
            this.Location = location;
            this.LookAt = lookAt;
        }
    }
}