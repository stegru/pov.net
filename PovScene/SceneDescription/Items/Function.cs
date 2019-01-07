namespace PovScene.SceneDescription.Items
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Output;

    [Output(Keyword.Function)]
    public class Function : SceneElement
    {
        public Collection<string> Parameters { get; } = new Collection<string>();

        [ValueElement(ContentStart = "(", ContentEnd = ")",
            CollectionJoin = ",", IsCollection = true,
            Before = nameof(Expression))]
        public string[] ParametersOutput => this.Parameters.ToArray();

        [BlockElement]
        public string Expression { get; set; }
        
        public Function()
        {
        }

        public Function(string expression)
        {
            this.Expression = expression;
        }
        
        public Function(string arg1, string expression)
            :this(expression)
        {
            this.Parameters = new Collection<string> {arg1};
        }

        public Function(string arg1, string arg2, string expression)
            :this(expression)
        {
            this.Parameters = new Collection<string> {arg1, arg2};
        }

        public Function(string arg1, string arg2, string arg3, string expression)
            :this(expression)
        {
            this.Parameters = new Collection<string> {arg1, arg2, arg3};
        }

        public Function(string arg1, string arg2, string arg3, string arg4, string expression)
            :this(expression)
        {
            this.Parameters = new Collection<string> {arg1, arg2, arg3, arg4};
        }
        
        public static implicit operator Function(string expression)
        {
            return new Function(expression);
        }
    }
}