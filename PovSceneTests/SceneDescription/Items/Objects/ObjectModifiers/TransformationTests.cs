namespace PovSceneTests.SceneDescription.Items.Objects.ObjectModifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.Objects.Solid;
    using Xunit;

    public class TransformationTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "rotate",
                    () => new Rotate((1.2, 3.4, 5.6)),
                    @"rotate <1.2, 3.4, 5.6>"
                ),
                (
                    "scale",
                    () => new Scale((1.2, 3.4, 5.6)),
                    @"scale <1.2, 3.4, 5.6>"
                ),
                (
                    "scale2",
                    () => new Scale(1.23),
                    @"scale 1.23"
                ),
                (
                    "translate",
                    () => new Translate((1.2, 3.4, 5.6)),
                    @"translate <1.2, 3.4, 5.6>"
                ),
                (
                    "all",
                    () => new Sphere((1, 2, 3), 123)
                        .Rotate(4, 5, 6)
                        .Scale(7, 8, 9)
                        .Translate(10, 11, 12)
                        .Rotate((4, 5, 6))
                        .Scale((7, 8, 9))
                        .Translate((10, 11, 12))
                        .Scale(13),
                    @"
sphere {
  <1, 2, 3>, 123
  rotate <4, 5, 6>
  scale <7, 8, 9>
  translate <10, 11, 12>
  rotate <4, 5, 6>
  scale <7, 8, 9>
  translate <10, 11, 12>
  scale 13
}"
                )
            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void TransformationTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestElement(elem(), expect);
        }
    }
}