namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using System;
    using System.Runtime.CompilerServices;
    using Output;
    using Values;

    public enum ShapeWarp
    {
        Default = 0,
        Cubic,
        Cylinder,
        Plane,
        Sphere,
        Torus
    }

    [BlockElement(Keyword.Warp)]
    public abstract class Warp : SceneElement
    {
        protected abstract Keyword WarpTypeKeyword { get; }

        public static Type TypeFromShape(ShapeWarp shape)
        {
            switch (shape)
            {
                case ShapeWarp.Cubic:
                    return typeof(Cubic);
                case ShapeWarp.Cylinder:
                    return typeof(Cylindrical);
                case ShapeWarp.Plane:
                    return typeof(Planar);
                case ShapeWarp.Sphere:
                    return typeof(Spherical);
                case ShapeWarp.Torus:
                    return typeof(Toroidal);
                case ShapeWarp.Default:
                    return null;
                default:
                    return null;
            }
        }

        public static Warp FromShape(ShapeWarp shape)
        {
            Type type = TypeFromShape(shape);
            if (type == null)
            {
                return null;
            }
            else
            {
                return Activator.CreateInstance(type) as Warp;
            }
        }

        public class Repeat : Warp
        {
            [ValueElement(Order = int.MinValue)]
            protected override Keyword WarpTypeKeyword { get; } = Keyword.Repeat;

            [ValueElement]
            public Vector Direction { get; set; }

        }

        public class BlackHole : Warp
        {
            [ValueElement(Order = int.MinValue)]
            protected override Keyword WarpTypeKeyword { get; } = Keyword.BlackHole;
            
            [ValueElement(Order = int.MinValue)]
            [GroupNext]
            public Vector Location { get; set; }

            [ValueElement(Order = int.MinValue)]
            public Float Radius { get; set; }

            [ValueElement(Keyword.Strength)]
            public Float Strength { get; set; }

            [ValueElement(Keyword.Falloff)]
            public int? Falloff { get; set; }

            [FlagElement(Keyword.Inverse)]
            public bool Inverse { get; set; }

            [ValueElement(Keyword.Repeat)]
            public Vector RepeatDirection { get; set; }

            [ValueElement(Keyword.Turbulence, Float = true)]
            public Float TurbulenceAmount { get; set; }

            [ValueElement(Keyword.Type)]
            public Float Type { get; set; }
        }

        public class Turbulence : Warp
        {
            [ValueElement(Order = int.MinValue)]
            protected override Keyword WarpTypeKeyword { get; } = Keyword.Turbulence;

            [ValueElement(Keyword.Turbulence, Float = true)]
            public Vector TurbulenceAmount { get; set; }

            [ValueElement(Keyword.Octaves)]
            public int? Octaves { get; set; }

            [ValueElement(Keyword.Omega)]
            public Float Omega { get; set; }

            [ValueElement(Keyword.Lambda)]
            public Float Lambda { get; set; }
        }

        public class Planar : Warp
        {
            [ValueElement(Order = int.MinValue)]
            protected override Keyword WarpTypeKeyword { get; } = Keyword.Planar;

            [ValueElement(GroupNext = true)]
            public Vector Normal { get; set; }
            [ValueElement(ContentStart = ",")]
            public Float Distance { get; set; }
        }

        public class Cubic : Warp
        {
            [ValueElement(Order = int.MinValue)]
            protected override Keyword WarpTypeKeyword { get; } = Keyword.Planar;
        }

        public class Cylindrical : Warp
        {
            [ValueElement(Order = int.MinValue)]
            protected override Keyword WarpTypeKeyword { get; } = Keyword.Cylindrical;

            [ValueElement(Keyword.Orientation)]
            public Vector Orientation { get; set; }

            [ValueElement(Keyword.DistExp)]
            public Float DistanceExponent { get; set; }

            public Cylindrical()
            {
            }

            public Cylindrical(Axis orientation, Float distanceExponent = default(Float))
                : this((Vector) orientation, distanceExponent)
            {
            }

            public Cylindrical(Vector orientation = default(Vector), Float distanceExponent = default(Float))
            {
                this.Orientation = orientation;
                this.DistanceExponent = distanceExponent;
            }
        }

        public class Spherical : Warp
        {
            [ValueElement(Order = int.MinValue)]
            protected override Keyword WarpTypeKeyword { get; } = Keyword.Spherical;

            [ValueElement(Keyword.Orientation)]
            public Vector Orientation { get; set; }

            [ValueElement(Keyword.DistExp)]
            public Float DistanceExponent { get; set; }

            public Spherical()
            {
            }

            public Spherical(Axis orientation, Float distanceExponent = default(Float))
                : this((Vector) orientation, distanceExponent)
            {
            }

            public Spherical(Vector orientation = default(Vector), Float distanceExponent = default(Float))
            {
                this.Orientation = orientation;
                this.DistanceExponent = distanceExponent;
            }
        }

        public class Toroidal : Warp
        {
            [ValueElement(Order = int.MinValue)]
            protected override Keyword WarpTypeKeyword { get; } = Keyword.Toroidal;

            [ValueElement(Keyword.Orientation)]
            public Vector Orientation { get; set; }

            [ValueElement(Keyword.DistExp)]
            public Float DistanceExponent { get; set; }

            public Toroidal()
            {
            }

            public Toroidal(Axis orientation, Float distanceExponent = default(Float))
                : this((Vector) orientation, distanceExponent)
            {
            }

            public Toroidal(Vector orientation = default(Vector), Float distanceExponent = default(Float))
            {
                this.Orientation = orientation;
                this.DistanceExponent = distanceExponent;
            }
        }
    }
}

