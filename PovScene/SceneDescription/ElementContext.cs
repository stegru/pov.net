namespace PovScene.SceneDescription
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using Engine;
    using Libraries;
    using Output;

    /// <summary>
    /// Describes a particular reference to an element within a scene.
    /// When the scene is generated, this is the tree of elements and their output attributes.
    /// </summary>
    public class ElementContext
    {
        private string fullName;
        
        /// <summary>The scene.</summary>
        public Scene Scene { get; }
        /// <summary>The element context that contains this one.</summary>
        public ElementContext Parent { get; }
        /// <summary>The element to which this context refers.</summary>
        public SceneElement Element { get; }
        
        /// <summary>The previous child element.</summary>
        public ElementContext Prev { get; private set; }
        /// <summary>The next child element.</summary>
        public ElementContext Next { get; private set; }
        /// <summary>The child elements.</summary>
        public List<ElementContext> Children { get; } = new List<ElementContext>();

        public OutputAttribute OutputAttribute { get; }
        
        /// <summary>false to not display the element.</summary>
        public bool Active { get; set; } = true;

        private int order;
        private int childCount;

        public string FullName
        {
            get
            {
                if (this.fullName == null)
                {
                    string name = this.OutputAttribute.PropertyName ?? string.Empty;
                    if (this.OutputAttribute.IsCollection)
                    {
                        name += "[" + this.OutputAttribute.Index + "#" + this.Name + "]";
                    }

                    if (string.IsNullOrEmpty(name))
                    {
                        name += this.Name;
                    }

                    string parent = (this.Parent == null ? string.Empty : this.Parent.FullName + "."); 
                    this.fullName = parent + name;
                }
                return this.fullName;
            }
        }

        public string Name => this.Element.Id;

        public ElementContext(ElementContext parent, SceneElement element, OutputAttribute outputAttribute = null)
        {
            this.Parent = parent;
            this.Scene = element as Scene ?? this.Parent.Scene;
            if (this.Parent != null)
            {
                this.Parent.childCount++;
            }

            this.OutputAttribute = outputAttribute ?? OutputAttribute.Default();

            int order = this.OutputAttribute.Order;
            if (order != int.MinValue && order != int.MaxValue)
            {
                // Order elements with deeper inheritance first.
                order = this.OutputAttribute.Order = 10000 + order - this.OutputAttribute.Depth * 1000;
            }

            this.order = order;

            this.Element = element;
            this.Active = this.Element.HasValue && !this.OutputAttribute.Ignore;

            if (this.Active)
            {
                if (this.Element is IRenderNotify renderNotify)
                {
                    renderNotify.RenderNotify(this);
                }

                if (this.Element is IIdentifiable identifiable)
                {
                    if (identifiable.IdentifierLibrary != null && identifiable.Identifier != null)
                    {
                        this.Scene.Include.Add(identifiable.IdentifierLibrary.Filename);
                    }
                }
            }
        }

        private void CreateChildren()
        {
            List<ElementContext> childs = this.Element
                .GetElements(this)
                .Where(e => e.Active)
                .ToList();

            foreach (ElementContext context in childs)
            {
                // Order before/after
                string otherName = context.OutputAttribute.After;
                bool after = !string.IsNullOrEmpty(otherName);
                if (!after)
                {
                    otherName = context.OutputAttribute.Before;
                }
                
                if (!string.IsNullOrEmpty(otherName))
                {
                    ElementContext otherElem = childs.FirstOrDefault(e => e.OutputAttribute.PropertyName == otherName);
                    if (otherElem != null)
                    {
                        context.order = otherElem.order + (after ? 1 : -1);
                    }
                }
            }
            
            ElementContext prev = null;
            foreach (ElementContext current in childs.OrderByDescending(e => e.OutputAttribute.IsParameter).ThenBy(e => e.order))
            {
                this.Children.Add(current);
                current.Prev = prev;
                if (prev != null)
                {
                    prev.Next = current;
                }

                prev = current;
            }
        }

        /// <summary>Return the preceding siblings.</summary>
        public IEnumerable<ElementContext> AllNext()
        {
            ElementContext current = this.Next;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        /// <summary>Return the previous siblings.</summary>
        public IEnumerable<ElementContext> AllPrev()
        {
            ElementContext current = this.Prev;
            while (current != null)
            {
                yield return current;
                current = current.Prev;
            }
        }


        /// <summary>Create the child elements</summary>
        public void LoadChildren(bool recursive = true)
        {
            if (this.Scene.Animating)
            {
                this.Element.OnAnimate(this.Scene.Animation);
            }
            try
            {
                this.Element.IsRendering = true;
                
                this.CreateChildren();

                if (recursive)
                {
                    foreach (ElementContext child in this.Children)
                    {
                        child.LoadChildren();
                    }
                }
            }
            finally
            {
                this.Element.IsRendering = false;
            }
        }

        /// <summary>Write this element to the scene file.</summary>
        /// <param name="output"></param>
        public void Write(SceneWriter output)
        {
            if (this.Active)
            {
                this.Element.Write(output, this);
            }
        }
    }

    /// <summary>
    /// When added to a scene, elements with this interface receive a notification when they're about to be rendered to
    /// the scene file. 
    /// </summary>
    public interface IRenderNotify
    {
        /// <summary>Called when the element is about to be rendered to the scene file.</summary>
        /// <param name="context"></param>
        void RenderNotify(ElementContext context);
    }
}