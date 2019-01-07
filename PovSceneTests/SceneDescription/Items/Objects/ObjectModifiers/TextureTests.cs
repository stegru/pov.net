namespace PovSceneTests.SceneDescription.Items.Objects.ObjectModifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class TextureTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "pigment",
                    () => new Pigment.Solid((0.1, 0.2, 0.3)),
                    @"pigment { color rgb <0.1, 0.2, 0.3> }"
                ),
                (
                    "normal",
                    () => new Normal.Patterned
                    {
                        Pattern = new Pattern.Agate()
                    },
                    @"normal { agate }"
                ),
                (
                    "finish",
                    () => new Finish
                    {
                        Diffuse = 0.1
                    },
                    @"finish { diffuse 0.1 }"
                ),
                (
                    "texture",
                    () => new Texture
                    {
                        Pigment = new Pigment.Solid((0.1, 0.2, 0.3)),
                        Normal = new Normal.Patterned
                        {
                            Pattern = new Pattern.Agate()
                        },
                        Finish =
                        {
                            ConserveEnergy = true,
                            Specular = 0.1
                        }
                    },
                    @"
texture {
  pigment { color rgb <0.1, 0.2, 0.3> }
  normal { agate }
  finish { specular 0.1 conserve_energy }
}"
                ),
                (
                    "pigment-transformed",
                    () => new Pigment.Patterned(new Pattern.Agate()).Scale(1, 2, 3).Rotate(45),
                    @"
pigment {
  agate
  scale <1, 2, 3>
  rotate <45, 0, 0>
}"
                ),
                (
                    "normal-transformed",
                    () => new Normal.Patterned(new Pattern.Agate()).Scale(1, 2, 3).Rotate(45),
                    @"
normal {
  agate
  scale <1, 2, 3>
  rotate <45, 0, 0>
}"
                ),
                (
                    "texture-transformed",
                    () => new Texture
                    {
                        Pigment = new Pigment.Solid((0.1, 0.2, 0.3)),
                        Normal = new Normal.Patterned
                        {
                            Pattern = new Pattern.Agate()
                        },
                        Finish =
                        {
                            ConserveEnergy = true,
                            Specular = 0.1
                        }
                    }.Scale(1, 2, 3).Rotate(45),
                    @"
texture {
  pigment { color rgb <0.1, 0.2, 0.3> }
  
  normal { agate }
  
  finish {
    specular 0.1
    conserve_energy
  }
  
  scale <1, 2, 3>
  rotate <45, 0, 0>
}"
                ),
                (
                    "textureTransformed2",
                    () => new Texture
                    {
                        Pigment = new Pigment.Solid((0.1, 0.2, 0.3)).Scale(4, 5, 6).Rotate(7, 8, 9),
                        Normal = new Normal.Patterned
                        {
                            Pattern = new Pattern.Agate()
                        }.Scale(9, 10, 11).Rotate(12, 13, 14),
                        Finish =
                        {
                            ConserveEnergy = true,
                            Specular = 0.1
                        }
                    }.Scale(1, 2, 3).Rotate(4, 5, 6),
                    @"
texture {
  pigment {
    color rgb <0.1, 0.2, 0.3>
    scale <4, 5, 6>
    rotate <7, 8, 9>
  }
  
  normal {
    agate
    scale <9, 10, 11>
    rotate <12, 13, 14>
  }
  
  finish {
    specular 0.1
    conserve_energy
  }
  
  scale <1, 2, 3>
  rotate <4, 5, 6>
}"
                ),
                (
                    "textureLayered",
                    () => new LayeredTexture
                    {
                        new Texture
                        {
                            Pigment = new Pattern.Bozo(),
                            Finish =
                            {
                                Diffuse = 1.23
                            }
                        },
                        new Texture
                        {
                            Pigment = new Pattern.Gradient(Vector.Y),
                            Normal = new Pattern.Dents()
                        },
                        new Texture("TextureIdentifier")
                    },
                    @"
texture {
pigment { bozo }
finish { diffuse 1.23 }
}
texture {
pigment { gradient y }
normal { dents }
}
texture { TextureIdentifier }
"
                ),
                (
                    "textureLayeredParams",
                    () => new LayeredTexture(
                        new Texture
                        {
                            Pigment = new Pattern.Bozo(),
                            Finish =
                            {
                                Diffuse = 1.23
                            }
                        },
                        new Texture
                        {
                            Pigment = new Pattern.Gradient(Vector.Y),
                            Normal = new Pattern.Dents()
                        },
                        new Texture("TextureIdentifier")
                    ),
                    @"
texture {
pigment { bozo }
finish { diffuse 1.23 }
}
texture {
pigment { gradient y }
normal { dents }
}
texture { TextureIdentifier }
"
                ),
                (
                    "textureLayeredAdd",
                    () => new Texture
                    {
                        Pigment = new Pattern.Bozo(),
                        Finish =
                        {
                            Diffuse = 1.23
                        }
                    } + new Texture
                    {
                        Pigment = new Pattern.Gradient(Vector.Y),
                        Normal = new Pattern.Dents()
                    } + new Texture("TextureIdentifier"),
                    @"
texture {
pigment { bozo }
finish { diffuse 1.23 }
}
texture {
pigment { gradient y }
normal { dents }
}
texture { TextureIdentifier }
"
                ),
                (
                    "textureLayeredTransform",
                    () => new LayeredTexture
                        {
                            new Texture
                            {
                                Pigment = new Pattern.Bozo(),
                                Finish =
                                {
                                    Diffuse = 1.23
                                }
                            }.Rotate(1, 2, 3).Scale(123),
                            new Texture
                            {
                                Pigment = new Pattern.Gradient(Vector.Y),
                                Normal = new Pattern.Dents()
                            }.Scale(4),
                            new Texture("TextureIdentifier").Translate(5, 6, 7)
                        }
                        .Rotate(8, 9, 10)
                        .Scale(11, 12, 13)
                        .Translate(14, 15, 16),
                    @"
  texture {
    pigment { bozo }
    finish { diffuse 1.23 }
    rotate <1, 2, 3>
    scale 123
    rotate <8, 9, 10>
    scale <11, 12, 13>
    translate <14, 15, 16>
  }
  texture {
    pigment { gradient y }
    normal { dents }
    scale 4
    rotate <8, 9, 10>
    scale <11, 12, 13>
    translate <14, 15, 16>
  }
  texture {
    TextureIdentifier
    translate <5, 6, 7>
    rotate <8, 9, 10>
    scale <11, 12, 13>
    translate <14, 15, 16>
  }
"
                )
            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void TextureTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestElement(elem(), expect);
        }

        [Fact]
        public void LayeredTextureBasic()
        {
            
        }
    }
}