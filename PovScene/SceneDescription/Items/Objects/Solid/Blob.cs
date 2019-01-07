namespace PovScene.SceneDescription.Items.Objects.Solid
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Output;
    using Values;


    [BlockElement(Keyword.Blob)]
    public class Blob : SolidObject, IEnumerable
    {
        [ValueElement(Keyword.Threshold, Order = int.MinValue)]
        public Float Threshold { get; set; }
        
        
        public List<(SolidObject obj, Float strength)> BlobItems { get; }
            = new List<(SolidObject item, Float strength)>();

        public Blob()
        {
        }

        public void Add(Sphere sphere, Float strength)
        {
            this.BlobItems.Add((sphere, strength));
        }
        
        public void Add(Cylinder cylinder, Float strength)
        {
            this.BlobItems.Add((cylinder, strength));
        }


        protected override IEnumerable<(object value, OutputAttribute output)> GetAdditionalValues()
        {
            int order = 0;
            return this.BlobItems.Select(item =>
            {
                OutputAttribute output = new OutputAttribute()
                {
                    Order = int.MinValue,
                    AdditionalItems = new[] {((object) item.strength, (OutputAttribute)new ObjectParameterAttribute())}
                };
                
                return ((object) item.obj, output);
            });
        }

        public IEnumerator GetEnumerator()
        {
            return this.BlobItems.GetEnumerator();
        }
    }

    public interface IBlobItem
    {
    }
    
}
