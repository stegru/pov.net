namespace PovScene.SceneDescription.Values
{
    using System;

    public enum Axis
    {
        X = 1,
        Y = 2,
        Z = 3,
        XNegative = -X,
        YNegative = -Y,
        ZNegative = -Z
    }

    public struct Vector : IValue
    {
        
        public static Vector X => new Vector("x", 1, 0, 0);
        public static Vector Y => new Vector("y", 0, 1, 0);
        public static Vector Z => new Vector("z", 0, 0, 1);
        public static Vector Zero => new Vector(0, 0, 0);

        private string constant;
        private Float _x;
        private Float _y;
        private Float _z;

        public bool HasValue { get; private set; }

        private Vector(string constant, Float x, Float y, Float z = default(Float))
        {
            this.constant = constant;
            this.HasValue = true;
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public Vector(Float x, Float y, Float z = default(Float))
        {
            this.constant = null;
            this.HasValue = true;
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public Vector(Float xyz) : this(xyz, xyz, xyz)
        {
        }

        public Float x
        {
            get => this._x;
            set
            {
                this.Changed();
                this._x = value;
            }
        }

        public Float y
        {
            get => this._y;
            set
            {
                this.Changed();
                this._y = value;
            }
        }

        public Float z
        {
            get => this._z;
            set
            {
                this.Changed();
                this._z = value;
            }
        }

        private void Changed()
        {
            this.constant = null;
            this.HasValue = true;
        }
        
        public string ToString(bool? useConstant)
        {
            if (useConstant == true)
            {
                if (this == X)
                {
                    return X.ToString();
                }
                if (this == Y)
                {
                    return Y.ToString();
                }
                if (this == Z)
                {
                    return Z.ToString();
                }
                if (this == 0 - X)
                {
                    return "-" + X.ToString();
                }
                if (this == 0 - Y)
                {
                    return "-" + Y.ToString();
                }
                if (this == 0 - Z)
                {
                    return "-" + Z.ToString();
                }
            }
            
            if (useConstant == null && this.constant != null)
            {
                return this.constant;
            }

            return string.Format("<{0}, {1}, {2}>", this._x, this._y, this._z);
        }

        public override string ToString()
        {
            return this.ToString(null);
        }

        public bool Equals(Vector other)
        {
            return this._x.Equals(other._x) && this._y.Equals(other._y) && this._z.Equals(other._z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Vector && Equals((Vector) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this._x.GetHashCode();
                hashCode = (hashCode * 397) ^ this._y.GetHashCode();
                hashCode = (hashCode * 397) ^ this._z.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !left.Equals(right);
        }

        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left._x + right._x, left._y + right._y, left._z + right._z );
        }

        public static Vector operator -(Vector left, Vector right)
        {
            return new Vector(left._x - right._x, left._y - right._y, left._z - right._z );
        }

        public static Vector operator *(Vector left, Float right)
        {
            return new Vector(left._x * right, left._y * right, left._z * right);
        }
        
        public static Vector operator *(Vector left, Vector right)
        {
            return new Vector(left._x * right._x, left._y * right._y, left._z * right._z );
        }

        public static Vector operator /(Vector left, Vector right)
        {
            return new Vector(left._x / right._x, left._y / right._y, left._z / right._z );
        }

        public static Vector operator -(Vector vector)
        {
            if (!string.IsNullOrEmpty(vector.constant))
            {
                bool neg = vector.constant[0] == '-';
                string id = neg ? vector.constant.Substring(1) : vector.constant;
                if (id == "x" || id == "y" || id == "z")
                {
                    if (!neg)
                    {
                        id = "-" + id;
                    }
                    return new Vector(id, -vector._x, -vector._y, -vector._z);
                }
            }
            
            return new Vector(-vector._x, -vector._y, -vector._z);
        }

        public static implicit operator (Float, Float, Float)(Vector v)
        {
            return (v.x, v.y, v.z);
        }
        public static implicit operator Vector((Float x, Float y, Float z) xyz)
        {
            return new Vector(xyz.x, xyz.y, xyz.z);
        }

        public static implicit operator Vector(Float xyz)
        {
            return new Vector(xyz, xyz, xyz);
        }
        
        public static implicit operator Vector(double xyz)
        {
            return new Vector(xyz);
        }

        public static implicit operator Vector(Axis axis)
        {
            Vector v;
            switch ((Axis)Math.Abs((int) axis))
            {
                case Axis.X:
                    v = Vector.X;
                    break;
                case Axis.Y:
                    v = Vector.Y;
                    break;
                case Axis.Z:
                    v = Vector.Z;
                    break;
                case 0:
                    v = new Vector();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
            }

            return axis > 0 ? v : -v;
        }
    }

    public struct Vector2D : IValue
    {
        private Float _u;
        private Float _v;

        public Float u
        {
            get => this._u;
            set
            {
                this.HasValue = true;
                this._u = value;
            }
        }

        public Float v
        {
            get => this._v;
            set
            {
                this.HasValue = true;
                this._v = value;
            }
        }


        public bool HasValue { get; private set; }

        public Vector2D(Float u, Float v)
        {
            this.HasValue = true;
            this._u = u;
            this._v = v;
        }

        public Vector2D(Float uv = default(Float)) : this(uv, uv)
        {
        }

        public override string ToString()
        {
            return $"<{this.u}, {this.v}>";
        }

        public bool Equals(Vector2D other)
        {
            return this.u.Equals(other.u) && this.v.Equals(other.v);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Vector2D && Equals((Vector2D) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.u.GetHashCode() * 397) ^ this.v.GetHashCode();
            }
        }

        public static bool operator ==(Vector2D left, Vector2D right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector2D left, Vector2D right)
        {
            return !left.Equals(right);
        }

    }

}