namespace PovSceneTests.SceneDescription.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using Xunit;

    public class GlobalSettingsTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "globalSettings",
                    obj: () => new GlobalSettings(),
                    expect: @"global_settings { assumed_gamma 1 }"),
                (
                    "globalSettingsAll",
                    obj: () => new GlobalSettings
                    {
                        AdcBailout = 1.2,
                        AmbientLight = (0.3, 0.4, 0.5),
                        AssumedGamma = 6.7,
                        CharsetUnicode = true,
                        IridWavelength = (0.8, 0.9, 1),
                        MaxIntersections = 11,
                        MaxTraceLevel = 12,
                        MmPerUnit = 13,
                        NoiseGenerator = 14,
                        NumberOfWaves = 15,
                        Radiosity =
                        {
                            AdcBailout = 1.6,
                            AlwaysSample = true,
                            Brightness = 1.7,
                            Count = 18,
                            CountTotal = 19,
                            ErrorBound = 2.0,
                            GrayThreshold = 2.1,
                            LowErrorFactor = 2.2,
                            MaximumReuse = 2.3,
                            MaxSample = 2.4,
                            Media = true,
                            MinimumReuse = 2.5,
                            NearestCount = 26,
                            Normal = true,
                            PretraceEnd = 2.7,
                            PretraceStart = 2.8,
                            RecursionLimit = 29,
                            Subsurface = true
                        }
                    },
                    expect: @"
global_settings {
  
  adc_bailout 1.2
  ambient_light rgb <0.3, 0.4, 0.5>
  assumed_gamma 6.7
  irid_wavelength rgb <0.8, 0.9, 1>
  charset utf8
  max_intersections 11
  max_trace_level 12
  mm_per_unit 13
  number_of_waves 15
  noise_generator 14
  radiosity {
    adc_bailout 1.6
    always_sample on
    brightness 1.7
    error_bound 2
    gray_threshold 2.1
    low_error_factor 2.2
    max_sample 2.4
    media on
    maximum_reuse 2.3
    minimum_reuse 2.5
    nearest_count 26
    normal on
    pretrace_start 2.8
    pretrace_end 2.7
    recursion_limit 29
    subsurface on
  }
}")


            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void GlobalSettingTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestSceneItem((SceneItem)elem(), expect);
        }
    }
}