namespace PovScene.SceneDescription.Output
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Util;
    using Values;

    /// <summary>
    /// Contains extension methods related to OutputAttributes
    /// </summary>
    public static class OutputAttributeExtension
    {
        /// <summary>
        /// Gets all attributes of a property or type, in order of inheritance.
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetAllAttributes<T>(this MemberInfo memberInfo)
            where T : Attribute
        {
            List<T> attrs = new List<T>();
            attrs.AddRange(memberInfo.GetCustomAttributesFast<T>().Reverse());
            
            switch (memberInfo)
            {
                case PropertyInfo pi:
                    attrs.AddRange(pi.PropertyType.GetAllAttributes<T>());
                    break;
                case Type type when type.BaseType != null:
                    attrs.AddRange(type.BaseType.GetAllAttributes<T>());
                    break;
            }

            return attrs;
        }

        /// <summary>
        /// Gets all attributes of a given type from the object.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetAllAttributes<T>(this object obj)
            where T : Attribute
        {
            return obj.GetType().GetAllAttributes<T>();
        }

        /// <summary>
        /// Returns a number indicating how far a type is inherited.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static int GetPropertyInheritanceDepth(this PropertyInfo propertyInfo)
        {
            int depth = 0;
            Type type = propertyInfo.ReflectedType;
            while (type != propertyInfo.DeclaringType && type != null)
            {
                type = type.DeclaringType;
                depth++;
            }

            return depth;
        }

        private static readonly IDictionary<(Type,MemberInfo), object> CustomAttributesCache =
            new Dictionary<(Type, MemberInfo), object>();
        
        /// <summary>
        /// A cached wrapper of GetCustomAttributes.
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetCustomAttributesFast<T>(this MemberInfo memberInfo) 
            where T : Attribute
        {
            lock (CustomAttributesCache)
            {
                var key = (typeof(T), memberInfo);
                if (CustomAttributesCache.TryGetValue(key, out object value))
                {
                    return (T[]) value;
                }

                T[] result = memberInfo.GetCustomAttributes<T>().ToArray();
                CustomAttributesCache.Add(key, result);
                return result;
            }
        }

        private static readonly IDictionary<(Type,MemberInfo), object> CustomAttributeCache =
            new Dictionary<(Type, MemberInfo), object>();
        
        /// <summary>
        /// A cached wrapper of GetCustomAttribute
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetCustomAttributeFast<T>(this MemberInfo memberInfo) 
            where T : Attribute
        {
            lock (CustomAttributeCache)
            {
                var key = (typeof(T), memberInfo);
                if (CustomAttributeCache.TryGetValue(key, out object value))
                {
                    return (T) value;
                }

                T result = memberInfo.GetCustomAttribute<T>();
                CustomAttributeCache.Add(key, result);
                return result;
            }

        }

    }
    
    /// <summary>
    /// The base output attribute, which contains the values related to how an element is written to the scene file.
    /// An element is something that is written to the scene file - which is identified by having this class (or a
    /// derivative) being an attribute of a property or the property's defining type. 
    /// 
    /// An element can therefore end up with multiple Output attributes associated with it, from:
    ///  - The element class (and base classes)
    ///  - The property (and over-ridden properties), if the element was a property of another element.
    ///  - Explicit assignment in code, when creating the ElementContext.
    /// All the values in each attribute instance are merged into a single instance before rendering (similar to CSS).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public class OutputAttribute : Attribute
    {
        private readonly PropertyStore props = new PropertyStore();
        
        /// <summary>The keyword to prepend.</summary>
        public Keyword Keyword { get => this.props.Get<Keyword>(); set => this.props.Set(value); }
        /// <summary>Only output .ToString().</summary>
        public bool OutputString { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>Text before the body (after the keyword).</summary>
        public string ContentStart { get => this.props.Get<string>(); set => this.props.Set(value); }
        /// <summary>Text after the body.</summary>
        public string ContentEnd { get => this.props.Get<string>(); set => this.props.Set(value); }
        /// <summary>True to put this after the parent ContentEnd (used by map modifiers)</summary>
        public bool Outside { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>True if this is a string, and to not space before ContentStart or after ContentEnd.</summary>
        public bool IsString { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>True to indent the body (between ContentStart and ContentEnd)</summary>
        public bool Indent { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>Only output if there's content.</summary>
        public bool OnlyWithContent { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>It's a wrapper around another element.</summary>
        public bool Wrapper { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>The type of Element.</summary>
        public Type ElementType { get => this.props.Get<Type>(); set => this.props.Set(value); }
        /// <summary>Output the value, even if not set.</summary>
        public bool Required { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>The order.</summary>
        public int Order { get => this.props.Get<int>(); set => this.props.Set(value); }
        /// <summary>Add a new-line if indented.</summary>
        public bool IndentNewLine { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>Add a new-line after the output.</summary>
        public bool NewLineAfter { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>Don't output process.</summary>
        public bool Ignore { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>Don't new-line after this element.</summary>
        public bool GroupNext { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>true to keep at the top, and comma with the next.</summary>
        public bool IsParameter { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>Inheritance depth of the property (used for ordering).</summary>
        public int Depth { get => this.props.Get<int>(); set => this.props.Set(value); }
        /// <summary>Name of the property (auto-generated).</summary>
        public string PropertyName { get => this.props.Get<string>(); set => this.props.Set(value); }
        /// <summary>The PropertyName of the property to order before.</summary>
        public string Before { get => this.props.Get<string>(); set => this.props.Set(value); }
        /// <summary>The PropertyName of the property to order after.</summary>
        public string After { get => this.props.Get<string>(); set => this.props.Set(value); }
        /// <summary>true if part of a collection.</summary>
        public bool IsCollection { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>string between items, if part of a collection.</summary>
        public string CollectionJoin { get => this.props.Get<string>(); set => this.props.Set(value); }
        /// <summary>Index of the collection.</summary>
        public int Index { get => this.props.Get<int>(); set => this.props.Set(value); }
        /// <summary>true to prefer x, y, or z for Vectors.</summary>
        public bool Direction { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>true to prefer a float for Vectors.</summary>
        public bool Float { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>true to only use RGB from a color.</summary>
        public bool Rgb { get => this.props.Get<bool>(); set => this.props.Set(value); }
        /// <summary>The keyword to use for "false", with flags or boolean values.</summary>
        public Keyword FalseKeyword { get => this.props.Get<Keyword>(); set => this.props.Set(value); }
        /// <summary>The keyword to use for "true", with boolean values.</summary>
        public Keyword TrueKeyword { get => this.props.Get<Keyword>(); set => this.props.Set(value); }
        /// <summary>The povray version that supports the item.</summary>
        public double PovVersion { get => this.props.Get<double>(); set => this.props.Set(value); }
        /// <summary>Members of this value to exclude.</summary>
        public string[] ExcludeMembers { get => this.props.Get<string[]>(); set => this.props.Set(value); }
        /// <summary>Values of this value to exclude.</summary>
        public Keyword[] ExcludeKeywords { get => this.props.Get<Keyword[]>(); set => this.props.Set(value); }
        
        /// <summary>
        /// true to make this instance override those above this one. 
        /// </summary>
        public bool Important { get; set; }
        
        public IEnumerable<(object,OutputAttribute)> AdditionalItems 
            { get => this.props.Get<IEnumerable<(object,OutputAttribute)>>(); set => this.props.Set(value); }

        public OutputAttribute(Keyword keyword = Keyword.Undefined, [CallerLineNumber] int order = int.MinValue + 1000)
        {
            if (keyword != Keyword.Undefined)
            {
                this.Keyword = keyword;
            }
            
            if (order != int.MinValue + 1000)
            {
                this.Order = order;
            }

        }

        public static OutputAttribute Default()
        {
            return new OutputAttribute();
        }

        /// <summary>
        /// Merge another instance of this class into this one.
        /// </summary>
        /// <param name="other">The other instance.</param>
        public void Combine(OutputAttribute other)
        {
            this.props.Merge(other.props);
        }

        /// <summary>
        /// Combines multiple attribute instances into one.
        /// </summary>
        /// <param name="attrs">Attributes, in order of importance (most important first).</param>
        /// <returns>An attribute containing the cascaded values.</returns>
        public static OutputAttribute Combine(IEnumerable<OutputAttribute> attrs)
        {
            OutputAttribute ret = Default();

            foreach (OutputAttribute attr in attrs.OrderByDescending(a => a.Important).Reverse())
            {
                ret.Combine(attr);
            }

            return ret;
        }

        public virtual string GetContentStart(ElementContext context)
        {
            return this.ContentStart ?? string.Empty;
        }

        public virtual string GetContentEnd(ElementContext context)
        {
            return (this.ContentEnd ?? string.Empty)
                   + (context.OutputAttribute.IsParameter && (context.Next != null) && context.Next.OutputAttribute.IsParameter && context.Next.Active
                       ? ","
                       : string.Empty);
        }
    }

    /// <summary>Ignore the element.</summary>
    public class IgnoreAttribute : OutputAttribute
    {
        public IgnoreAttribute(Keyword keyword = Keyword.Undefined) : base(keyword)
        {
            this.Ignore = true;
        }
    }

    /// <summary>
    /// Renders an optional keyword, based on a boolean value. For example, 'open' flag of the cylinder object.
    /// </summary>
    public class FlagElementAttribute : OutputAttribute
    {
        public FlagElementAttribute(Keyword keyword = Keyword.Undefined, Keyword falseKeyword = Keyword.Undefined, [CallerLineNumber] int order = 0)
            : base(keyword, order)
        {
            if (falseKeyword != Keyword.Undefined)
            {
                this.FalseKeyword = falseKeyword;
            }
            this.ElementType = typeof(FlagElement);
        }
    }
    
    /// <summary>
    /// Renders an object's property whose order matters.
    /// </summary>
    public class ObjectParameterAttribute : OutputAttribute
    {
        public ObjectParameterAttribute(Keyword keyword = Keyword.Undefined, [CallerLineNumber] int order = 0)
            : base(keyword, order)
        {
            this.IsParameter = true;
        }
    }

    /// <summary>
    /// Renders a named value of an object. For example, the 'location' directive of a camera.
    /// </summary>
    public class ValueElementAttribute : OutputAttribute
    {
        public ValueElementAttribute(Keyword keyword = Keyword.Undefined, [CallerLineNumber] int order = 0)
            : base(keyword, order)
        {
            this.OnlyWithContent = true;
        }        
    }

    /// <summary>
    /// Something that can be have an object as its value.
    /// </summary>
    public class ObjectElementAttribute : BlockElementAttribute
    {
        public ObjectElementAttribute(Keyword keyword = Keyword.Undefined, [CallerLineNumber] int order = 0)
            : base(keyword, order)
        {
            this.OnlyWithContent = true;
            this.Wrapper = true;
        }
    }

    /// <summary>
    /// Suppress new-lines after writing elements with this attribute.
    /// </summary>
    public class GroupNextAttribute : OutputAttribute
    {
        public GroupNextAttribute(Keyword keyword = Keyword.Undefined, [CallerLineNumber] int order = 0)
            : base(keyword, order)
        {
            this.GroupNext = true;
        }
    }

    /// <summary>
    /// A string value - the value is surrounded by double quotes.
    /// </summary>
    public class StringElementAttribute : OutputAttribute
    {
        public StringElementAttribute(Keyword keyword = Keyword.Undefined, [CallerLineNumber] int order = 0)
            : base(keyword, order)
        {
            this.IsString = true;
            this.ContentStart = this.ContentEnd = "\"";
        }
    }
    
    /// <summary>
    /// The child elements are to be contained within braces.
    /// </summary>
    public class BlockElementAttribute : OutputAttribute
    {
        public BlockElementAttribute(Keyword keyword = Keyword.Undefined, int order = int.MinValue + 1000)
            : base(keyword, order)
        {
            this.ContentStart = "{";
            this.ContentEnd = "}";
            this.Indent = true;
            this.OnlyWithContent = true;
            this.NewLineAfter = true;
            this.IndentNewLine = true;
        }        
    }
}