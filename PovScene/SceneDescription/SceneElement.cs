namespace PovScene.SceneDescription
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Engine;
    using Items;
    using Output;
    using Values;

    /// <summary>
    /// The base class of anything that's part of a scene.
    /// </summary>
    public class SceneElement : IValue
    {
        /// <summary>true if this element has a value.</summary>
        [Ignore] public bool HasValue => true;

        public string Id { get; }

        private static readonly IDictionary<string, int> Ids = new ConcurrentDictionary<string, int>();

        private SceneWriter outsideWriter;
        
        public bool IsRendering { get; internal set; }

        protected SceneElement()
        {
            // Give this element a unique name, base on its type.
            string id = this.GetType().Name;
            if (!Ids.TryGetValue(id, out int count))
            {
                count = 0;
            }

            Ids[id] = ++count;
            this.Id = id + "_" + count;

            // Initialise the collection properties.
            foreach (PropertyInfo property in this.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                               BindingFlags.FlattenHierarchy))
            {
                bool create = typeof(ICollection<>).IsAssignableFrom(property.PropertyType) ||
                              property.GetCustomAttributesFast<InitAttribute>().Any();

                if (create && property.GetValue(this) == null)
                {
                    object value = Activator.CreateInstance(property.PropertyType);
                    property.SetValue(this, value);
                }
            }
        }

        /// <summary>Raised for each frame when being animated.</summary>
        public event EventHandler<Animation> Animate;
        
        /// <summary>Called when rendering an animation frame.</summary>
        /// <param name="animation">The animation information.</param>
        internal void OnAnimate(Animation animation)
        {            
            this.Animate?.Invoke(this, animation);
        }
        
        /// <summary>Get the output producing properties.</summary>
        /// <returns>An enumeration of objects, the property type, and output attributes.</returns>
        protected virtual IEnumerable<(object, MemberInfo, OutputAttribute)> GetProperties()
        {
            return this.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                               BindingFlags.FlattenHierarchy)
                .Where(p => p.GetIndexParameters().Length == 0)
                .Select(p => (p.GetValue(this), (MemberInfo) p, (OutputAttribute) null));
        }

        /// <summary>Override to provide additional objects for output.</summary>
        /// <returns>Values and their output attributes.</returns>
        protected virtual IEnumerable<(object value, OutputAttribute output)> GetAdditionalValues()
        {
            return Enumerable.Empty<(object, OutputAttribute)>();
        }

        /// <summary>Gets objects and their output attributes from this element</summary>
        /// <param name="parent">The element context of the parent element.</param>
        /// <returns></returns>
        protected virtual IEnumerable<(object value, OutputAttribute output)> GetValues(ElementContext parent)
        {
            string[] excludeMembers = parent.OutputAttribute.ExcludeMembers;
            if (excludeMembers == null && parent.Parent?.Element is SceneItemWrapper<SceneItem>)
            {
                excludeMembers = parent.Parent.OutputAttribute.ExcludeMembers;
            }
            
            foreach ((object value, MemberInfo type, OutputAttribute output) in this.GetProperties())
            {
                OutputAttribute outputAttr;

                if (type is PropertyInfo propertyInfo)
                {
                    if (excludeMembers != null && excludeMembers.Length > 0)
                    {
                        if (excludeMembers.Contains(type.Name))
                        {
                            continue;
                        }
                    }
                    
                    OutputAttribute[] propertyAttrs = type.GetCustomAttributesFast<OutputAttribute>().ToArray();
                    if (propertyAttrs.Length == 0)
                    {
                        // Property has no Output attribute
                        continue;
                    }

                    // Combine the attributes of the property
                    outputAttr = OutputAttribute.Combine(propertyAttrs);
                    if (output != null)
                    {
                        outputAttr.Combine(output);
                    }

                    outputAttr.Depth = propertyInfo.GetPropertyInheritanceDepth();
                    outputAttr.PropertyName = propertyInfo.Name;
                    
                }
                else
                {
                    outputAttr = output;
                }

                if (value is ICollection enumerable)
                {
                    int index = 0;

                    if (enumerable.Cast<object>().All(e => e == null))
                    {
                        continue;
                    }

                    if (!outputAttr.IsCollection)
                    {
                        outputAttr.IsCollection = true;
                        // Unwrap the enumeration
                        foreach (SceneElement element in enumerable.OfType<SceneElement>())
                        {
                            outputAttr.Index = index++;
                            yield return (element, outputAttr);
                        }

                        continue;
                    }
                }

                yield return (value, outputAttr);

            }
        }

        /// <summary>Gets the child elements of this element.</summary>
        /// <param name="parent">The parent element's context.</param>
        /// <returns>Enumeration of elements.</returns>
        public virtual IEnumerable<ElementContext> GetElements(ElementContext parent)
        {
            IEnumerable<(object, OutputAttribute)> values =
                this.GetValues(parent)
                    .Concat(this.GetAdditionalValues());

            if (parent.OutputAttribute.AdditionalItems != null)
            {
                values = values.Concat(parent.OutputAttribute.AdditionalItems);
            }
            
            Keyword[] excludeKeywords = parent.OutputAttribute.ExcludeKeywords;
            if (excludeKeywords == null && parent.Parent?.Element is SceneItemWrapper<SceneItem>)
            {
                excludeKeywords = parent.Parent.OutputAttribute.ExcludeKeywords;
            }

            foreach ((object valueOrig, OutputAttribute output) in values)
            {
                object value = valueOrig;
                if (value == null || value is IValue v && !v.HasValue)
                {
                    continue;
                }

                if (output != null)
                {
                    if (output.Wrapper && value is SceneItem item)
                    {
                        value = new SceneItemWrapper<SceneItem>(item);
                    }
                }

                OutputAttribute outputAttribute =
                    OutputAttribute.Combine(value.GetType().GetAllAttributes<OutputAttribute>());

                if (output != null)
                {
                    outputAttribute.Combine(output);
                }

                if (outputAttribute.Ignore)
                {
                    continue;
                }
                
                if (outputAttribute.PovVersion > parent.Scene.PovVersion)
                {
                    continue;
                }

                if (excludeKeywords != null)
                {
                    if (excludeKeywords.Contains(outputAttribute.Keyword))
                    {
                        continue;
                    }
                }


                SceneElement element = value as SceneElement ?? SceneElement.CreateElement(value, outputAttribute);
                ElementContext context = new ElementContext(parent, element, outputAttribute);
                yield return context;
            }
        }
        
        /// <summary>Create an element for a non-element object</summary>
        /// <param name="value"></param>
        /// <param name="outputAttribute"></param>
        /// <returns></returns>
        public static SceneElement CreateElement(object value, OutputAttribute outputAttribute)
        {
            return Activator.CreateInstance(
                outputAttribute.ElementType ?? typeof(ValueElement), value, outputAttribute) as SceneElement;
        }


        /// <summary>
        /// Write the inner content of this element.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="context"></param>
        protected virtual void WriteContent(SceneWriter output, ElementContext context)
        {
            bool? space = context.OutputAttribute.IsString ? (bool?)false : null;

            if (context.OutputAttribute.OutputString)
            {
                output.Append(this.ToString(), space);
            }
            else
            {
                context.Children.ForEach(child =>
                {
                    child.Write(child.OutputAttribute.Outside ? this.outsideWriter : output);
                });
            }
        }

        /// <summary>Gets the keyword used by this element.</summary>
        /// <param name="context"></param>
        protected virtual string GetKeyword(ElementContext context)
        {
            return KeywordAttribute.ToString(context.OutputAttribute.Keyword);            
        }
    

        /// <summary>Write the start of this element, which is usually the keyword.</summary>
        /// <param name="output"></param>
        /// <param name="context"></param>
        protected virtual void WriteStart(SceneWriter output, ElementContext context)
        {
            this.outsideWriter = new SceneWriter {IndentLevel = output.IndentLevel};

            string keyword = this.GetKeyword(context);
            if (!string.IsNullOrEmpty(keyword))
            {
                output.Append(keyword);
            }

            output.Append(context.OutputAttribute.GetContentStart(context));
            if (context.OutputAttribute.Indent)
            {
                output.Indent(context.OutputAttribute.IndentNewLine);
            }
        }
        
        /// <summary>Write the end of this element.</summary>
        /// <param name="output"></param>
        /// <param name="context"></param>
        protected virtual void WriteEnd(SceneWriter output, ElementContext context)
        {
            if (context.OutputAttribute.Indent)
            {
                output.Unindent(context.OutputAttribute.IndentNewLine);
            }

            bool? space = context.OutputAttribute.IsString ? (bool?)false : null;
            output.Append(context.OutputAttribute.GetContentEnd(context), space);

            if (!context.OutputAttribute.GroupNext)
            {
                output.AppendLine();
            }

            output.Append(this.outsideWriter.ToString());
            this.outsideWriter = null;
        }

        /// <summary>
        /// Write this element to the output.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="context">The element context.</param>
        public virtual void Write(SceneWriter output, ElementContext context)
        {
            int startPos = output.Length;
            int startIndent = output.IndentLevel;
            
            this.WriteStart(output, context);
            int contentPos = output.Length;
            this.WriteContent(output, context);

            if (context.OutputAttribute.OnlyWithContent && output.Length == contentPos)
            {
                output.Length = startPos;
                output.IndentLevel = startIndent;
            }
            else
            {
                bool newLine = false;
                if (context.OutputAttribute.Indent)
                {
                    string content = output.SubString(contentPos).Trim();
                    if (content.IndexOf('\n') == -1)
                    {
                        output.Length = contentPos;
                        output.Unspace();                        
                        output.Append(content);
                        if (context.OutputAttribute.IndentNewLine)
                        {
                            context.OutputAttribute.IndentNewLine = false;
                            newLine = true;
                        }
                    }
                }
                
                this.WriteEnd(output, context);

                if (newLine)
                {
                    context.OutputAttribute.IndentNewLine = true;
                }

                
            }
        }

        /// <summary>Determines if this element is equal to another - that is, they are the same object.</summary>
        /// <param name="other">The other element.</param>
        /// <returns>true if they're the same object.</returns>
        private bool Equals(SceneElement other)
        {
            return string.Equals(this.Id, other.Id);
        }

        /// <summary>Determines if this element is equal to another - that is, they are the same object.</summary>
        /// <param name="obj">The other object.</param>
        /// <returns>true if they're the same object.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((SceneElement) obj);
        }

        public override int GetHashCode()
        {
            return (this.Id != null ? this.Id.GetHashCode() : 0);
        }

        public static bool operator ==(SceneElement left, SceneElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SceneElement left, SceneElement right)
        {
            return !Equals(left, right);
        }
    }

    /// <summary>
    /// An element that is a single value.
    /// </summary>
    public class ValueElement : SceneElement, IRenderNotify
    {
        /// <summary>The value, as a string.</summary>
        public string Value { get; set; }
        /// <summary>The original value.</summary>
        public object RealValue { get; set; }
        /// <summary>true to display this element, or false to hide.</summary>
        private bool active = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The value that the element should wrap.</param>
        /// <param name="outputAttribute">The output attribute for the value.</param>
        public ValueElement(object value, OutputAttribute outputAttribute)
        {
            bool gotValue = false;
            this.RealValue = value;

            if (value is bool b)
            {
                Keyword keyword = b
                    ? (outputAttribute.TrueKeyword == Keyword.Undefined ? Keyword.On : outputAttribute.TrueKeyword)
                    : (outputAttribute.FalseKeyword == Keyword.Undefined ? Keyword.Off : outputAttribute.FalseKeyword);

                if (keyword == Keyword.Null)
                {
                    this.active = false;
                    return;
                }
                
                value = keyword;
            }

            if (outputAttribute.Rgb && value is Color color)
            {
                value = Color.ToRgb(color);
            }
            
            switch (value)
            {
                case Enum _:
                    KeywordAttribute attr =
                        value.GetType().GetField(value.ToString()!).GetCustomAttributeFast<KeywordAttribute>();
                    
                    if (attr != null)
                    {
                        this.Value = KeywordAttribute.ToString(attr.Keyword);
                        if (string.IsNullOrEmpty(this.Value))
                        {
                            this.Value = null;
                        }

                        gotValue = true;
                    }

                    break;
                case IValue v:
                    if (!v.HasValue)
                    {
                        this.Value = null;
                        gotValue = true;
                    }
                    break;                
            }
            
            if (!gotValue)
            {
                this.Value = value.ToString();
            }
        }

        /// <inheritdoc />
        public override void Write(SceneWriter output, ElementContext context)
        {
            if (this.active)
            {
                base.Write(output, context);
            }
        }

        /// <inheritdoc />
        protected override void WriteContent(SceneWriter output, ElementContext context)
        {
            if (context.OutputAttribute.IsCollection && this.RealValue.GetType().IsArray)
            {
                IEnumerable<string> e = ((IEnumerable) this.RealValue)
                    .Cast<object>()
                    .Where(o => o != null)
                    .Select(o => o.ToString());
                
                this.Value = string.Join(context.OutputAttribute.CollectionJoin ?? " " , e);
            }
            
            if (context.OutputAttribute.Direction)
            {
                if (this.RealValue is Vector v)
                {
                    this.Value = v.ToString(true);
                }
            }

            if (context.OutputAttribute.Float)
            {
                switch (this.RealValue)
                {
                    case Vector v:
                        if (v.x == v.y && v.x == v.z)
                        {
                            this.Value = v.x.ToString();
                        }

                        break;
                    case Color c:
                        if (c.Identifier == null && c.Red == c.Green && c.Red == c.Blue)
                        {
                            this.Value = c.Red.ToString();
                        }

                        break;
                }
            }

            output.Append(this.Value);
        }

        /// <summary>Called before the item is to be rendered.</summary>
        /// <param name="context"></param>
        public void RenderNotify(ElementContext context)
        {
            if (this.RealValue is IRenderNotify renderNotify)
            {
                renderNotify.RenderNotify(context);
            }
        }
    }

    /// <summary>
    /// An element representing a boolean value, which is displayed when true and hidden when false.
    /// </summary>
    public class FlagElement : ValueElement
    {
        private bool active;

        public FlagElement(object value, OutputAttribute outputAttribute) : base(value, outputAttribute)
        {
            if (value is bool b)
            {
                this.active = b;
            }
            else if (bool.TryParse(this.Value, out bool b2))
            {
                this.active = b2;
            }
            else if (int.TryParse(this.Value, out int n))
            {
                this.active = n != 0;
            }
            else
            {
                this.active = string.IsNullOrWhiteSpace(this.Value);
            }
        }

        /// <inheritdoc />
        protected override string GetKeyword(ElementContext context)
        {
            return this.active
                ? base.GetKeyword(context)
                : KeywordAttribute.ToString(context.OutputAttribute.FalseKeyword);
        }

        /// <inheritdoc />
        public override void Write(SceneWriter output, ElementContext context)
        {
            if (this.active || context.OutputAttribute.FalseKeyword != Keyword.Undefined)
            {
                base.Write(output, context);
            }
        }

        /// <inheritdoc />
        protected override void WriteContent(SceneWriter output, ElementContext context)
        {
            // There is no inner content for this type of element
        }
    }
}