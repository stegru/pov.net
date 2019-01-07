namespace PovScene.SceneDescription.Items.Lights
{
    using System;
    using System.Linq;
    using Libraries;
    using Objects;
    using Objects.Solid;
    using Output;
    using Values;

    /// <!-- pov:light_source -->
    [BlockElement(Keyword.LightSource)]
    public class LightSource : SceneObject
    {
        [ObjectParameter]
        [GroupNext]
        public Vector Location { get; set; } = Vector.Zero;
        
        [ObjectParameter]
        public Color Color { get; set; }
        
        [ValueElement(Order = -1000)]
        public Keyword LightType { get; protected set; }
        
        [FlagElement(Keyword.Parallel)]
        public bool Parallel { get; set; }
        
        [FlagElement(Keyword.Shadowless)]
        public bool Shadowless { get; set; }
        
        [BlockElement(Keyword.LooksLike, Wrapper = true)]
        public SolidObject LooksLike { get; set; }
        
        [ValueElement(Keyword.FadeDistance)]
        public Float FadeDistance { get; set; }
        
        [ValueElement(Keyword.FadePower)]
        public Float FadePower { get; set; }
        
        [ValueElement(Keyword.MediaAttenuation)]
        public Float MediaAttenuation { get; set; }
        
        [ValueElement(Keyword.MediaInteraction)]
        public Float MediaInteraction { get; set; }
        
        [BlockElement(Keyword.ProjectedThrough,Wrapper = true)]
        public SolidObject ProjectedThrough { get; set; }

        private LightSource()
        {
            this.LightType = this.GetType().GetAllAttributes<KeywordAttribute>().FirstOrDefault()?.Keyword ??
                             Keyword.Null;
        }

        public LightSource(Vector location) : this(location, Colors.White)
        {
        }
        
        public LightSource(Vector location, Color color) : this()
        {
            this.Location = location;
            this.Color = color;
        }

        [Keyword(Keyword.Spotlight)]
        public class Spotlight : LightSource
        {
            [ValueElement(Keyword.Radius)]
            public Float Radius { get; set; }
            
            [ValueElement(Keyword.Falloff)]
            public Float Falloff { get; set; }
            
            [ValueElement(Keyword.Tightness)]
            public Float Tightness { get; set; }
            
            [ValueElement(Keyword.PointAt)]
            public Vector PointAt { get; set; }

            public Spotlight()
            {
            }

            public Spotlight(Vector location) : base(location)
            {
            }

            public Spotlight(Vector location, Vector pointAt, Color color) : base(location, color)            
            {
                this.PointAt = pointAt;
            }
            
            public Spotlight(Vector location, Vector pointAt) : this(location, pointAt, Colors.White)
            {
            }
        }

        [Keyword(Keyword.Cylinder)]
        public class Cylinder : Spotlight
        {
            public Cylinder()
            {
            }

            public Cylinder(Vector location) : base(location)
            {
            }

            public Cylinder(Vector location, Vector pointAt, Color color) : base(location, pointAt, color)
            {
            }

            public Cylinder(Vector location, Vector pointAt) : base(location, pointAt)
            {
            }
        }

        [Keyword(Keyword.AreaLight)]
        public class Area : LightSource
        {
            [ObjectParameter(GroupNext = true)] public Vector Axis1 { get; set; }
            [ObjectParameter] public Vector Axis2 { get; set; }
            [ObjectParameter(GroupNext = true)] public Vector Size1 { get; set; }
            [ObjectParameter] public Vector Size2 { get; set; }

            [ValueElement(Keyword.Adaptive)]
            public int Adaptive { get; set; }
            
            [ValueElement(Keyword.AreaIllumination)]
            public bool? AreaIllumination { get; set; }
            
            [FlagElement(Keyword.Jitter)]
            public bool Jitter { get; set; }
            
            [FlagElement(Keyword.Circular)]
            public bool Circular { get; set; }
            
            [FlagElement(Keyword.Orient)]
            public bool Orient { get; set; }
            
            public Area()
            {
            }

            public Area(Vector location) : base(location)
            {
            }

            public Area(Vector location, Color color) : base(location, color)
            {
            }

            public Area(Vector location, Vector axis1, Vector size1, Vector axis2, Vector size2, Color color)
                : base(location, color)
            {
                this.Axis1 = axis1;
                this.Axis2 = axis2;
                this.Size1 = size1;
                this.Size2 = size2;
            }

            public Area(Vector location, Vector axis1, Vector size1, Vector axis2, Vector size2)
                : this(location, axis1, size1, axis2, size2, Colors.White)
            {                
            }
        }
    }
}