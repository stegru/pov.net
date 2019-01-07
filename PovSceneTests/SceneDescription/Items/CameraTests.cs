namespace PovSceneTests.SceneDescription.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class CameraTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "camera",
                    obj: () => new Camera((0, 1, 2)),
                    expect: @"camera { location <0,1,2> look_at <0,0,0> }"
                ),
                (
                    "camera-lookat",
                    obj: () => new Camera((0, 1, 2), (3, 4, 5)),
                    expect: @"camera { location <0,1,2> look_at <3,4,5> }"
                ),
                (
                    "camera-angle-horz",
                    obj: () => new Camera((0, 1, 2), (3, 4, 5))
                    {
                        AngleHorizontal = 1.23
                    },
                    expect: @"camera { location <0,1,2> look_at <3,4,5> angle 1.23 }"
                ),
                (
                    "camera-angle-vert",
                    obj: () => new Camera((0, 1, 2), (3, 4, 5))
                    {
                        AngleVertical = 1.23
                    },
                    expect: @"camera { location <0,1,2> look_at <3,4,5> angle 0 1.23 }"
                ),
                (
                    "camera-angle-both",
                    obj: () => new Camera((0, 1, 2), (3, 4, 5))
                    {
                        AngleHorizontal = 1.23,
                        AngleVertical = 4.56
                    },
                    expect: @"camera { location <0,1,2> look_at <3,4,5> angle 1.23 4.56 }"
                ),
                (
                    "camera-all",
                    obj: () => new Camera((0, 1, 2), (3, 4, 5))
                    {
                        AngleHorizontal = 1.23,
                        AngleVertical = 4.56,
                        BlurSamples = 7,
                        BlurSamplesMin = 8,
                        CameraType = Keyword.Perspective,
                        Confidence = 9.1,
                        FocalPoint = (10, 11, 12),
                        Right = Vector.X,
                        Up = Vector.Y,
                        Sky = Vector.Z,
                        Variance = 13.14
                    },
                    expect: @"
camera {
  perspective
  location <0, 1, 2>
  look_at <3, 4, 5>
  angle 1.23 4.56
  right x
  up y
  confidence 9.1
  focal_point <10, 11, 12>
  sky z
  variance 13.14
  blur_samples 8,7
}"
                ),
                (
                    "camera-alternative",
                    obj: () => new Camera((0, 1, 2), (3, 4, 5))
                    {
                        CameraType = Keyword.Panoramic,
                        Right = (1,0,0),
                        Up = (0,1,0),
                        Sky = (0,0,1)
                    },
                    expect: @"
camera {
  panoramic
  location <0, 1, 2>
  look_at <3, 4, 5>
  right x
  up y
  sky z
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