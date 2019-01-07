namespace PovScene.SceneDescription
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Design;
    using System.Linq;
    using Items;
    using Items.ObjectModifiers;
    using Output;

    /// <summary>
    /// A scene file directive.
    /// </summary>
    [ValueElement(ContentStart = "#", NewLineAfter = true, OutputString = true, Order = -1)]
    public class Directive : SceneElement, IRenderNotify
    {
        [ValueElement]
        public Keyword Keyword { get; set; }
        public string Content { get; set; }
        
        [BlockElement()]
        protected SceneElement ContentItem { get; private set; }
           

        public Directive(Keyword keyword, string content)
        {
            this.Keyword = keyword;
            this.Content = content;
        }
        public override string ToString()
        {
            return this.Content == null
                ? null
                : string.Format("{0} {1}", KeywordAttribute.ToString(this.Keyword), this.Content);
        }

        public void RenderNotify(ElementContext context)
        {
            if (this.Content == null && this.ContentItem != null)
            {
                context.OutputAttribute.OutputString = false;
            }
        }

        /// <summary>Create an include directive.</summary>
        /// <param name="path"></param>
        public static Directive Include(string path)
        {
            return new Directive(Keyword.Include, string.Format("\"{0}\"", path));
        }

        public static Directive Default(Texture texture)
        {
            return new Directive(Keyword.Default, null)
            {
                ContentItem = new SceneItemWrapper<Texture>(texture)
            };
        }
    }

    /// <summary>A collection of directives.</summary>
    public class DirectiveCollection : SceneElement 
    {
        [Output]
        internal Collection<Directive> Directives { get; }

        public DirectiveCollection()
        {
            this.Directives = new Collection<Directive>();
        }
        
        public DirectiveCollection(IEnumerable<Directive> directives)
        {
            this.Directives = new Collection<Directive>(directives.ToList());
        }
    }
    
}