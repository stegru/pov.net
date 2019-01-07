namespace PovScene.SceneDescription.Items
{
    using System;
    using Output;
    using Values;

    [BlockElement(Keyword.GlobalSettings)]
    public class GlobalSettings : SceneItem
    {
        [ValueElement(Keyword.AdcBailout)]
        public Float AdcBailout { get; set; } 
        [ValueElement(Keyword.AmbientLight)]
        public Color AmbientLight { get; set; } 
        [ValueElement(Keyword.AssumedGamma)]
        public Float AssumedGamma { get; set; } = 1; 
        [ValueElement(Keyword.IridWavelength)]
        public Color IridWavelength { get; set; } 
        //protected Keyword Charset => this.CharsetUnicode ? Keyword.Utf8 : Keyword.Null;
        [ValueElement(Keyword.Charset, TrueKeyword = Keyword.Utf8, FalseKeyword = Keyword.Null)]
        public bool CharsetUnicode { get; set; }
        [ValueElement(Keyword.MaxIntersections)]
        public int? MaxIntersections { get; set; }
        [ValueElement(Keyword.MaxTraceLevel)]
        public int? MaxTraceLevel { get; set; }
        [ValueElement(Keyword.MmPerUnit)]
        public int? MmPerUnit { get; set; } 
        [ValueElement(Keyword.NumberOfWaves)]
        public int? NumberOfWaves { get; set; } 
        [ValueElement(Keyword.NoiseGenerator)]
        public int? NoiseGenerator { get; set; }

        [Init]
        [Output]
        public RadiositySettings Radiosity { get; set; }
        
        [BlockElement(Keyword.Radiosity)]
        public class RadiositySettings : SceneItem, IRenderNotify
        {
            [ValueElement]
            protected string PresetOutput
            {
                get
                {
                    string name = null;
                    switch (this.Preset)
                    {
                        case RadiosityPreset.Bounce2:
                            name = "2Bounce";
                            break;
                        case RadiosityPreset.OutdoorLowQuality:
                            name = "OutdoorLQ";
                            break;
                        case RadiosityPreset.OutdoorHighQuality:
                            name = "OutdoorHQ";
                            break;
                        case RadiosityPreset.IndoorLowQuality:
                            name = "IndoorLQ";
                            break;
                        case RadiosityPreset.IndoorHighQuality:
                            name = "IndoorHQ";
                            break;
                        case RadiosityPreset.None:
                            break;
                        default:
                            name = this.Preset.ToString();
                            break;
                    }

                    return name == null
                        ? null
                        : string.Format("Rad_Settings(Radiosity_{0}, {1}, {2})",
                            name,
                            this.Normal == true ? "on" : "off",
                            this.Media == true ? "on" : "off");
                }
                
            }

            /// <summary>
            /// Presets for Rad_Settings macro in rad_def.inc.
            /// </summary>
            public RadiosityPreset Preset { get; set; } = RadiosityPreset.None;
            
            [ValueElement(Keyword.AdcBailout)]
            public Float AdcBailout { get;set;}  
            [ValueElement(Keyword.AlwaysSample, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
            public bool? AlwaysSample { get;set;}  
            [ValueElement(Keyword.Brightness)]
            public Float Brightness { get;set;}

            [ValueElement(Keyword.Count)]
            protected int?[] CountOutput => new int?[] {this.Count, this.CountTotal};
            public int? Count { get;set;} 
            public int? CountTotal { get;set;}
            
            [ValueElement(Keyword.ErrorBound)]
            public Float ErrorBound { get;set;}  
            [ValueElement(Keyword.GrayThreshold)]
            public Float GrayThreshold { get;set;}  
            [ValueElement(Keyword.LowErrorFactor)]
            public Float LowErrorFactor { get;set;}  
            [ValueElement(Keyword.MaxSample)]
            public Float MaxSample { get;set;}  
            [ValueElement(Keyword.Media, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
            public bool? Media { get;set;}  
            [ValueElement(Keyword.MaximumReuse)]
            public Float MaximumReuse { get;set;}  
            [ValueElement(Keyword.MinimumReuse)]
            public Float MinimumReuse { get;set;}  
            [ValueElement(Keyword.NearestCount)]
            public int? NearestCount { get;set;} 
            [ValueElement(Keyword.Normal, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
            public bool? Normal { get;set;}  
            [ValueElement(Keyword.PretraceStart)]
            public Float PretraceStart { get;set;}  
            [ValueElement(Keyword.PretraceEnd)]
            public Float PretraceEnd { get;set;}  
            [ValueElement(Keyword.RecursionLimit)]
            public int? RecursionLimit { get;set;}  
            [ValueElement(Keyword.Subsurface, TrueKeyword = Keyword.On, FalseKeyword = Keyword.Off)]
            public bool? Subsurface { get;set;}

            public void RenderNotify(ElementContext context)
            {
                if (this.Preset != RadiosityPreset.None)
                {
                    context.Scene.Include.RadDef = true;
                }
            }
        }
//        Subsurface { SUBSURFACE_ITEMS } 
//        Photon { PHOTON_ITEMS... }       
    }

    public enum RadiosityPreset
    {
        None = -1,
        Default = 0,
        Debug = 1,
        Fast = 2,
        Normal = 3,
        Bounce2 = 4,
        Final = 5,
        OutdoorLowQuality = 6,
        OutdoorHighQuality = 7,
        OutdoorLight = 8,
        IndoorLowQuality = 9,
        IndoorHighQuality = 10,        
    }
}