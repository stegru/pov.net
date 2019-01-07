namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using Output;
    using Values;

    public enum Patterns
    {
        Agate = Keyword.Agate,
        Boxed = Keyword.Boxed,
        Bozo = Keyword.Bozo,
        Bumps = Keyword.Bumps,
        Cubic = Keyword.Cubic,
        Cylindrical = Keyword.Cylindrical,
        Dents = Keyword.Dents,
        MandelFractal = Keyword.Mandel,
        JuliaFractal = Keyword.Julia,
        MagnetFractal = Keyword.Magnet,
        Function = Keyword.Function,
        Gradient = Keyword.Gradient,
        Granite = Keyword.Granite,
        Leopard = Keyword.Leopard,
        Marble = Keyword.Marble,
        Onion = Keyword.Onion,
        Planar = Keyword.Planar,
        Potential = Keyword.Potential,
        Quilted = Keyword.Quilted,
        Radial = Keyword.Radial,
        Ripples = Keyword.Ripples,
        Spherical = Keyword.Spherical,
        Spiral1 = Keyword.Spiral1,
        Spiral2 = Keyword.Spiral2,
        Spotted = Keyword.Spotted,
        Waves = Keyword.Waves,
        Wood = Keyword.Wood,
        Wrinkles = Keyword.Wrinkles
    }
    
    // ReSharper disable SuggestBaseTypeForParameter

    /// <summary>
    /// Pigment and Normal patterns
    /// </summary>
    public abstract class Pattern : SceneItem
    {
        public bool AllowPigment { get; protected set; } = true;
        public bool AllowNormal { get; protected set; } = true;
        
        [Output(Order = int.MaxValue)]
        public BlendMap Map { get; set; }
        
        [ValueElement(Keyword.NoiseGenerator)]
        public int? NoiseGenerator { get; set; }
        
        [ValueElement(Keyword.Turbulence, Float = true)]
        public Vector Turbulence { get; set; }

        [ValueElement(Keyword.Octaves)]
        public int? Octaves { get; set; }
        
        [ValueElement(Keyword.Omega)]
        public Float Omega { get; set; }
        
        [ValueElement(Keyword.Lambda)]
        public Float Lambda { get; set; }

        public Pattern()
        {
        }

        [Output(Keyword.Gradient)]
        public class Gradient : Pattern
        {
            [ObjectParameter(Order = 0, Direction = true)]
            public Vector Orientation { get; set; }

            public Gradient(Vector orientation = default(Vector))
            {
                this.Orientation = orientation.HasValue ? orientation : Vector.X;
            }
        }

        [Output(Keyword.Tiling)]
        public class Tiling : Pattern
        {
            [ValueElement]
            public int TilePattern { get; set; }

            public Tiling(int tilePattern)
            {
                this.TilePattern = tilePattern;
            }
        }

        /// <summary>A pattern that has a float value.</summary>
        public abstract class ValuedPattern : Pattern
        {
            [ValueElement]
            public Float Value { get; set; }

            protected ValuedPattern(Float value)
            {
                this.Value = value;
            }
        }


        // General Patterns
        
        [Output(Keyword.Agate)]
        public class Agate : ValuedPattern
        {
            [ValueElement(Keyword.AgateTurb)]
            public Float AgateTurb { get; set; }

            public Agate(Float agateTurb = default(Float), Float bumpSize = default(Float))
                : base(bumpSize)
            {
                this.AgateTurb = agateTurb;
            }
        }
               
        [Output(Keyword.Bumps)]
        public class Bumps : ValuedPattern
        {
            public Bumps(Float value) : base(value)
            {
            }
        }

        [Output(Keyword.Ripples)]
        public class Ripples : Pattern
        {
            [ValueElement(Keyword.Frequency)]
            public Float Frequency { get; set; }

            [ValueElement(Keyword.Phase)]
            public Float Phase { get; set; }

            public Ripples(Float frequency, Float phase)
            {
                this.Frequency = frequency;
                this.Phase = phase;
            }
        }

        [Output(Keyword.Pavement)]
        public class Pavement : Pattern
        {
            [ValueElement(Keyword.NumberOfSides)]
            public int? NumberOfSides { get; set; }
            
            [ValueElement(Keyword.NumberOfTiles)]
            public int? NumberOfTiles { get; set; }
            
            [ValueElement(Keyword.Pattern)]
            public int? Pattern { get; set; }
            
            [ValueElement(Keyword.Exterior)]
            public int? Exterior { get; set; }
            
            [ValueElement(Keyword.Interior)]
            public int? Interior { get; set; }
            
            [ValueElement(Keyword.Form)]
            public int? Form { get; set; }
            
        }

        public abstract class Spiral : Pattern
        {
            [ValueElement(IsParameter = true)]
            [GroupNext]
            public int NumberOfArms { get; set; }
            
            [ValueElement]
            public Float BumpSize { get; set; }
            
            protected Spiral(int numberOfArms, Float bumpSize = default(Float))
            {
                this.NumberOfArms = numberOfArms;
                this.BumpSize = bumpSize;
            }            
        }
        
        [Output(Keyword.Spiral1)]
        public class Spiral1 : Spiral{
            public Spiral1(int numberOfArms, Float bumpSize = default(Float)) : base(numberOfArms, bumpSize)
            {
            }
        }
        
        [Output(Keyword.Spiral2)]
        public class Spiral2 : Spiral{
            public Spiral2(int numberOfArms, Float bumpSize = default(Float)) : base(numberOfArms, bumpSize)
            {
            }
        }

        // General Patterns (no parameters)
        [Output(Keyword.Boxed)] public class Boxed : Pattern{}
        [Output(Keyword.Bozo)] public class Bozo : Pattern{}
        [Output(Keyword.Cells)] public class Cells : Pattern{}
        [Output(Keyword.Cylindrical)] public class Cylindrical : Pattern{}
        [Output(Keyword.Dents)] public class Dents : Pattern{}
        [Output(Keyword.Function)] public class FunctionPattern : Pattern{}
        [Output(Keyword.Granite)] public class Granite : Pattern{}
        [Output(Keyword.Julia)] public class Julia : Pattern{}
        [Output(Keyword.Leopard)] public class Leopard : Pattern{}
        [Output(Keyword.Magnet)] public class Magnet : Pattern{}
        [Output(Keyword.Mandel)] public class Mandel : Pattern{}
        [Output(Keyword.Marble)] public class Marble : Pattern{}
        [Output(Keyword.Onion)] public class Onion : Pattern{}
        [Output(Keyword.Planar)] public class Planar : Pattern{}
        [Output(Keyword.Potential, PovVersion = 3.8)] public class Potential : Pattern{}
        [Output(Keyword.Quilted)] public class Quilted : Pattern{}
        [Output(Keyword.Radial)] public class Radial : Pattern{}
        [Output(Keyword.Spherical)] public class Spherical : Pattern{}
        [Output(Keyword.Spotted)] public class Spotted : Pattern{}
        [Output(Keyword.Waves)] public class Waves : Pattern{}
        [Output(Keyword.Wood)] public class Wood : Pattern{}
        [Output(Keyword.Wrinkles)] public class Wrinkles : Pattern{}

        // Normal only
        [Output(Keyword.Facets)]
        public class Facets : Pattern
        {
            public Facets()
            {
                this.AllowPigment = false;
            }
        }
        
        

        // Block Patterns
        public abstract class BlockPattern : Pattern
        {
        }
        
        [Output(Keyword.Brick)]
        public class Brick : BlockPattern
        {
            [ObjectParameter] public PigmentOrNormal Mortar { get; set; }
            [ObjectParameter] public PigmentOrNormal Bricks { get; set; }
            
            [ValueElement(Keyword.BrickSize)]
            public Vector BrickSize { get; set; }

            [ValueElement(Keyword.Mortar)]
            public Float MortarSize { get; set; }

            public Brick()
            {
            }

            public Brick(Pigment mortar, Pigment bricks)
            {
                this.AllowNormal = false;
                this.Mortar = mortar;
                this.Bricks = bricks;
            }
            
            public Brick(Normal mortar, Normal bricks)
            {
                this.AllowPigment = false;
                this.Mortar = mortar;
                this.Bricks = bricks;
            }
        }


        [Output(Keyword.Checker)]
        public class Checker : BlockPattern
        {
            [ObjectParameter] public PigmentOrNormal Check1 { get; set; }
            [ObjectParameter] public PigmentOrNormal Check2 { get; set; }

            public Checker()
            {
            }

            public Checker(Pigment check1, Pigment check2)
            {
                this.AllowNormal = false;
                this.Check1 = check1;
                this.Check2 = check2;
            }

            public Checker(Normal check1, Normal check2)
            {
                this.AllowPigment = false;
                this.Check1 = check1;
                this.Check2 = check2;
            }
        }

        [Output(Keyword.Hexagon)]
        public class Hexagon : BlockPattern
        {
            [ObjectParameter] public PigmentOrNormal Hexagon1 { get; set; }
            [ObjectParameter] public PigmentOrNormal Hexagon2 { get; set; }
            [ObjectParameter] public PigmentOrNormal Hexagon3 { get; set; }

            public Hexagon()
            {
            }

            public Hexagon(Pigment hexagon1, Pigment hexagon2, Pigment hexagon3)
            {
                this.AllowNormal = false;
                this.Hexagon1 = hexagon1;
                this.Hexagon2 = hexagon2;
                this.Hexagon3 = hexagon3;
            }

            public Hexagon(Normal hexagon1, Normal hexagon2, Normal hexagon3)
            {
                this.AllowPigment = false;
                this.Hexagon1 = hexagon1;
                this.Hexagon2 = hexagon2;
                this.Hexagon3 = hexagon3;
            }
        }
        
        [Output(Keyword.Cubic)]
        public class Cubic : BlockPattern
        {
            [ObjectParameter] public PigmentOrNormal XFront { get; set; }
            [ObjectParameter] public PigmentOrNormal YFront { get; set; }
            [ObjectParameter] public PigmentOrNormal ZFront { get; set; }
            [ObjectParameter] public PigmentOrNormal XBack { get; set; }
            [ObjectParameter] public PigmentOrNormal YBack { get; set; }
            [ObjectParameter] public PigmentOrNormal ZBack { get; set; }

            public Cubic(Pigment xFront, Pigment yFront, Pigment zFront, Pigment xBack,
                Pigment yBack, Pigment zBack)
            {
                this.AllowNormal = false;
                this.XFront = xFront;
                this.YFront = yFront;
                this.ZFront = zFront;
                this.XBack = xBack;
                this.YBack = yBack;
                this.ZBack = zBack;
            }
            
            public Cubic(Normal xFront, Normal yFront, Normal zFront, Normal xBack,
                Normal yBack, Normal zBack)
            {
                this.AllowPigment = false;
                this.XFront = xFront;
                this.YFront = yFront;
                this.ZFront = zFront;
                this.XBack = xBack;
                this.YBack = yBack;
                this.ZBack = zBack;
            }
        }
        
        [Output(Keyword.Square)]
        public class Square : BlockPattern
        {
            [ObjectParameter] public PigmentOrNormal Item1 { get; set; }
            [ObjectParameter] public PigmentOrNormal Item2 { get; set; }
            [ObjectParameter] public PigmentOrNormal Item3 { get; set; }
            [ObjectParameter] public PigmentOrNormal Item4 { get; set; }

            public Square(Pigment item1, Pigment item2, Pigment item3, Pigment item4)
            {
                this.AllowNormal = false;
                this.Item1 = item1;
                this.Item2 = item2;
                this.Item3 = item3;
                this.Item4 = item4;
            }

            public Square(Normal item1, Normal item2, Normal item3, Normal item4)
            {
                this.AllowPigment = false;
                this.Item1 = item1;
                this.Item2 = item2;
                this.Item3 = item3;
                this.Item4 = item4;
            }
        }
    }
    
}