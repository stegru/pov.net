namespace PovSceneTests.SceneDescription.Items.Objects.ObjectModifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using Xunit;

    public class NormalTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {

                (
                    "normal",
                    () => new Normal {BumpMap = new BumpMap()},
                    @""
                ),
                (
                    "patterned",
                    () => new Normal.Patterned(new Pattern.Agate()),
                    @"normal { agate }"
                ),
                (
                    "patterned-cast",
                    () => (Normal)new Pattern.Agate(),
                    @"normal { agate }"
                ),
                (
                    "brick",
                    () => (Normal)new Pattern.Brick(
                        new Normal.Patterned(new Pattern.Agate()),
                        new Normal.Patterned(new Pattern.Bozo())),
                    @"
normal {
  brick normal { agate },
  normal { bozo }
}"
                ),
                (
                    "checker",
                    () => new Normal.Patterned(new Pattern.Checker(
                        new Normal.Patterned(new Pattern.Agate()),
                        new Normal.Patterned(new Pattern.Bozo()))),
                    @"
normal {
  checker normal { agate },
  normal { bozo }
}"
                ),
                (
                    "hexagon",
                    () => (Normal)new Pattern.Hexagon(
                        new Normal.Patterned(new Pattern.Agate()),
                        new Normal.Patterned(new Pattern.Bozo()),
                        new Normal.Patterned(new Pattern.Dents())),
                    @"
normal {
  hexagon normal { agate },
  normal { bozo },
  normal { dents }
}"
                )
            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void NormalTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestElement(elem(), expect);
        }
    }
}