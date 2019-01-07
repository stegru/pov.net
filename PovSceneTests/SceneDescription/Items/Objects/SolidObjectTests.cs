namespace PovSceneTests.SceneDescription.Items.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.Libraries;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects;
    using PovScene.SceneDescription.Items.Objects.Solid;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class SolidObjectTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> ObjectTests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "blob",
                    obj: () => new Blob
                    {
                        {new Sphere((1, 2, 3), 4), 5},
                        {new Cylinder((6, 7, 8), (9, 10, 11), 12), 13},
                        {new Sphere((21, 22, 23), 24), 25},
                        {new Cylinder((26, 27, 28), (29, 210, 211), 212), 213}
                    },
                    expect: @"
blob {
  sphere { <1, 2, 3>, 4, 5 }
  cylinder { <6, 7, 8>, <9, 10, 11>, 12, 13 }
  sphere { <21, 22, 23>, 24, 25 }
  cylinder { <26, 27, 28>, <29, 210, 211>, 212, 213 }
$texture }"
                ),
                (
                    "box",
                    obj: () => new Box
                    {
                        Corner1 = (1, 2, 3),
                        Corner2 = (4, 5, 6)
                    },
                    expect: @"box { <1, 2, 3>, <4, 5, 6> $texture }"
                ),
                (
                    "cone",
                    obj: () => new Cone
                    {
                        Base = (1, 2, 3),
                        BaseRadius = 4,
                        Cap = (5, 6, 7),
                        CapRadius = 8
                    },
                    expect: @"cone {<1, 2, 3>, 4, <5, 6, 7>, 8 $texture }"
                ),
                (
                    "cylinder",
                    obj: () => new Cylinder
                    {
                        BasePoint = (1, 2, 3),
                        CapPoint = (4, 5, 6)
                    },
                    expect: @"cylinder { <1, 2, 3>, <4, 5, 6> $texture }"
                ),
                (
                    "cylinderClosed",
                    obj: () => new Cylinder
                    {
                        BasePoint = (1, 2, 3),
                        CapPoint = (4, 5, 6),
                        Open = false
                    },
                    expect: @"cylinder { <1, 2, 3>, <4, 5, 6> $texture }"
                ),
                (
                    "cylinderOpen",
                    obj: () => new Cylinder
                    {
                        BasePoint = (1, 2, 3),
                        CapPoint = (4, 5, 6),
                        Open = true
                    },
                    expect: @"cylinder { <1, 2, 3>, <4, 5, 6> open $texture }"
                ),
                (
                    "heightField",
                    obj: () => new HeightField
                    {
                        Image = new FileImage("filename.png")
                    },
                    expect: @"height_field { ""filename.png"" $texture }"
                ),
                (
                    "heightField-Hierarchy",
                    obj: () => new HeightField
                    {
                        Image = new FileImage("filename.png"),
                        Hierarchy = true
                    },
                    expect: @"height_field { ""filename.png"" hierarchy on $texture }"
                ),
                (
                    "heightField-Smooth",
                    obj: () => new HeightField
                    {
                        Image = new FileImage("filename.png"),
                        Smooth = true
                    },
                    expect: @"height_field { ""filename.png"" smooth $texture }"
                ),
                (
                    "heightField-WaterLevel",
                    obj: () => new HeightField
                    {
                        Image = new FileImage("filename.png"),
                        WaterLevel = 5.6
                    },
                    expect: @"height_field { ""filename.png"" water_level 5.6 $texture }"
                ),
                (
                    "isosurface",
                    obj: () =>  new Isosurface
                    {
                        Accuracy = 1.23,
                        ContainedBy = new Sphere((1,2,3),4),
                        AllIntersections = true,
                        EvaluateP0 = 1.2,
                        EvaluateP1 = 2.3,
                        EvaluateP2 = 3.4,
                        Function = "5+6*7",
                        MaxGradient = 8.9,
                        MaxTrace = 10,
                        Open = true,
                        Polarity = true,
                        Threshold = 1.2
                    },
                    expect: @"
isosurface {
  function { 5+6*7 }
  contained_by { sphere { <1, 2, 3>, 4 } }
  threshold 1.2
  accuracy 1.23
  max_gradient 8.9
  evaluate 1.2,2.3,3.4
  open
  all_intersections
  max_trace 10
  $texture
}"
                ),
                (
                    "plane",
                    obj: () => new Plane
                    {
                        Distance = 1.23,
                        Axis = Vector.X
                    },
                    expect: @"plane { x, 1.23 $texture }"
                ),
                (
                    "sphere",
                    obj: () => new Sphere
                    {
                        Center = (11, 22, 33),
                        Radius = 44
                    },
                    expect: @"sphere { <11, 22, 33>, 44 $texture }"
                ),
                (
                    "text",
                    obj: () => new TextObject
                    {
                        FontName = "font-name",
                        Offset = (1, 2, 3),
                        Text = "sample-text",
                        Thickness = 1.23
                    },
                    expect: @"text { ttf ""font-name"" ""sample-text"" 1.23, <1, 2, 3> $texture }"
                ),
                (
                    "torus",
                    obj: () => new Torus
                    {
                        MajorRadius = 10,
                        MinorRadius = 5,
                        Sturm = true
                    },
                    expect: @"torus { 10, 5 sturm $texture }"
                )
            };

        public static List<(string name, Func<SceneElement> obj, string expect)> CsgTests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "union",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) + new Sphere((6, 7, 8), 9),
                    expect: @"
union {
  box { <0, 1, 2>, <3, 4, 5> }
  sphere { <6, 7, 8>, 9 }
}"
                ),
                (
                    "difference",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) - new Sphere((6, 7, 8), 9),
                    expect: @"
difference {
  box { <0, 1, 2>, <3, 4, 5> }
  sphere { <6, 7, 8>, 9 }
}"
                ),
                (
                    "intersection",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) & new Sphere((6, 7, 8), 9),
                    expect: @"
intersection {
  box { <0, 1, 2>, <3, 4, 5> }
  sphere { <6, 7, 8>, 9 }
}"
                ),
                (
                    "merge",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) | new Sphere((6, 7, 8), 9),
                    expect: @"
merge {
  box { <0, 1, 2>, <3, 4, 5> }
  sphere { <6, 7, 8>, 9 }
}"
                ),
                (
                    "union2",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) + new Sphere((6, 7, 8), 9) +
                          new Box((10, 11, 12), (13, 14, 15)),
                    expect: @"
union {
  union {
    box { <0, 1, 2>, <3, 4, 5> }
    sphere { <6, 7, 8>, 9 }
  }
  box { <10, 11, 12>, <13, 14, 15> }
}"
                ),
                (
                    "difference2",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) - new Sphere((6, 7, 8), 9) -
                          new Box((10, 11, 12), (13, 14, 15)),
                    expect: @"
difference {
  difference {
    box { <0, 1, 2>, <3, 4, 5> }
    sphere { <6, 7, 8>, 9 }
  }
  box { <10, 11, 12>, <13, 14, 15> }
}"
                ),
                (
                    "intersection2",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) & new Sphere((6, 7, 8), 9) &
                          new Box((10, 11, 12), (13, 14, 15)),
                    expect: @"
intersection {
  intersection {
    box { <0, 1, 2>, <3, 4, 5> }
    sphere { <6, 7, 8>, 9 }
  }
  box { <10, 11, 12>, <13, 14, 15> }
}"
                ),
                (
                    "merge2",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) | new Sphere((6, 7, 8), 9) |
                          new Box((10, 11, 12), (13, 14, 15)),
                    expect: @"
merge {
  merge {
    box { <0, 1, 2>, <3, 4, 5> }
    sphere { <6, 7, 8>, 9 }
  }
  box { <10, 11, 12>, <13, 14, 15> }
}"
                ),
                (
                    "several",
                    obj: () => new Box((0, 1, 2), (3, 4, 5)) | new Sphere((6, 7, 8), 9)
                          & new Box((10, 11, 12), (13, 14, 15)) - new Sphere((16, 17, 18), 19)

                          & new Box((20, 21, 22), (23, 24, 25)) + new Sphere((26, 27, 28), 29),
                    expect: @"
merge {
  box { <0, 1, 2>, <3, 4, 5> }
  intersection {
    intersection {
      sphere { <6, 7, 8>, 9 }
      difference {
        box { <10, 11, 12>, <13, 14, 15> }
        sphere { <16, 17, 18>, 19 }
      }
    }
    union {
      box { <20, 21, 22>, <23, 24, 25> }
      sphere { <26, 27, 28>, 29 }
    }
  }
}"
                ),
                (
                    "csgTexture1",
                    obj: () =>  new Box((0, 1, 2), (3, 4, 5)) {Texture = Library.Textures.BrassMetal} |
                          new Sphere((6, 7, 8), 9) {Texture = Library.Textures.CandyCane},
                    expect: @"
merge {
  box {
    <0, 1, 2>, <3, 4, 5>
    texture { Brass_Metal }
  }
  sphere {
    <6, 7, 8>, 9
    texture { Candy_Cane }
  }
}"
                ),
                (
                    "csgTexture2",
                    obj: () =>
                    {
                        var obj = new Box((0, 1, 2), (3, 4, 5)) | new Sphere((6, 7, 8), 9);
                        obj.Texture = Library.Textures.Jade;
                        return obj;

                    },
                    expect: @"
merge {
  box { <0, 1, 2>, <3, 4, 5> }
  sphere { <6, 7, 8>, 9 }
  texture { Jade }
}"
                ),
                (
                    "csgTexture3",
                    obj: () =>
                    {
                        var obj = new Box((0, 1, 2), (3, 4, 5)) {Texture = Library.Textures.BrassMetal} |
                                          new Sphere((6, 7, 8), 9) {Texture = Library.Textures.CandyCane};
                        obj.Texture = Library.Textures.Jade;
                        return obj;
                    },

                    expect: @"
merge {
  box {
    <0, 1, 2>, <3, 4, 5>
    texture { Brass_Metal }
  }
  sphere {
    <6, 7, 8>, 9
    texture { Candy_Cane }
  }
  texture { Jade }
}"
                )
            };

        public static IEnumerable<object[]> GetObjectTests(object n)
        {
            return ObjectTests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        public static IEnumerable<object[]> GetCsgTests(object n)
        {
            return CsgTests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetObjectTests), null)]
        public void ObjectsTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestSceneObject((SceneObject)elem(), expect);
            
        }
        
        [Theory]
        [MemberData(nameof(GetCsgTests), null)]
        public void CsgTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestSceneObject((SceneObject)elem(), expect);
        }

    }
}
