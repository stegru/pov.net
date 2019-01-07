#define PIGMENT

namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Libraries;
    using Output;
    using Values;

    public class PigmentOrNormal : TextureModifier, IIdentifiable
    {
        private ShapeWarp shapeWarp;
        private Axis shapeWarpDirection;

        [ValueElement]
        public string Identifier { get; set; }
        [Ignore]
        public Library IdentifierLibrary { get; set; }

        [Ignore]
        public ShapeWarp ShapeWarp
        {
            get => this.shapeWarp;
            set
            {
                this.shapeWarp = value;
                this.Warps.Clear();
                Warp newWarp = Warp.FromShape(this.shapeWarp);
                if (newWarp != null)
                {
                    this.Warps.Add(newWarp);
                    this.ShapeWarpDirection = this.ShapeWarpDirection;
                }
            }
        }

        [Ignore]
        public Axis ShapeWarpDirection
        {
            get => this.shapeWarpDirection;
            set
            {
                this.shapeWarpDirection = value;
                if (this.Warps.Count == 1)
                {
                    switch (this.Warps[0])
                    {
                        case Warp.Spherical s:
                            s.Orientation = value;
                            break;
                        case Warp.Cylindrical c:
                            c.Orientation = value;
                            break;
                        case Warp.Toroidal t:
                            t.Orientation = value;
                            break;
                        case Warp.Planar p:
                            p.Normal = value;
                            break;
                    }
                }
            }
        }

        [Output(Order = int.MaxValue)]        
        public Collection<Warp> Warps { get; } = new Collection<Warp>();
    }
   
    [BlockElement(Keyword.Pigment)]
    public class Pigment : PigmentOrNormal
    {
        [ValueElement(Keyword.QuickColor)]
        public Color? QuickColor { get; set; }

        public static implicit operator Pigment(Color color)
        {
            return new Solid(color);
        }
        public static implicit operator Pigment((Float r, Float g, Float b) rgb)
        {
            return (Color)(rgb.r, rgb.g, rgb.b);
        }

        public static Solid FromColor(Color color)
        {
            return new Solid(color);
        }
        
        public class Solid : Pigment
        {
            [ValueElement(Keyword.Color)]
            public Color Color { get; set; }

            public Solid(Color color)
            {
                this.Color = color;
            }
        }
        
        [Output]
        public BlendMap Map { get; set; } 
        
        public static implicit operator Pigment(Pattern pattern)
        {
            if (pattern.AllowPigment)
            {
                return new Patterned(pattern);
            }
            else
            {
                throw new InvalidCastException("That pattern can't be casted to a pigment.");
            }
        }

        public class Patterned : Pigment
        {
            [Output]
            public Pattern Pattern { get; set; }
            
            public Patterned(Pattern pattern = null)
            {
                this.Pattern = pattern;
            }
        }

#if PIGMENT
        public class Image : Pigment, IFileMap
        {
            [Output]
            protected ImageMap ImageMap { get; set; }

            public Image() : this(new PovImage())
            {
            }

            public Image(string path) : this(new FileImage(path))
            {
            }
            
            public Image(Scene scene) : this(new SceneImage(scene))
            {
            }
            
            public Image(PovImage image)
            {
                this.ImageMap = new ImageMap
                {
                    MapImage = image 
                };
            }

            public PovImage MapImage
            {
                get => this.ImageMap.MapImage;
                set => this.ImageMap.MapImage = value;
            }

            public bool Once
            {
                get => this.ImageMap.Once;
                set => this.ImageMap.Once = value;
            }
            
            public MapType MapType
            {
                get => this.ImageMap.MapType;
                set => this.ImageMap.MapType = value;
            }

            public Interpolation Interpolate
            {
                get => this.ImageMap.Interpolate;
                set => this.ImageMap.Interpolate = value;
            }

            public Float Gamma
            {
                get => this.ImageMap.Gamma;
                set => this.ImageMap.Gamma = value;
            }
        }
#endif
    }
}