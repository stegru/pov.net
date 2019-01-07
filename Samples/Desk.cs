namespace Samples
{
    using PovScene.Libraries;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.Lights;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects.Patch;
    using PovScene.SceneDescription.Items.Objects.Solid;
    using PovScene.SceneDescription.Values;
    using PovScene.Util;

    public class Desk : Scene
    {
        public Desk()
        {
            Union redPencil = new Union
            {
                new Cylinder(0, (0, 30, 0), 0.5)
                {
                    Finish =
                    {
                        Crand = 0.05,
                        Ambient = 0.3,
                        Diffuse = 0.7
                    },
                    Pigment = Colors.Red
                },
                new Cylinder(0, (0, 32, 0), 0.5)
                {
                    Finish =
                    {
                        Crand = 0.05,
                        Ambient = 0.3,
                        Diffuse = 0.7
                    },
                    Pigment = Colors.Tan
                }
            };

            Union greenPencil = redPencil.Copy();
            greenPencil[0].Pigment = Colors.Green;

            Union bluePencil = redPencil.Copy();
            greenPencil[0].Pigment = Colors.Blue;

            // Wall
            Plane backWall = new Plane(Vector.Z, 200)
            {
                Hollow = true,
                Finish =
                {
                    Crand = 0.05,
                    Ambient = 0.3,
                    Diffuse = 0.7
                },
                Pigment = Colors.LightGray
            };

            Plane ceiling = new Plane(Vector.Y, 500)
            {
                Hollow = true,
                Finish =
                {
                    Ambient = 0.3,
                    Diffuse = 0.7
                },
                Pigment = Colors.White
            };
            
            Box deskTop = new Box((-125, -2, -100), (125, 2, 100));
            deskTop.TranslateY(-20);
            deskTop.Texture = new Texture
            {
                Pigment = Library.Woods.Pigments.WoodGrain6A,
                Finish =
                {
                    Reflection = 0.2
                }
            };
            deskTop.Pigment.Map = Library.Woods.ColorMaps.Wood6A;

            deskTop.Texture.RotateY(90)
                .TranslateZ(30)
                .RotateZ(5)
                .Scale(5);

            Union blotter = new Union
            {
                new Triangle((0, 0, 0), (8.5, 0, 0), (0, 0, -11)),
                new Triangle((0, 0, -11), (8.5, 0, -11), (8.5, 0, 0))
            };
            blotter.Scale(4, 1, 4)
                .RotateY(-30)
                .Translate(-20, -17.9999, -40);

            blotter.Texture = new Texture
            {
                Finish =
                {
                    Crand = 0.04,
                    Ambient = 0.15,
                    Diffuse = 0.5
                },
                Pigment = (0.5, 0.5, 0.3)
            };


            Intersection paperweight = new Intersection
            {
                new Sphere((0, -5, 0), 10),
                new Disc(0, -Vector.Y, 10.1)
            };

            paperweight.Translate(0, -17.9998, -35);
            paperweight.Texture = new Texture
            {
                Pigment = Color.Rgbf(0.8, 1, 0.95, 0.9),
                Finish = Library.Textures.GlassFinish
            };

            paperweight.Interior.Ior = 1.5;

            Union picture = new Union
            {
                new Box(-1, 1)
                    {
                        Finish =
                        {
                            Ambient = 0.05,
                            Diffuse = 0.9
                        },
                        Pigment = new Pigment.Image(this)
                        {
                            Once = true,
                            Interpolate = Interpolation.Normalized
                        }.Scale(2, 2, 1).Translate(-1, -1, 0)
                    }
                    .Translate(1, 1, 1)
                    .Scale(20, 15, 1)
            };

            Union frame = new Union
            {
                new Cylinder(-Vector.Y, (0, 31, 0), 1).TranslateX(41),
                new Cylinder(-Vector.Y, (0, 31, 0), 1).TranslateX(-1),
                new Cylinder(-Vector.X, (41, 0, 0), 1).TranslateY(31),
                new Cylinder(-Vector.X, (41, 0, 0), 1).TranslateY(-1),
                new Sphere((-1, -1, 0), 1),
                new Sphere((-1, 31, 0), 1),
                new Sphere((41, -1, 0), 1),
                new Sphere((41, 31, 0), 1)
            };

            frame.Texture = Library.Textures.BrassTexture;

            picture.Add(frame);
            picture.Scale(1.5)
                .Rotate(10, -35, 0)
                .Translate(-65, -15, -25);

            Union pencilHolder = new Union
            {
                new Intersection
                {
                    new Cylinder((0, 0, 0), (0, 30, 0), 5),
                    new Cylinder((0, -0.1, 0), (0, 30.1, 0), 4.8) {Inverse = true},
                    new Plane(Vector.Y, 0)
                    {
                        Inverse = true
                    },
                    new Plane(Vector.Y, 15).RotateX(-45)
                },
                redPencil.RotateZ(-2)
                    .Translate(1, 0, 1),
                greenPencil.RotateZ(2)
                    .Translate(-1, 3, 0),
                bluePencil.Rotate(2, 0, 3)
                    .Translate(0, 2, 1)
            };
            pencilHolder[0].Texture = Library.Textures.BrassTexture;
            pencilHolder.RotateY(45)
                .Translate(70, -18, -20);

            Intersection lampTop = new Intersection
            {
                new Cylinder((-30, 0, 0), (30, 0, 0), 10),
                new Cylinder((-30, 0, 0), (30, 0, 0), 9.95) {Inverse = true},
                new Plane(Vector.Y, 0) {Inverse = true},
                new Plane(Vector.X, -30) {Inverse = true},
                new Plane(Vector.X, 30)
            };
            lampTop.Translate(0, 35, -13);
            lampTop.Texture = new Texture
            {
                Finish = new Finish(Library.Finishes.Shiny)
                {
                    Crand = 0.05,
                    Ambient = 0.5,
                    Diffuse = 0.5,
                    Reflection = 0.3,
                    Brilliance = 4.0
                },
                Pigment = Colors.DarkGreen
            };

            Union lampTopSides = new Union
            {
                new Intersection
                {
                    new Sphere((-30, 35, -13), 10),
                    new Sphere((-30, 35, -13), 9.95) {Inverse = true},
                    new Plane(Vector.Y, 35) {Inverse = true},
                    new Plane(Vector.X, -30)
                },
                new Intersection
                {
                    new Plane(Vector.Y, 35) {Inverse = true},
                    new Plane(Vector.X, 30) {Inverse = true},
                    new Sphere((30, 35, -13), 10),
                    new Sphere((30, 35, -13), 9.95) {Inverse = true}
                }
            };
            lampTopSides.Texture = Library.Textures.BrassTexture;


            Union lamp = new Union
            {
                new Cylinder((0, -18, 0), (0, 40, 0), 3)
                {
                    Texture = Library.Textures.BrassTexture
                },
                new Cylinder((0, -2, 0), (0, 2, 0), 25)
                {
                    Texture = new Texture(Library.Textures.BrassTexture)
                    {
                        Normal = new Pattern.Bumps(0.1)
                    }
                }.Translate(0, -16, -5),
                lampTop,
                lampTopSides
            };

            lamp.RotateY(35).Translate(50, 0, 30);

            LightSource lampLight = new LightSource(0, Colors.White)
            {
                LooksLike = new Cylinder((-25, 0, 0), (25, 0, 0), 2)
                {
                    Pigment = new Color(Colors.White, 0),
                    Finish =
                    {
                        Ambient = 1,
                        Diffuse = 0
                    }
                }
            };

            lampLight.Translate(0, 43, -10).RotateY(35).Translate(50, 0, 30);

            this.Camera = new Camera((0, 40, -150), 0)
            {
                AngleHorizontal = 65,
                Right = Vector.X * 1.25
            };

            LightSource light = new LightSource((20, 100, -200), Colors.White);
            this.Add(light);

            this.Add(backWall);
            this.Add(ceiling);
            this.Add(deskTop);
            this.Add(blotter);
            this.Add(paperweight);
            this.Add(picture);
            this.Add(pencilHolder);
            this.Add(lamp);
            this.Add(lampLight);

            this.GlobalSettings.Radiosity = new GlobalSettings.RadiositySettings
            {
                PretraceStart = 1,
                PretraceEnd = 1,                
                ErrorBound =  0.25,
                RecursionLimit = 1,
                Normal = true,
                Brightness = 1              
            };
            this.GlobalSettings.AssumedGamma = 2.2;
        }
    }
}