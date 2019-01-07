namespace PovSceneTests.SceneDescription.Items.Objects.ObjectModifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using Xunit;

    public class PigmentTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {

                (
                    "pigment",
                    () => new Pigment {QuickColor = (0.1, 0.2, 0.3)},
                    @"pigment { quick_color rgb <0.1, 0.2, 0.3> }"
                ),
                (
                    "solid",
                    () => new Pigment.Solid((0.1, 0.2, 0.3)),
                    @"pigment { color rgb <0.1, 0.2, 0.3> }"
                ),
                (
                    "color-cast",
                    () => (Pigment)(0.1, 0.2, 0.3),
                    @"pigment { color rgb <0.1, 0.2, 0.3> }"
                ),
                (
                    "patterned",
                    () => new Pigment.Patterned(new Pattern.Agate()),
                    @"pigment { agate }"
                ),
                (
                    "patterned-cast",
                    () => (Pigment)new Pattern.Agate(), 
                    @"pigment { agate }"
                ),
                (
                    "brick",
                    () => (Pigment)new Pattern.Brick((0.1, 0.2, 0.3), (0.4, 0.5, 0.6)),
                    @"
pigment {
  brick pigment { color rgb <0.1, 0.2, 0.3> },
  pigment { color rgb <0.4, 0.5, 0.6> }
}"
                ),
                (
                    "checker",
                    () => new Pigment.Patterned(new Pattern.Checker((0.1, 0.2, 0.3), (0.4, 0.5, 0.6))),
                    @"
pigment {
  checker pigment { color rgb <0.1, 0.2, 0.3> },
  pigment { color rgb <0.4, 0.5, 0.6> }
}"
                ),
                (
                    "hexagon",
                    () => (Pigment)new Pattern.Hexagon((0.1, 0.2, 0.3), (0.4, 0.5, 0.6), (0.7, 0.8, 0.9)),
                    @"
pigment {
  hexagon pigment { color rgb <0.1, 0.2, 0.3> },
  pigment { color rgb <0.4, 0.5, 0.6> },
  pigment { color rgb <0.7, 0.8, 0.9> }
}"
                ),
                (
                    "image",
                    () => new Pigment.Image("image-path.png"),
                    @"pigment { image_map { ""image-path.png""} }"
                )

            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void PigmentTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestElement(elem(), expect);
        }
    }
}