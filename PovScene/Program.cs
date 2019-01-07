namespace PovScene
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using Engine;
    using Libraries;
    using PovScene.SceneDescription;
    using SceneDescription.Items;
    using SceneDescription.Items.Lights;
    using SceneDescription.Items.ObjectModifiers;
    using SceneDescription.Items.Objects.Atmospheric;
    using SceneDescription.Items.Objects.Solid;
    using SceneDescription.Output;
    using SceneDescription.Values;


    class Program
    {
        public static string RenderElement(SceneElement element)
        {
            SceneWriter output = new SceneWriter();
            OutputAttribute outputAttr = OutputAttribute.Combine(element.GetAllAttributes<OutputAttribute>());
            ElementContext sceneContext = new ElementContext(new ElementContext(null, new Scene()), element, outputAttr);
            sceneContext.LoadChildren(true);
            sceneContext.Write(output);
            return output.ToString();
        }

        
        private static int lastLine = 0;
        private static string[] source;
        public static void test(IValue item, [CallerLineNumber] int line = 0)
        {
            if (item != null)
            {
                Regex re = new Regex(@"^\s+\S+\s+(\S+)\s+=\s+new\s+", RegexOptions.Compiled);
                string code = "";
                for (int i = lastLine; i < line - 1; i++)
                {
                    code += re.Replace(source[i], " (\n\"$1\",\n() => new ") + "\n";
                }

                code = code.Trim();
                if (code.EndsWith(';'))
                {
                    code = code.Substring(0, code.Length - 1);
                }

                string output = null;
                if (item is SceneElement elem)
                {

                    //Console.WriteLine("#" + line);
                    output = RenderElement(elem).Replace("\"", "\"\"").Trim();
                    if (output.IndexOf('\n') > -1)
                    {
                        output = "\n" + output;
                    }
                }
                else
                {
                    output = item.ToString();
                }

                Console.WriteLine(code + ",\n@\"" + output + "\"\n),".Replace("\n\n", "\n"));
            }

            lastLine = line + 1;

        }

        public static void MakeTests()
        {
            source = File.ReadAllLines("Program.cs");
            test(null);
            
            
            
        }

        static void Main(string[] args)
        {
//            MakeTests();
//            if (args.Length < 10)
//            {
//                return;
//            }

            
            Scene scene = new Scene();

            
            scene.Camera = new Camera((2, 4, -7), (0, 1.5, 0))
            {
                FocalPoint = 0,
                //BlurSamples = 50
            };

            scene.Add(new LightSource.Area((5, 9, -6))
            {
                FadeDistance = 6,
                FadePower = 2
            });

            scene.Add(new Plane(Vector.Y)
            {
                Pigment = new Pattern.Checker(Colors.Black, Colors.White),
                Normal = new Pattern.Brick(
                    new Normal.Patterned(new Pattern.Agate()),
                    new Normal.Patterned(new Pattern.Bozo())),
                Finish = 
                {
                    Reflection = 0.02
                }
            });
            
            scene.Add(new SkySphere
            {
                Pigment = new Pattern.Gradient(Vector.Y)
                {
                    Map = new ColorMap
                    {
                        {0, (0.7, 0.8, 1)},
                        {0.04, (0.2, 0.3, 0.8)},
                        {0.7, (0.2, 0.4, 0.9)}
                    }
                }
            });

            Sphere sphere = new Sphere((0, 1, 0), 0)
            {
                Texture = new Texture()
                {
                    Pigment = (0.1, 0.1, 0.1),
                    Finish = new Finish
                    {
                        Reflection =
                        {
                            ColorMin = 0.9,
                            Color = 0.6
                        },
                        Phong = 1.0,
                        PhongSize = 200,
                        Diffuse = 0.25
                    }

                }
            };
                
            sphere.Animate += (sender, animation) =>
            {
                sphere.Radius = animation.Clock;
                
            };
            scene.Add(sphere);
            
            Povray pv = new Povray();
            PovrayOptions options = new PovrayOptions();
//            pv.Options.DisplayOutput.Pause_When_Done = true;
//            pv.Options.DisplayOutput.Display = true;
            options.Tracing.Quality = 11;
            options.Tracing.Antialias = true;

            pv.Render(scene);
            return;
            options.DisplayOutput.Display = false;
            Animation anim = new Animation(scene, 5, pv);
            anim.DoubleBack = true;
            anim.DoubleBack = anim.DoubleBackRemoveEnds = true;
            anim.RenderMovie("output.mp4");

        }

    }
}