namespace Samples
{
    using PovScene.Libraries;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.Lights;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects.Atmospheric;
    using PovScene.SceneDescription.Items.Objects.Solid;
    using PovScene.SceneDescription.Values;

    public class DemoScene : Scene
    {
        public DemoScene()
        {
            this.Camera = new Camera((2, 4, -7), (0, 1.5, 0))
            {
                FocalPoint = 0
            };

            this.Add(new LightSource.Area((5, 9, -6))
            {
                FadeDistance = 6,
                FadePower = 2
            });

            this.Add(new Plane(Vector.Y)
            {
                Pigment = new Pattern.Checker(Colors.Black, Colors.White),
                Finish = 
                {
                    Reflection = 0.02
                }               
            });
            
            this.Add(new SkySphere
            {
                Pigment = new Pattern.Gradient(Vector.Y)
                {
                    Map = new ColorMap
                    {
                        {0, (0.7, 0.8, 1)},
                        {0.04, (0.2, 0.3, 0.8)},
                        {0.7, (0.2, 0.4, 0.9)}
                    }
                },
                Emission = (1,1,1)
            });

        }
    }
}