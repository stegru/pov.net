namespace PovSceneTests.SceneDescription.Items.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects;
    using PovScene.SceneDescription.Items.Objects.Patch;
    using PovScene.SceneDescription.Items.Objects.Solid;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class PatchObjectTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> FiniteObjectTests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "triangle",
                    obj: () => new Triangle((0, 0, 0), (-1, 1, 0), (1, 1, 0)),
                    expect: @"triangle { <0, 0, 0>, <-1, 1, 0>, <1, 1, 0> }"
                ),
                (
                    "disc",
                    obj: () => new Disc((1, 2, 3), Vector.Y, 4),
                    expect: @"disc { <1, 2, 3>, y, 4 }"
                ),
                (
                    "disc2",
                    obj: () => new Disc((1, 2, 3), -Vector.Z, 4, 0.5),
                    expect: @"disc { <1, 2, 3>, -z, 4, 0.5 }"
                ),
            };

  
        public static IEnumerable<object[]> GetFiniteObjectTests(object n)
        {
            return FiniteObjectTests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetFiniteObjectTests), null)]
        public void ObjectsTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestSceneObject((SceneObject)elem(), expect);
            
        }

    }
}
