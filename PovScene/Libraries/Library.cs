namespace PovScene.Libraries
{
    public partial class Library
    {
        internal static readonly Library TexturesInc = new Library("textures.inc");
        internal static readonly Library ColorsInc = new Library("colors.inc");
        internal static readonly Library WoodsInc = new Library("woods.inc");
        internal static readonly Library FinishInc = new Library("finish.inc");
        internal static readonly Library StonesInc = new Library("stones.inc");

        public string Filename { get; }

        protected Library(string filename)
        {
            this.Filename = filename;
        }

        internal T Get<T>(string identifier)
            where T : IIdentifiable, new()
        {
            T obj = new T
            {
                Identifier = identifier,
                IdentifierLibrary = this
            };
            return obj;
        }
    }

    public interface IIdentifiable
    {
        string Identifier { get; set; }
        Library IdentifierLibrary { get; set; }
    }
}