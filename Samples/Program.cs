using System;

namespace Samples
{
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using PovScene.Engine;
    using PovScene.Libraries;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.Lights;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects;
    using PovScene.SceneDescription.Items.Objects.Atmospheric;
    using PovScene.SceneDescription.Items.Objects.Patch;
    using PovScene.SceneDescription.Items.Objects.Solid;
    using PovScene.SceneDescription.Values;
    using PovScene.Util;

    class Program
    {
        static void Main(string[] args)
        {
            //Scene scene = new Desk();

            Scene scene = new Scene
            {
                Camera = new Camera((2, 80, -190), (0, 4, 0))
                {
                    FocalPoint = 0
                }
            };

            scene.DefaultTexture = new Texture
            {
                Finish =
                {
                    Emission = 0,
                    Diffuse = 1,
                    Ambient = 0,
                    ConserveEnergy = true
                }
            };

//            scene.Add(new LightSource.Area((5, 9, -6))
//            {
//                FadeDistance = 6,
//                FadePower = 2
//            });

            scene.Add(new Plane(Vector.Y, 0)
            {
                Pigment = new Pattern.Checker(Colors.Black, Colors.White).Scale(10),
                Finish =
                {
                    Phong = 1,
                    Reflection = 0
                }
            }.RotateX(0));

            Pigment.Image img = new Pigment.Image("Road_to_MonumentValley_Ref.hdr")
            {
                
                Interpolate = Interpolation.Bilinear,
                MapType = MapType.Spherical,
                //Gamma = 1
            };
            img.MapImage.BitmapType = Keyword.Hdr;
            
            var ss = new SkySphere()
            {
                Pigment = img,
                Emission = 1                
            };
            var sky = new Sphere((0,0,0),1000)
            {
                Pigment = img,
                Inverse = true,
                Hollow = true,
                Finish =
                {
                    Emission = 1,
                    Ambient = 0,
                    Diffuse = 0,
                    Specular = 0,
                    Reflection = 0
                }
                //Emission = 2,

            };
            var l = new LightSource((0, 0, 0))
            {
               LooksLike = sky
            };

            var u = new Union()
            {
                l,
                sky
            };

            scene.Add(ss.RotateY(90) );
            

//            Cylinder water = new Cylinder((0, 0.3, 0), (0, 2.8, 0), 4.7);
//                       
//            Pattern.Ripples ripples = new Pattern.Ripples(4, 0);
//            ripples.Animate += (sender, animation) => ripples.Phase = 1 - animation.Clock;
//            
//            water.Texture = new Texture
//            {
//                Pigment = Color.Rgbf(0.9,0.9,1,1),
//                Normal = ripples,
//                Finish =
//                {
//                    Reflection =
//                    {
//                        Color = 0.4,
//                        //ColorMin = 0.3,
//                        //Fresnel = 1
//                    }
//                }
//            };
//            
//            water.Interior = Library.Textures.WaterInterior;
//            
//            Cylinder cutout = new Cylinder(water.BasePoint, (0, 5, 0), water.Radius);
//            
//            SceneObject tub = new Cylinder((0, 0, 0), (0, 3, 0), 5) - cutout;
//
//            tub.Texture = new Texture(Library.Textures.CandyCane)
//            {
//                Finish =
//                {
//                    Emission = 0,
//                    Diffuse = 1
//                }
//            };
            
            //tub.Interior = Library.Textures.GlassInterior;

            //tub.Texture.Pigment.ShapeWarp = ShapeWarp.Cylinder;
            //tub.Texture.Pigment.ShapeWarpDirection = Axis.Z;

//            var both = tub + water;
//
//            scene.Add(both);

            Sphere sphere = new Sphere((9, 20, 6), 20)
            {
                //Pigment = Colors.Red,
                //Normal =new Pattern.Ripples(0.4,0),
                Finish =
                {
                    Reflection = 1
                }
            };

            scene.Add(sphere);

            scene.PovrayOptions.Tracing.Quality = 11;
            scene.PovrayOptions.Tracing.Antialias = true;
            scene.PovrayOptions.DisplayOutput.PauseWhenDone = true;
            scene.PovrayOptions.DisplayOutput.Display = true;
            scene.PovrayOptions.FileOutput.OutputFileName = "desk.png";

            scene.GlobalSettings = new GlobalSettings
            {
                AssumedGamma = 1,
                
                Radiosity = new GlobalSettings.RadiositySettings
                {
                    Preset = RadiosityPreset.OutdoorHighQuality,
                    
                    Normal = true,
                    Media = true
                }
            };


            bool single = scene.ToString() != "a";
            
            if (single)
            {
                Povray pv = new Povray();
                pv.Render(scene);
            }
            else
            {
                scene.PovrayOptions.DisplayOutput.Display = false;
                Animation anim = new Animation(scene, 20);
                anim.Cyclic = true;
                anim.RenderMovie("out.mp4");
            }

//            PovrayOptions options = new PovrayOptions(scene.PovrayOptions);
//            options.FileOutput.OutputFileName = "desk-orig.png";
//            options.SceneParsing.InputFileName = "/usr/local/share/povray-3.7/scenes/advanced/desk/desk.pov";
//            
//            pv.Render(options).Wait();


        }
    }
}