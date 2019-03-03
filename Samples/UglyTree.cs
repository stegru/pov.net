namespace Samples
{
    using System;
    using PovScene.Engine;
    using PovScene.Libraries;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.Lights;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects.Atmospheric;
    using PovScene.SceneDescription.Items.Objects.Solid;
    using PovScene.SceneDescription.Values;
    using PovScene.Util;

    public class UglyTree : Union
    {
        private Scene scene;

        public UglyTree(Scene scene)
        {
            this.scene = scene;
            Cylinder trunk = new Cylinder((0,0,0), (0,10,0), 1);
            this.Add(trunk);
            this.AddBranches(trunk, 5);
            this.Texture = Library.Textures.DarkWood;
            
            this.Scale(0.1);
        }

        private void AddBranches(Cylinder parentBranch, Float size)
        {
            for (int n = 0; n < this.scene.Random.Int(2, 5); n++)
            {
                this.Branch(parentBranch, size);
            }
        }

        private void Branch(Cylinder parent, Float size)
        {
            Cylinder branch = new Cylinder();
            branch.Texture = Library.Textures.DarkWood;
            Vector end = (new PovRandom().Vector() + (-0.5, 0, -0.5)) * (size * 3) ;
            
            branch.BasePoint = parent.CapPoint;
            branch.CapPoint = parent.CapPoint + end;
            branch.Radius = size * 0.1;

            this.Add(branch);

            size = size * 0.5;
            if (size > 1)
            {
                this.AddBranches(branch, size);
            }
        }

        public static void Render()
        {
            Scene scene = new Scene();

            for (int x = -5; x < 5; x++)
            {
                for (int z = 0; z < 5; z++)
                {
                    UglyTree tree = new UglyTree(scene);
                    tree.Translate(x * 2, 0, z * 2);
                    scene.Add(tree);
                }
            }


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

            
            scene.PovrayOptions.Tracing.Quality = 11;
            scene.PovrayOptions.Tracing.Antialias = true;
            scene.PovrayOptions.DisplayOutput.PauseWhenDone = true;
            scene.PovrayOptions.DisplayOutput.Display = true;
            scene.PovrayOptions.FileOutput.OutputFileName = "uglytree.png";

            scene.Write();
            Povray pv = new Povray();            
            pv.Render(scene, 1280,1024);


        }
    }
    
    
    
}