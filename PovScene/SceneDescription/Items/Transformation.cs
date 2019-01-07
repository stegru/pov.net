namespace PovScene.SceneDescription.Items
{
    using System.Collections.Generic;
    using Output;
    using Values;

    /// <summary>
    /// A list of transformations.
    /// </summary>
    public class Transformations : List<Transformation>, ITransformable
    {
        public ITransformable Transform(Transformation transformation)
        {
            this.Add(transformation);
            return this;
        }
    }
    
    /// <summary>A transformation.</summary>
    public abstract class Transformation : ItemModifier
    {
        [ObjectParameter(Float = true)]
        public Vector Value { get; set; }
        public Transformation(Vector value)
        {
            this.Value = value;
        }
    }
    
    [ValueElement(Keyword.Rotate, Order = -1)]
    public class Rotate : Transformation
    {
        public Rotate(Vector value) : base(value)
        {
        }
    }
    [ValueElement(Keyword.Scale, Order = -1)]
    public class Scale : Transformation
    {
        public Scale(Vector value) : base(value)
        {
        }
    }
    [ValueElement(Keyword.Translate, Order = -1)]
    public class Translate : Transformation
    {
        public Translate(Vector value) : base(value)
        {
        }
    }
    
    /// <summary>
    /// Extension methods for transformable objects.
    /// </summary>
    public static class TransformationMethods
    {
        public static T Rotate<T>(this T item, Vector value) where T : ITransformable
        {
            return (T)item.Transform(new Rotate(value));
        }

        public static T Rotate<T>(this T item, Float x, Float y = default(Float), Float z = default(Float)) where T : ITransformable
        {
            return item.Rotate(new Vector(x, y, z));
        }

        public static T RotateX<T>(this T item, Float x) where T : ITransformable
        {
            return item.Rotate(x, 0, 0);
        }

        public static T RotateY<T>(this T item, Float y) where T : ITransformable
        {
            return item.Rotate(0, y, 0);
        }

        public static T RotateZ<T>(this T item, Float z) where T : ITransformable
        {
            return item.Rotate(0, 0, z);
        }

        public static T Scale<T>(this T item, Vector value) where T : ITransformable
        {
            return (T)item.Transform(new Scale(value));
        }

        public static T Scale<T>(this T item, Float x, Float y, Float z) where T : ITransformable
        {
            return item.Scale(new Vector(x, y, z));
        }

        public static T ScaleX<T>(this T item, Float x) where T : ITransformable
        {
            return item.Scale(x, 1, 1);
        }

        public static T ScaleY<T>(this T item, Float y) where T : ITransformable
        {
            return item.Scale(1, y, 1);
        }

        public static T ScaleZ<T>(this T item, Float z) where T : ITransformable
        {
            return item.Scale(1, 1, z);
        }

        public static T Scale<T>(this T item, Float amount) where T : ITransformable
        {
            return item.Scale(new Vector(amount));
        }

        public static T Translate<T>(this T item, Vector value) where T : ITransformable
        {
            return (T)item.Transform(new Translate(value));
        }

        public static T Translate<T>(this T item, Float x, Float y = default(Float), Float z = default(Float)) where T : ITransformable
        {
            return item.Translate(new Vector(x, y, z));
        }
        
        public static T TranslateX<T>(this T item, Float x) where T : ITransformable
        {
            return item.Translate(x, 0, 0);
        }

        public static T TranslateY<T>(this T item, Float y) where T : ITransformable
        {
            return item.Translate(0, y, 0);
        }

        public static T TranslateZ<T>(this T item, Float z) where T : ITransformable
        {
            return item.Translate(0, 0, z);
        }


    }

    public interface ITransformable
    {
        ITransformable Transform(Transformation transformation);
    }

    
}