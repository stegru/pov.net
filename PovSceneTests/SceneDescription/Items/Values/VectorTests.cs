namespace PovSceneTests.SceneDescription.Items.Values
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class VectorTests
    {
        public static List<(string name, Func<IValue> obj, string expect)> Tests =>
            new List<(string name, Func<IValue> obj, string expect)>
            {
                (
                    "vector",
                    () => new Vector(1, 2, 3),
                    @"<1, 2, 3>"
                ),
                (
                    "single",
                    () => new Vector(1),
                    @"<1, 1, 1>"
                ),
                (
                    "round",
                    () => new Vector(0.12345, 1 / 3.0, 0.1),
                    @"<0.12345, 0.333333333333333, 0.1>"
                ),
                (
                    "cast",
                    () => (Vector) (1, 2, 3),
                    @"<1, 2, 3>"
                ),
                (
                    "castFloat",
                    () => (Vector) (Float) 2,
                    @"<2, 2, 2>"
                ),
                (
                    "castDouble",
                    () => (Vector) (double) 2,
                    @"<2, 2, 2>"
                ),
                (
                    "x",
                    () => Vector.X,
                    @"x"
                ),
                (
                    "y",
                    () => Vector.Y,
                    @"y"
                ),
                (
                    "z",
                    () => Vector.Z,
                    @"z"
                ),
                (
                    "neg",
                    () => -new Vector(1, 2, 3),
                    @"<-1, -2, -3>"
                ),
                (
                    "negX",
                    () => -Vector.X,
                    @"-x"
                ),
                (
                    "negY",
                    () => -Vector.Y,
                    @"-y"
                ),
                (
                    "negZ",
                    () => -Vector.Z,
                    @"-z"
                ),
                (
                    "plus",
                    () => (Vector) (1, 2, 3) + (4, 5, 6),
                    @"<5, 7, 9>"
                ),
                (
                    "minus",
                    () => (Vector) (1, 2, 3) - (4, 5, 6),
                    @"<-3, -3, -3>"
                ),
                (
                    "multiply",
                    () => (Vector) (1, 2, 3) * (4, 5, 6),
                    @"<4, 10, 18>"
                ),
                (
                    "divide",
                    () => (Vector) (10, 20, 30) / (4, 5, 6),
                    @"<2.5, 4, 5>"
                ),
                (
                    "plusFloat",
                    () => (Vector) (1, 2, 3) + 4,
                    @"<5, 6, 7>"
                ),
                (
                    "minusFloat",
                    () => (Vector) (1, 2, 3) - 4,
                    @"<-3, -2, -1>"
                ),
                (
                    "multiplyFloat",
                    () => (Vector) (1, 2, 3) * 4,
                    @"<4, 8, 12>"
                ),
                (
                    "divideFloat",
                    () => (Vector) (10, 20, 30) / 4,
                    @"<2.5, 5, 7.5>"
                )
            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }

        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void VectorTest(string name, Func<IValue> elem, string expect)
        {
            TestHelpers.TestString(elem().ToString(), expect);
        }

    }
}