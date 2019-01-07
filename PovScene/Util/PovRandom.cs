namespace PovScene.Util
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Reflection;
    using SceneDescription;
    using SceneDescription.Items;
    using SceneDescription.Values;

    /// <summary>
    /// A wrapper of the <see cref="Random"/> class.
    /// </summary>
    public class PovRandom
    {
        public static PovRandom Global => new PovRandom();

        private Random rand;
        
        public int Seed { get; private set; }

        public PovRandom(int? seed = null)
        {
            this.Seed = seed ?? new Random().Next();
            this.Reset();
        }
        
        public void Reset()
        {
            this.rand = new Random(this.Seed);
        }

        /// <returns>A random Float between 0 and 1.</returns>
        public Float Float()
        {
            return this.rand.NextDouble();
        }

        /// <returns>A random Float between -1 and 1.</returns>
        public Float FloatSigned()
        {
            return this.Bool() ? this.rand.NextDouble() : -this.rand.NextDouble();
        }

        /// <returns>A random Vector with values between 0 and 1.</returns>
        public Vector Vector()
        {
            return new Vector(this.Float(), this.Float(), this.Float());
        }

        /// <returns>A random Vector with values between -1 and 1.</returns>
        public Vector VectorSigned()
        {
            return new Vector(this.FloatSigned(), this.FloatSigned(), this.FloatSigned());
        }

        /// <returns>A random Color.</returns>
        public Color Color()
        {
            return this.Vector();
        }

        /// <returns>A random int.</returns>        
        public int Int()
        {
            return this.rand.Next();
        }

        /// <returns>A random int, between min (inclusive) and max (exclusive).</returns>        
        public int Int(int min, int max)
        {
            return this.rand.Next(min, max);
        }

        /// <returns>A random int, between 0 (inclusive) and max (exclusive).</returns>        
        public int Int(int max)
        {
            return this.Int(0, max);
        }

        /// <returns>A random int, between int.MinValue and int.MaxValue.</returns>        
        public int SignedInt()
        {
            return this.Bool() ? this.Int() : -this.Int();
        }

        /// <returns>A random boolean.</returns>        
        public bool Bool()
        {
            return (this.Int() & 1) == 0;
        }

        public T SceneItem<T>()
            where T : SceneElement, new()
        {
            T item = new T();

            foreach (PropertyInfo property in item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy))
            {
                if (property.CanWrite && property.GetIndexParameters().Length == 0)
                {
                    Type type = property.PropertyType;
                    object value = null;

                    if (type == typeof(Float))
                    {
                        value = this.Float();
                    }
                    else if (type == typeof(int) || type == typeof(int?))
                    {
                        value = this.Int();
                    }
                    else if (type == typeof(Vector))
                    {
                        value = this.Vector();
                    }
                    else if (type == typeof(Color))
                    {
                        value = this.Color();
                    }

                    if (value != null)
                    {
                        property.SetValue(item, value);
                    }
                }
            }

            return item;
        }
    }
}