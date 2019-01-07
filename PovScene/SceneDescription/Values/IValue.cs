namespace PovScene.SceneDescription.Values
{
    using Output;

    /// <summary>
    /// Something which may have a value.
    /// </summary>
    public interface IValue
    {
        /// <summary>true if this object has a value.</summary>
        [Ignore]
        bool HasValue { get; }
    }
}