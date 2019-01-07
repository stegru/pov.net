namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Libraries;
    using Output;
    using Util;

    [BlockElement(Keyword.Texture)]
    public class Texture : TextureModifier, IIdentifiable
    {
        [ValueElement] public string Identifier { get; set; }
        [Ignore]
        public Library IdentifierLibrary { get; set; }

        [Init][Output]
        public virtual Pigment Pigment { get; set; }

        [Init][Output]
        public virtual Normal Normal { get; set; }

        [Init][Output]
        public virtual Finish Finish { get; set; }

        public Texture(Texture baseTexture)
        {
            this.Pigment = baseTexture.Pigment.Copy();
            this.Normal = baseTexture.Normal.Copy();
            this.Finish = baseTexture.Finish.Copy();
            this.Transformations = baseTexture.Transformations.Copy();
            this.Identifier = baseTexture.Identifier;
        }

        public Texture()
        {
        }
        
        public Texture(string identifier)
        {
            this.Identifier = identifier;
        }

        public static LayeredTexture operator +(Texture left, Texture right)
        {
            return new LayeredTexture
            {
                left,
                right
            };
        }
    }

    internal class InteriorTexture : ItemModifier
    {
        [Output(Keyword.InteriorTexture)]
        public Texture Texture { get; }
        
        public InteriorTexture(Texture texture)
        {
            this.Texture = texture;
        }
    }

    [Output(Keyword.Null, ContentStart = null, ContentEnd = null, Indent = false, Important = true)]
    public class LayeredTexture : Texture, ICollection<Texture>, ICollection, IRenderNotify
    {
        public LayeredTexture(params Texture[] textures)
        {
            foreach (Texture texture in textures)
            {
                this.Textures.Add(texture);
            }
        }
        
        [Output]
        public Collection<Texture> Textures { get; } = new Collection<Texture>();

        [Ignore]
        public override Pigment Pigment
        {
            get => this.Textures.FirstOrDefault()?.Pigment;
            set
            {
                foreach (Texture texture in this.Textures)
                {
                    texture.Pigment = value;
                }
            }
        }

        [Ignore]
        public override Normal Normal
        {
            get => this.Textures.FirstOrDefault()?.Normal;
            set
            {
                foreach (Texture texture in this.Textures)
                {
                    texture.Normal = value;
                }
            }
        }

        [Ignore]
        public override Finish Finish
        {
            get => this.Textures.FirstOrDefault()?.Finish;
            set
            {
                foreach (Texture texture in this.Textures)
                {
                    texture.Finish = value;
                }
            }
        }

        public void RenderNotify(ElementContext context)
        {
            if (this.Transformations.Count > 0)
            {
                foreach (Texture texture in this)
                {
                    texture.Transformations.AddRange(this.Transformations);
                }
            }

            this.Transformations.Clear();
        }

        public IEnumerator<Texture> GetEnumerator()
        {
            return this.Textures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this.Textures).GetEnumerator();
        }

        public void Add(Texture item)
        {
            this.Textures.Add(item);
        }

        public void Clear()
        {
            this.Textures.Clear();
        }

        public bool Contains(Texture item)
        {
            return this.Textures.Contains(item);
        }

        public void CopyTo(Texture[] array, int arrayIndex)
        {
            this.Textures.CopyTo(array, arrayIndex);
        }

        public bool Remove(Texture item)
        {
            return this.Textures.Remove(item);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection) this.Textures).CopyTo(array, index);
        }

        public int Count => this.Textures.Count;
        public bool IsSynchronized => ((ICollection) this.Textures).IsSynchronized;
        public object SyncRoot => ((ICollection) this.Textures).SyncRoot;
        public bool IsReadOnly => ((ICollection<Texture>) this.Textures).IsReadOnly;
    }

    public abstract class TextureModifier : ObjectModifier, ITransformable
    {
        [Output(Order = Int32.MaxValue)]
        public virtual Transformations Transformations { get; protected set; } = new Transformations();
        
        public virtual ITransformable Transform(Transformation transformation)
        {
            this.Transformations.Transform(transformation);
            return this;
        }
    }

}