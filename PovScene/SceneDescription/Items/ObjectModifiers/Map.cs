namespace PovScene.SceneDescription.Items.ObjectModifiers
{
    using System.Collections.ObjectModel;
    using Output;
    using Values;

    public interface IFileMap
    {
        PovImage MapImage { get; set; }
        bool Once { get; set; }
        MapType MapType { get; set; }
        Interpolation Interpolate { get; set; } 
    }
    
    public class FileMap : SceneElement, IFileMap
    {
        /// <inheritdoc cref="IFileMap"/>
        [Output]
        public PovImage MapImage { get; set; }
        
        [ValueElement(Keyword.Gamma)]
        public Float Gamma { get; set; }

        /// <inheritdoc cref="IFileMap"/>
        [FlagElement(Keyword.Once)]
        public bool Once { get; set; }

        /// <inheritdoc cref="IFileMap"/>
        [ValueElement(Keyword.MapType)]
        protected int? MapTypeOutput => this.MapType == MapType.Planar ? null : (int?) this.MapType; 
        public MapType MapType { get; set; }
        
        /// <inheritdoc cref="IFileMap"/>
        [ValueElement(Keyword.Interpolate)]
        protected int? InterpolateOutput => this.Interpolate == Interpolation.None ? null : (int?) this.Interpolate; 
        public Interpolation Interpolate { get; set; }
        
    }

    public enum MapType
    {
        Planar = 0,
        Spherical = 1,
        Cylindrical = 2,
        Torus = 5,
        Angular = 7
    }

    public enum Interpolation
    {
        None = 0,
        Bilinear = 2,
        Bicubic = 3,
        Normalized = 4
    }
    
    [BlockElement(Keyword.ImageMap)]
    public class ImageMap : FileMap
    {
    }
    
    [BlockElement(Keyword.BumpMap)]
    public class BumpMap : FileMap
    {
        [ValueElement(Keyword.BumpSize)]
        public Float BumpSize { get; set; }

        [ValueElement(Keyword.UseIndex)]
        public bool? UseIndex { get; set; }

        [ValueElement(Keyword.UseColor)]
        public bool? UseColor { get; set; }
    }
    
    [BlockElement(Keyword.MaterialMap)]
    public class MaterialMap : FileMap
    {
        [Output]
        [Init]
        public Collection<Texture> Textures { get; set; }
    }
    

}