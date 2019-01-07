namespace PovSceneTests.SceneDescription.Items.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects;
    using PovScene.SceneDescription.Items.Objects.Atmospheric;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class AtmosphericObjectTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "skysphere",
                    obj: () => new SkySphere
                    {
                        Emission = (0.1, 0.2, 0.3),
                        Pigment = new Pigment.Solid((0.1, 0.2, 0.3))
                    },
                    expect: @"sky_sphere { emission rgb <0.1,0.2,0.3> pigment { color rgb <0.1, 0.2, 0.3> }}"
                    
                ),
                (
                    "fog",
                    obj: () => new Fog(),
                    expect: @"fog { fog_type 1 }"
                ),
                (
                    "fog-ground",
                    obj: () => new Fog
                    {
                        GroundFog = true
                    },
                    expect: @"fog { fog_type 2 }"
                ),
                (
                    "fog-alternative-value",
                    obj: () => new Fog
                    {
                        Turbulence = 1.23,
                        Up = Vector.Y
                    },
                    expect: @"fog { fog_type 1 turbulence 1.23 up y }"
                ),
                (
                    "fog-all",
                    obj: () => new Fog
                    {
                        Color = (0,1,2),
                        Distance = 4.5,
                        FogAlt = 6.7,
                        FogOffset = 8.9,
                        Lambda = 10.11,
                        Octaves = 12.13,
                        Turb_depth = 14.15,
                        Turbulence = (16.1, 17.2, 18.3),
                        Up = (11, 22, 33)
                    },
                    expect: @"
fog {
  fog_type 1
  distance 4.5
  color rgb <0, 1, 2>
  turbulence <16.1, 17.2, 18.3>
  turb_depth 14.15
  lambda 10.11
  octaves 12.13
  fog_offset 8.9
  fog_alt 6.7
  up <11, 22, 33>
}"
                ),
            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void ObjectsTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestSceneItem((SceneItem)elem(), expect);
        }

    }
}