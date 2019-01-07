namespace PovSceneTests.SceneDescription.Items.Objects.ObjectModifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Values;
    using Xunit;

    public class PatternTests
    {
        public static List<(string name, Func<SceneElement> obj, string expect)> Tests =>
            new List<(string name, Func<SceneElement> obj, string expect)>
            {
                (
                    "agate",
                    () => new Pattern.Agate(1.23),
                    @"agate agate_turb 1.23"
                ),
                (
                    "gradient",
                    () => new Pattern.Gradient(Vector.Y),
                    @"gradient y"
                ),
                (
                    "tiling",
                    () => new Pattern.Tiling(2),
                    @"tiling 2"
                ),
                (
                    "boxed",
                    () => new Pattern.Boxed(),
                    @"boxed"
                ),
                (
                    "bozo",
                    () => new Pattern.Bozo(),
                    @"bozo"
                ),
                (
                    "bumps",
                    () => new Pattern.Bumps(1),
                    @"bumps 1"
                ),
                (
                    "cells",
                    () => new Pattern.Cells(),
                    @"cells"
                ),
                (
                    "cylindrical",
                    () => new Pattern.Cylindrical(),
                    @"cylindrical"
                ),
                (
                    "dents",
                    () => new Pattern.Dents(),
                    @"dents"
                ),
                (
                    "mandel",
                    () => new Pattern.Mandel(),
                    @"mandel"
                ),
                (
                    "julia",
                    () => new Pattern.Julia(),
                    @"julia"
                ),
                (
                    "magnet",
                    () => new Pattern.Magnet(),
                    @"magnet"
                ),
                (
                    "function",
                    () => new Pattern.FunctionPattern(),
                    @"function"
                ),
                (
                    "granite",
                    () => new Pattern.Granite(),
                    @"granite"
                ),
                (
                    "leopard",
                    () => new Pattern.Leopard(),
                    @"leopard"
                ),
                (
                    "marble",
                    () => new Pattern.Marble(),
                    @"marble"
                ),
                (
                    "onion",
                    () => new Pattern.Onion(),
                    @"onion"
                ),
                (
                    "planar",
                    () => new Pattern.Planar(),
                    @"planar"
                ),
                (
                    "potential",
                    () => new Pattern.Potential(),
                    @"potential"
                ),
                (
                    "quilted",
                    () => new Pattern.Quilted(),
                    @"quilted"
                ),
                (
                    "radial",
                    () => new Pattern.Radial(),
                    @"radial"
                ),
                (
                    "ripples",
                    () => new Pattern.Ripples(1,2),
                    @"
ripples
frequency 1
phase 2"
                ),
                (
                    "spherical",
                    () => new Pattern.Spherical(),
                    @"spherical"
                ),
                (
                    "spiral1",
                    () => new Pattern.Spiral1(1,2),
                    @"spiral1 1 2"
                ),
                (
                    "spiral2",
                    () => new Pattern.Spiral2(1,2),
                    @"spiral2 1 2"
                ),
                (
                    "spotted",
                    () => new Pattern.Spotted(),
                    @"spotted"
                ),
                (
                    "waves",
                    () => new Pattern.Waves(),
                    @"waves"
                ),
                (
                    "wood",
                    () => new Pattern.Wood(),
                    @"wood"
                ),
                (
                    "wrinkles",
                    () => new Pattern.Wrinkles(),
                    @"wrinkles"
                ),
                (
                    "facets",
                    () => new Pattern.Facets(),
                    @"facets"
                ),
                (
                    "brick",
                    () => new Pattern.Brick((0.1, 0.2, 0.3), (0.4, 0.5, 0.6)),
                    @"
brick pigment { color rgb <0.1, 0.2, 0.3> },
pigment { color rgb <0.4, 0.5, 0.6> }"
                ),
                (
                    "checker",
                    () => new Pattern.Checker((0.1, 0.2, 0.3), (0.4, 0.5, 0.6)),
                    @"
checker pigment { color rgb <0.1, 0.2, 0.3> },
pigment { color rgb <0.4, 0.5, 0.6> }"
                ),
                (
                    "hexagon",
                    () => new Pattern.Hexagon((0.1, 0.2, 0.3), (0.4, 0.5, 0.6), (0.7, 0.8, 0.9)),
                    @"
hexagon pigment { color rgb <0.1, 0.2, 0.3> },
pigment { color rgb <0.4, 0.5, 0.6> },
pigment { color rgb <0.7, 0.8, 0.9> }"
                ),
                (
                    "cubic",
                    () => new Pattern.Cubic((0.1, 0.2, 0.3), (0.4, 0.5, 0.6), (0.7, 0.8, 0.9), (1.1, 1.2, 1.3),
                        (1.4, 1.5, 1.6), (1.7, 1.8, 1.9)),
                    @"
cubic pigment { color rgb <0.1, 0.2, 0.3> },
pigment { color rgb <0.4, 0.5, 0.6> },
pigment { color rgb <0.7, 0.8, 0.9> },
pigment { color rgb <1.1, 1.2, 1.3> },
pigment { color rgb <1.4, 1.5, 1.6> },
pigment { color rgb <1.7, 1.8, 1.9> }"
                ),
                (
                    "square",
                    () => new Pattern.Square((0.1, 0.2, 0.3), (0.4, 0.5, 0.6), (0.7, 0.8, 0.9),
                        (1.1, 1.2, 1.3)),
                    @"
square pigment { color rgb <0.1, 0.2, 0.3> },
pigment { color rgb <0.4, 0.5, 0.6> },
pigment { color rgb <0.7, 0.8, 0.9> },
pigment { color rgb <1.1, 1.2, 1.3> }"
                )

            };

        public static IEnumerable<object[]> GetTests(object n)
        {
            return Tests.Select(t => new object[] {t.name, t.obj, t.expect});
        }
        
        [Theory]
        [MemberData(nameof(GetTests), null)]
        public void PatternTest(string name, Func<SceneElement> elem, string expect)
        {
            TestHelpers.TestElement(elem(), expect);
        }
    }
}