namespace PovSceneTests.SceneDescription.Items.Values
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class FloatTests
    {
        public static List<(string name, Func<IValue> obj, string expect)> Tests =>
            new List<(string name, Func<IValue> obj, string expect)>
            {
                (
                    "float",
                    () => new Float(123),
                    @"123"
                ),
                (
                    "round",
                    () => new Float(0.12345),
                    @"0.12345"
                ),
                (
                    "cast",
                    () => (Float) 123,
                    @"123"
                ),
                (
                    "castDouble",
                    () => (Float) (double) 2,
                    @"2"
                ),
                (
                    "zero",
                    () => Float.Zero,
                    @"0"
                ),
                (
                    "neg",
                    () => -(Float)123.45,
                    @"-123.45"
                ),
                (
                    "plus",
                    () => (Float) 1 + 3,
                    @"4"
                ),
                (
                    "minus",
                    () => (Float) 2 - 1,
                    @"1"
                ),
                (
                    "multiply",
                    () => (Float) 2 * 3,
                    @"6"
                ),
                (
                    "divide",
                    () => (Float) 10 / 4,
                    @"2.5"
                ),
            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }

        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void FloatTest(string name, Func<IValue> elem, string expect)
        {
            TestHelpers.TestString(elem().ToString(), expect);
        }

    }
}