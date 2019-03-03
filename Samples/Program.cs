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
            HelloWorld.Render();

/*            
            if (true)
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
/**/
//            PovrayOptions options = new PovrayOptions(scene.PovrayOptions);
//            options.FileOutput.OutputFileName = "desk-orig.png";
//            options.SceneParsing.InputFileName = "/usr/local/share/povray-3.7/scenes/advanced/desk/desk.pov";
//            
//            pv.Render(options).Wait();


        }
    }
}