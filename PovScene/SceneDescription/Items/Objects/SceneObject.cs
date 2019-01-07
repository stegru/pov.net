namespace PovScene.SceneDescription.Items.Objects
{
    using ObjectModifiers;
    using Output;
    using Solid;

    public class SceneObject : SceneItem
    {
        private Texture texture;
        private InteriorTexture interiorTexture;
        private Interior interior;

        [Ignore]
        public virtual Texture Texture
        {
            get
            {
                if (!this.IsRendering && this.texture == null)
                {
                    this.Texture = new Texture();
                }
                return this.texture;
            }
            set
            {
                if (this.texture != null)
                {
                    this.Modifiers.Remove(this.texture);
                }
                this.texture = value;
                if (this.texture != null)
                {
                    this.Modifiers.Add(this.texture);
                }
            }
        }

        [Ignore]
        public virtual Texture InteriorTexture
        {
            get => this.interiorTexture?.Texture;
            set
            {
                if (this.interiorTexture != null)
                {
                    this.Modifiers.Remove(this.interiorTexture);
                }
                this.interiorTexture = new InteriorTexture(value);
                if (this.interiorTexture != null)
                {
                    this.Modifiers.Add(this.interiorTexture);
                }
            }
        }

        public virtual Pigment Pigment
        {
            get => this.Texture?.Pigment;
            set
            {
                if (this.Texture == null)
                {
                    this.Texture = new Texture();
                }

                this.Texture.Pigment = value;
            }
        }

        public virtual Normal Normal
        {
            get => this.Texture?.Normal;
            set
            {
                if (this.Texture == null)
                {
                    this.Texture = new Texture();
                }

                this.Texture.Normal = value;
            }
        }

        public virtual Finish Finish
        {
            get => this.Texture?.Finish;
            set
            {
                if (this.Texture == null)
                {
                    this.Texture = new Texture();
                }

                this.Texture.Finish = value;
            }
        }

        [Ignore]
        public virtual Interior Interior
        {
            get
            {
                if (!this.IsRendering && this.interior == null)
                {
                    this.Interior = new Interior();
                }
                return this.interior;
            }
            set
            {
                if (this.interior != null)
                {
                    this.Modifiers.Remove(this.interior);
                }
                this.interior = value;
                if (this.interior != null)
                {
                    this.Modifiers.Add(this.interior);
                }
            }
        }
        
        [ObjectElement(Keyword.ClippedBy, ExcludeKeywords = new [] {Keyword.Texture})]
        public SceneObject ClippedBy { get; set; }
        
        [ObjectElement(Keyword.BoundedBy, ExcludeKeywords = new [] {Keyword.Texture})]
        public SceneObject BoundedBy { get; set; }
     
        [FlagElement(Keyword.Inverse)]
        public bool Inverse { get; set; }
        
        [ValueElement(Keyword.Hollow, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
        public bool? Hollow { get; set; }
        
        [FlagElement(Keyword.NoShadow)]
        public bool NoShadow { get; set; }
        
        [ValueElement(Keyword.NoImage, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
        public bool? NoImage { get; set; }
        
        [ValueElement(Keyword.NoRadiosity, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
        public bool? NoRadiosity { get; set; }
        
        [ValueElement(Keyword.NoReflection, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
        public bool? NoReflection { get; set; }
        
        [ValueElement(Keyword.DoubleIlluminate, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
        public bool? DoubleIlluminate { get; set; }
        
        public static CSG operator +(SceneObject left, SceneObject right)
        {
            return new Union
            {
                left,
                right
            };
        }

        public static CSG operator -(SceneObject left, SceneObject right)
        {
            return new Difference
            {
                left,
                right
            };
        }
        
        public static CSG operator &(SceneObject left, SceneObject right)
        {
            return new Intersection
            {
                left,
                right
            };
        }
        
        public static CSG operator |(SceneObject left, SceneObject right)
        {
            return new Merge
            {
                left,
                right
            };
        }
        
    }
}