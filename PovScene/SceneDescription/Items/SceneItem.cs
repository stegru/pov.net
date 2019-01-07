namespace PovScene.SceneDescription.Items
{
    using System;
    using System.Collections.ObjectModel;
    using Output;
    using Values;

    public abstract class SceneItem : SceneElement, ITransformable
    {
        [Output(Order = 10000)]
        public Collection<ItemModifier> Modifiers { get; } = new Collection<ItemModifier>();

        public ITransformable Transform(Transformation transformation)
        {
            this.Modifiers.Add(transformation);
            return this;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class InitAttribute : Attribute
    {
    }

    public abstract class ItemModifier : SceneElement
    {
    }

    public class SceneItemWrapper<T> : SceneItem
        where T : IValue
    {
        [Output]
        public T SceneItem { get; set; }

        public SceneItemWrapper(T sceneItem)
        {
            this.SceneItem = sceneItem;
        }
    }
}