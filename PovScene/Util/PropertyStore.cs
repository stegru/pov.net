namespace PovScene.Util
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a way of storing values of class properties in a dictionary, without needing to specify the property
    /// name in a string.
    /// </summary>
    /// <remarks>Used by the OutputAttribute class to store its properties.</remarks>
    public class PropertyStore
    {
        private readonly Dictionary<string, object> store = new Dictionary<string, object>();

        /// <summary>
        /// Set the value of a property.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The property name - no need to supply this parameter; this is performed by the compiler.</param>
        /// <typeparam name="T">The value type.</typeparam>
        /// <returns>The value.</returns>
        public T Set<T>(T value, [CallerMemberName] string name = null)
        {
            if (name != null)
            {
                this.store[name] = value;
            }

            return value;
        }

        /// <summary>
        /// Gets a property value.
        /// </summary>
        /// <param name="name">The property name - no need to supply this parameter; this is performed by the compiler.</param>
        /// <typeparam name="T">The value type.</typeparam>
        /// <returns>The value.</returns>
        public T Get<T>([CallerMemberName] string name = null)
        {
            if (name != null && this.store.TryGetValue(name, out object value))
            {
                return (T) value;
            }

            return default(T);
        }

        /// <summary>
        /// Returns a value indicating if this instance has a value for the given property name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns></returns>
        public bool HasValue(string name)
        {
            return this.store.ContainsKey(name);
        }

        /// <summary>
        /// Merge another instance of this class onto this one. Properties on the other instance will override this one.
        /// </summary>
        /// <param name="otherStore">The other instance.</param>
        public void Merge(PropertyStore otherStore)
        {
            foreach (KeyValuePair<string,object> pair in otherStore.store)
            {
                this.store[pair.Key] = pair.Value;
            }
        }
    }
}
