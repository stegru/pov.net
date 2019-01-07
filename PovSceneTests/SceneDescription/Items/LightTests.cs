namespace PovSceneTests.SceneDescription.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.Lights;
    using Xunit;

    public class LightTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {

                (
                    "light",
                    obj: () => new LightSource((1, 2, 3)),
                    expect: @"light_source { <1, 2, 3>, White }"),
                (
                    "lightAll",
                    obj: () => new LightSource((1, 2, 3))
                    {
                        Color = (4, 5, 6),
                        FadeDistance = 7.8,
                        FadePower = 9.1,
                        MediaAttenuation = 10.11,
                        MediaInteraction = 12.13,
                        Parallel = true,
                        Shadowless = true
                    },
                    expect: @"
light_source {
  <1, 2, 3>, rgb <4, 5, 6>
  parallel
  shadowless
  fade_distance 7.8
  fade_power 9.1
  media_attenuation 10.11
  media_interaction 12.13
}"),
                (
                    "area",
                    obj: () => new LightSource.Area((1, 2, 3)),
                    expect: @"light_source { <1, 2, 3>, White adaptive 0 }"),
                (
                    "areaAll",
                    obj: () => new LightSource.Area((1, 2, 3))
                    {
                        Axis1 = (4, 5, 6),
                        Axis2 = (7, 8, 9),
                        Color = (10, 11, 12),
                        FadeDistance = 13.14,
                        FadePower = 15.16,
                        MediaAttenuation = 17.18,
                        MediaInteraction = 19.2,
                        Parallel = true,
                        Shadowless = true,
                        Size1 = 21.22,
                        Size2 = 23.24,
                        Adaptive = 25,
                        Jitter = true,
                        Circular = true,
                        Orient = true
                    },
                    expect: @"
light_source {
  <1, 2, 3>, rgb <10, 11, 12>,
  <4, 5, 6>, <7, 8, 9>,
  <21.22, 21.22, 21.22>, <23.24, 23.24, 23.24>
  parallel
  shadowless
  fade_distance 13.14
  fade_power 15.16
  media_attenuation 17.18
  media_interaction 19.2
  adaptive 25
  jitter
  circular
  orient
}"),
                (
                    "spotlight",
                    obj: () => new LightSource.Spotlight((1, 2, 3), (4, 5, 6))
                    {
                        Color = (0.1, 0.2, 0.3),
                        Radius = 7.8,
                        FadeDistance = 9.1,
                        Tightness = 11.12
                    },
                    expect: @"
light_source {
  <1, 2, 3>, rgb <0.1, 0.2, 0.3>
  spotlight
  fade_distance 9.1
  radius 7.8
  tightness 11.12
  point_at <4, 5, 6>
}"),
                (
                    "cylinder",
                    obj: () => new LightSource.Cylinder((1, 2, 3), (4, 5, 6))
                    {
                        Color = (0.1, 0.2, 0.3),
                        Radius = 7.8,
                        FadeDistance = 9.1,
                        Tightness = 11.12
                    },
                    expect: @"
light_source {
  <1, 2, 3>, rgb <0.1, 0.2, 0.3>
  cylinder
  radius 7.8
  tightness 11.12
  point_at <4, 5, 6>
  fade_distance 9.1
}")
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