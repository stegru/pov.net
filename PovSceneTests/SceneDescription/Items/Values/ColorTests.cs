namespace PovSceneTests.SceneDescription.Items.Values
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.Libraries;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class ColorTests
    {
        public static List<(string name, Func<IValue> obj, string expect)> Tests =>
            new List<(string name, Func<IValue> obj, string expect)>
            {
                (
                    "rgb",
                    () => new Color(0.1, 0.2, 0.3),
                    @"rgb <0.1, 0.2, 0.3>"
                ),
                (
                    "rgbf",
                    () => new Color(0.1, 0.2, 0.3, 0.4),
                    @"rgbf <0.1, 0.2, 0.3, 0.4>"
                ),
                (
                    "rgbft",
                    () => new Color(0.1, 0.2, 0.3, 0.4, 0.5),
                    @"rgbft <0.1, 0.2, 0.3, 0.4, 0.5>"
                ),
                (
                    "identifier",
                    () => Colors.LimeGreen,
                    @"LimeGreen"
                ),
                (
                    "identifierModified",
                    () =>
                    {
                        Color c = Colors.LimeGreen;
                        c.Blue = 1;
                        c.Filter = 0.5;
                        return c;
                    },
                    @"LimeGreen blue 1 filter 0.5"
                ),
                (
                    "ctorFloat",
                    () => new Color(0.4),
                    @"rgb <0.4, 0.4, 0.4>"
                ),
                (
                    "castFloat",
                    () => (Color) 0.2,
                    @"rgbft <0.2, 0.2, 0.2, 0.2, 0.2>"
                ),
                (
                    "castTuple",
                    () => (Color) (0.1, 0.2, 0.3),
                    @"rgb <0.1, 0.2, 0.3>"
                ),
                (
                    "castTuple2",
                    () => (Color) (0.1, 0.2, 0.3, 0.4, 0.5),
                    @"rgbft <0.1, 0.2, 0.3, 0.4, 0.5>"
                ),
                (
                    "castVector",
                    () => (Color) new Vector(0.1, 0.2, 0.3),
                    @"rgb <0.1, 0.2, 0.3>"
                ),
                (
                    "rounding",
                    () => new Color(1 / 0.6, 12.3456789, 0.1),
                    @"rgb <1.667, 12.346, 0.1>"
                ),
                (
                    "htmlCode",
                    () => Color.FromString("#4080c0"),
                    @"rgb <0.25, 0.5, 0.75>"
                ),
                (
                    "htmlCode3",
                    () => Color.FromString("#09f"),
                    @"rgb <0, 0.6, 1>"
                ),
                (
                    "stringCast",
                    () => (Color) "#c08040",
                    @"rgb <0.75, 0.5, 0.25>"
                ),
                (
                    "multiply",
                    () => new Color(0.1, 1, -0.5) * 6,
                    @"rgb <0.6, 6, -3>"
                ),
                (
                    "multiply2",
                    () => 5 * new Color(1.5, 0.1, -0.5),
                    @"rgb <7.5, 0.5, -2.5>"
                ),
                (
                    "divide",
                    () => new Color(0.18, 100, -36) / 6,
                    @"rgb <0.03, 16.667, -6>"
                ),
                (
                    "divide2",
                    () => 5 / new Color(1.5, 0.1, -0.5),
                    @"rgb <0.3, 0.02, -0.1>"
                ),
                (
                    "divide-rgbf",
                    () => new Color(0.1, 0.2, 0.3, 0.4) / 5,
                    @"rgbf <0.02, 0.04, 0.06, 0.08>"
                ),
                (
                    "divide-rgbft",
                    () => new Color(0.1, 0.2, 0.3, 0.4, 0.5) / 5,
                    @"rgbft <0.02, 0.04, 0.06, 0.08, 0.1>"
                )
            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }

        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void ColorTest(string name, Func<IValue> elem, string expect)
        {
            TestHelpers.TestString(elem().ToString(), expect);
        }

    }
}