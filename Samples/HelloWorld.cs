/*
 * The radiosity presets taken from 'rad_def.inc', part of the POV-Ray distribution:
 * 
 * https://github.com/POV-Ray/povray/blob/master/distribution/include/rad_def.inc
 * 
 * This work is licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-sa/3.0/ or send a
 * letter to Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
namespace Samples
{
    using PovScene.Engine;
    using PovScene.Libraries;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.Lights;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects.Solid;
    using PovScene.SceneDescription.Values;

    public class HelloWorld : Scene
    {
        public static void Render()
        {            
            Povray pv = new Povray();
            pv.Render(new HelloWorld());
        }
        
        public HelloWorld()
        {
            Scene scene = new Scene
            {
                // Point a camera to the middle of the world.
                Camera = new Camera((2, 1, -7), (0, 1.5, 0)) {FocalPoint = (0, 1.5, 0), BlurSamples = 50}
            };

            // Add a light.
            scene.Add(new LightSource.Area((5, 9, -6))
            {
                FadeDistance = 6,
                FadePower = 2
            });

            // Lay the checkered floor
            scene.Add(new Plane(Vector.Y)
            {
                Pigment = new Pattern.Checker(Colors.Blue, Colors.White),
                Finish = 
                {
                    Reflection = 0.02
                }               
            });

            // Float the mirror ball.
            scene.Add(new Sphere((0, 2.5, 0), 2)
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
            });
            
            scene.GlobalSettings.Radiosity = new GlobalSettings.RadiositySettings
            {
                PretraceStart = 1,
                PretraceEnd = 1,                
                ErrorBound =  0.25,
                RecursionLimit = 1,
                Normal = true,
                Brightness = 2                
            };

            scene.PovrayOptions.DisplayOutput.PauseWhenDone = true;
            scene.PovrayOptions.DisplayOutput.Display = true;
            scene.PovrayOptions.Tracing.Quality = 11;
            scene.PovrayOptions.Tracing.Antialias = true;

            // Render it
            Povray povray = new Povray();
            povray.Render(scene);

        }
    }
}