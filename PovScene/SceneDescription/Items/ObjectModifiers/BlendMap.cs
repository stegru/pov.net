namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Libraries;
    using Output;
    using Values;

    public abstract class BlendMap : SceneElement
    {
        [Output]
        public Collection<BlendMapItem> MapItems { get; set; } = new Collection<BlendMapItem>();

    }
    
    [ValueElement(ContentStart = "[", ContentEnd = "]")]
    public class BlendMapItem : SceneElement
    {
        [ValueElement(ContentEnd = " ")]
        [GroupNext]
        public Float Number { get; internal set; }
        [Ignore]
        public IValue Value { get; }

        internal bool Auto;

        public BlendMapItem(IValue value) : this(0, value)
        {
            this.Auto = true;
        }

        public BlendMapItem(Float number, IValue value)
        {
            this.Number = number;
            this.Value = value;
        }

        protected override IEnumerable<(object value, OutputAttribute output)> GetAdditionalValues()
        {
            // Output just the content of the map values.
            return new (object, OutputAttribute)[]
            {
                (this.Value, new ValueElementAttribute())
            };
        }
    }

    public abstract class BlendMap<TValue> : BlendMap, IEnumerable<(Float, TValue)>, IIdentifiable
        where TValue : IValue
    {
        [ValueElement] public string Identifier { get; set; }
        [Ignore] public Library IdentifierLibrary { get; set; }

        [ValueElement(Keyword.Frequency, Outside = true)]
        public Float Frequency { get; set; }

        [ValueElement(Keyword.Phase, Outside = true)]
        public Float Phase { get; set; }
        
        /// <summary>
        /// Assign a number to the items that have no number, via an equal increment between those that have a number. 
        /// </summary>
        protected void AdjustAutoNumbers()
        {
            BlendMapItem[] items = this.MapItems.ToArray();
            int total = items.Length;
            int autoCount = items.Count(item => item.Auto);

            if (total == 0 || autoCount == 0)
            {
                return;
            }

            if (autoCount == total)
            {
                switch (total)
                {
                    case 1:
                        items[0].Number = 0.5;
                        return;
                    case 2:
                        items[0].Number = 0;
                        items[1].Number = 1;
                        return;
                }
            }

            double currentNumber = 0;
            
            for (int n = 0; n < total; n++)
            {
                if (items[n].Auto)
                {
                    if (n == 0)
                    {
                        currentNumber = items[n].Number = 0;
                        continue;
                    }
                    int count = 0;
                    double last = 1;
                    for (int lookAhead = n+1; lookAhead < total; lookAhead++)
                    {
                        count++;
                        if (!items[lookAhead].Auto)
                        {
                            last = items[lookAhead].Number;
                            break;
                        }
                    }

                    if (count == 1)
                    {
                        items[n].Number = currentNumber + (last - currentNumber) / 2;
                    }
                    else
                    {

                        double interval = (last - currentNumber) / (count + 1);
                        for (; n < total && items[n].Auto; n++)
                        {
                            if (n > 0)
                            {
                                currentNumber += interval;
                            }

                            items[n].Number = currentNumber;
                        }
                    }
                }
                else
                {
                    currentNumber = items[n].Number;
                }
            }
        }
        public void Add(TValue value)
        {
            this.MapItems.Add(new BlendMapItem(value));
            this.AdjustAutoNumbers();
        }

        public void Add(Float number, TValue value)
        {
            this.MapItems.Add(new BlendMapItem(number, value));
            this.AdjustAutoNumbers();
        }

        public void Clear()
        {
            this.MapItems.Clear();
        }

        public IEnumerator<(Float, TValue)> GetEnumerator()
        {
            return this.MapItems.Select(e => (e.Number, (TValue)e.Value)).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    
    [BlockElement(Keyword = Keyword.ColorMap)]
    public class ColorMap : BlendMap<Color>
    {
    }
    
    [BlockElement(Keyword = Keyword.PigmentMap)]
    public class PigmentMap : BlendMap<Pigment>
    {
    }
    
    [BlockElement(Keyword = Keyword.TextureMap)]
    public class TextureMap : BlendMap<Texture>
    {
    }

    [BlockElement(Keyword = Keyword.NormalMap)]
    public class NormalMap : BlendMap<Normal>
    {
    }

    [BlockElement(Keyword = Keyword.SlopeMap)]
    public class SlopeMap : BlendMap<Vector2D>
    {
    }

    [BlockElement(Keyword = Keyword.DensityMap)]
    public class DensityMap : BlendMap<Vector2D>
    {
        // TODO
    }
}