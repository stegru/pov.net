namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Output;

    /// <summary>
    /// Constructive Solid Geometry shape.
    /// </summary>
    public class CSG : SceneObject, IEnumerable<SceneObject>
    {
        [Output]
        public Collection<SceneObject> Objects { get; }

        public CSG(IEnumerable<SceneObject> objects)
        {
            IEnumerable<SceneObject> list = objects ?? Enumerable.Empty<SceneObject>();
            this.Objects = new Collection<SceneObject>(list.ToList());
        }

        public CSG()
            : this(null)
        {
        }

        public void Add(SceneObject obj)
        {
            this.Objects.Add(obj);
        }

        public IEnumerator<SceneObject> GetEnumerator()
        {
            return this.Objects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
        public SceneObject this[int index] => this.Objects[index];
    }

    [BlockElement(Keyword.Union)]
    public class Union : CSG
    {        
    }
    [BlockElement(Keyword.Intersection)]
    public class Intersection : CSG
    {        
        [FlagElement(Keyword.CutawayTextures)]
        public bool CutawayTextures { get; set; }
    }
    
    [BlockElement(Keyword.Difference)]
    public class Difference : CSG
    {        
        [FlagElement(Keyword.CutawayTextures)]
        public bool CutawayTextures { get; set; }
    }
    
    [BlockElement(Keyword.Merge)]
    public class Merge : CSG
    {        
    }
}