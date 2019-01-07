namespace PovScene.SceneDescription.Values
{
    using System;
    using System.Globalization;

    //public class Float : SceneElement, IComparable<Float>
    public struct Float : IValue, IComparable<Float>
    {
        public double Value { get; }
        public bool HasValue { get; }
        public bool IsIdentifier => this.Identifier != null;
        public string Identifier { get; }

        public static Float Zero;

        public Float(string identifier) : this(0)
        {
            this.Identifier = identifier;
            this.HasValue = true;
        }

        public Float(double value)
        {
            this.HasValue = true;
            this.Value = value;
            this.Identifier = null;
        }
        
        public override string ToString()
        {            
            return this.IsIdentifier ? this.Identifier : this.Value.ToString(CultureInfo.InvariantCulture);
        }

        public bool Equals(Float other)
        {
            return this.Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Float f && this.Equals(f);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static bool operator ==(Float left, Float right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Float left, Float right)
        {
            return !left.Equals(right);
        }

        public int CompareTo(Float other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public static bool operator <(Float left, Float right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Float left, Float right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Float left, Float right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Float left, Float right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static implicit operator double(Float f)
        {
            return f.Value;
        }

        public static implicit operator Float(double d)
        {
            return new Float(d);
        }
        
        public static implicit operator Float(string identifier)
        {
            return new Float(identifier);
        }
        
        public static Float operator +(Float left, Float right)
        {
            return left.HasValue && right.HasValue
                ? (Float) (left.Value + right.Value)
                : default(Float);
        }

        public static Float operator -(Float left, Float right)
        {
            return left.HasValue && right.HasValue
                ? (Float) (left.Value - right.Value)
                : default(Float);
        }

        public static Float operator *(Float left, Float right)
        {
            return left.HasValue && right.HasValue
                ? (Float) (left.Value * right.Value)
                : default(Float);
        }

        public static Float operator /(Float left, Float right)
        {
            return left.HasValue && right.HasValue
                ? (Float) (left.Value / right.Value)
                : default(Float);
        }

        public static Float operator -(Float f)
        {
            return f.HasValue
                ? new Float(-f.Value)
                : default(Float);
        }
    }
}