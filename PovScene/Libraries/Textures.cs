/*
 * The list of textures was extracted from 'textures.inc', part of the POV-Ray distribution:
 * 
 * https://github.com/POV-Ray/povray/blob/master/distribution/include/textures.inc
 * 
 * This work is licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-sa/3.0/ or send a
 * letter to Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
namespace PovScene.Libraries
{
    using SceneDescription.Items.ObjectModifiers;

    public partial class Library
    {
        public static class Finishes
        {
            public static Finish Shiny => FinishInc.Get<Finish>("Shiny");
        }

        public static class Textures
        {
            // ReSharper disable InconsistentNaming
            public static Texture Aluminum => TexturesInc.Get<Texture>("Aluminum");
            public static Texture Apocalypse => TexturesInc.Get<Texture>("Apocalypse");
            public static Texture BloodMarble => TexturesInc.Get<Texture>("Blood_Marble");
            public static Texture BloodMarbleMap => TexturesInc.Get<Texture>("Blood_Marble_Map");
            public static Texture BloodSky => TexturesInc.Get<Texture>("Blood_Sky");
            public static Texture BlueAgate => TexturesInc.Get<Texture>("Blue_Agate");
            public static Texture BlueAgateMap => TexturesInc.Get<Texture>("Blue_Agate_Map");
            public static Texture BlueSky => TexturesInc.Get<Texture>("Blue_Sky");
            public static Texture BlueSky2 => TexturesInc.Get<Texture>("Blue_Sky2");
            public static Texture BlueSky3 => TexturesInc.Get<Texture>("Blue_Sky3");
            public static Texture BlueSkyMap => TexturesInc.Get<Texture>("Blue_Sky_Map");
            public static Texture BrassMetal => TexturesInc.Get<Texture>("Brass_Metal");
            public static Texture BrassTexture => TexturesInc.Get<Texture>("Brass_Texture");
            public static Texture BrassValley => TexturesInc.Get<Texture>("Brass_Valley");
            public static Texture BrightBlueSky => TexturesInc.Get<Texture>("Bright_Blue_Sky");
            public static Texture BrightBronze => TexturesInc.Get<Texture>("Bright_Bronze");
            public static Texture BronzeMetal => TexturesInc.Get<Texture>("Bronze_Metal");
            public static Texture BronzeTexture => TexturesInc.Get<Texture>("Bronze_Texture");
            public static Texture BrownAgate => TexturesInc.Get<Texture>("Brown_Agate");
            public static Texture BrownAgateMap => TexturesInc.Get<Texture>("Brown_Agate_Map");
            public static Texture BrushedAluminum => TexturesInc.Get<Texture>("Brushed_Aluminum");
            public static Texture CandyCane => TexturesInc.Get<Texture>("Candy_Cane");
            public static Texture CherryWood => TexturesInc.Get<Texture>("Cherry_Wood");
            public static Texture ChromeMetal => TexturesInc.Get<Texture>("Chrome_Metal");
            public static Texture ChromeTexture => TexturesInc.Get<Texture>("Chrome_Texture");
            public static Texture Clouds => TexturesInc.Get<Texture>("Clouds");
            public static Texture CopperMetal => TexturesInc.Get<Texture>("Copper_Metal");
            public static Texture CopperTexture => TexturesInc.Get<Texture>("Copper_Texture");
            public static Texture Cork => TexturesInc.Get<Texture>("Cork");
            public static Texture DarkGreenGlass => TexturesInc.Get<Texture>("Dark_Green_Glass");
            public static Texture DarkWood => TexturesInc.Get<Texture>("Dark_Wood");
            public static Texture DMFDarkOak => TexturesInc.Get<Texture>("DMFDarkOak");
            public static Texture DMFLightOak => TexturesInc.Get<Texture>("DMFLightOak");
            public static Texture DMFWood1 => TexturesInc.Get<Texture>("DMFWood1");
            public static Texture DMFWood2 => TexturesInc.Get<Texture>("DMFWood2");
            public static Texture DMFWood3 => TexturesInc.Get<Texture>("DMFWood3");
            public static Texture DMFWood4 => TexturesInc.Get<Texture>("DMFWood4");
            public static Texture DMFWood5 => TexturesInc.Get<Texture>("DMFWood5");
            public static Texture DMFWood6 => TexturesInc.Get<Texture>("DMFWood6");
            public static Texture EMBWood1 => TexturesInc.Get<Texture>("EMBWood1");
            public static Texture FBMClouds => TexturesInc.Get<Texture>("FBM_Clouds");
            public static Texture Glass => TexturesInc.Get<Texture>("Glass");
            public static Texture Glass2 => TexturesInc.Get<Texture>("Glass2");
            public static Texture Glass3 => TexturesInc.Get<Texture>("Glass3");
            public static Finish GlassFinish => TexturesInc.Get<Finish>("Glass_Finish");
            public static Interior GlassInterior => TexturesInc.Get<Interior>("Glass_Interior");
            public static Texture GoldMetal => TexturesInc.Get<Texture>("Gold_Metal");
            public static Texture GoldNugget => TexturesInc.Get<Texture>("Gold_Nugget");
            public static Texture GoldTexture => TexturesInc.Get<Texture>("Gold_Texture");
            public static Texture GreenGlass => TexturesInc.Get<Texture>("Green_Glass");
            public static Texture Jade => TexturesInc.Get<Texture>("Jade");
            public static Texture JadeMap => TexturesInc.Get<Texture>("Jade_Map");
            public static Texture Lightning1 => TexturesInc.Get<Texture>("Lightning1");
            public static Texture Lightning2 => TexturesInc.Get<Texture>("Lightning2");
            public static Texture LightningCMap1 => TexturesInc.Get<Texture>("Lightning_CMap1");
            public static Texture LightningCMap2 => TexturesInc.Get<Texture>("Lightning_CMap2");
            public static Texture MDarkGreenGlass => TexturesInc.Get<Texture>("M_Dark_Green_Glass");
            public static Texture Metal => TexturesInc.Get<Texture>("Metal");
            public static Texture MetallicFinish => TexturesInc.Get<Texture>("Metallic_Finish");
            public static Texture MGlass2 => TexturesInc.Get<Texture>("M_Glass2");
            public static Texture MGlass3 => TexturesInc.Get<Texture>("M_Glass3");
            public static Texture MGlass => TexturesInc.Get<Texture>("M_Glass");
            public static Texture MGreenGlass => TexturesInc.Get<Texture>("M_Green_Glass");
            public static Texture MNBBeerbottleGlass => TexturesInc.Get<Texture>("M_NB_Beerbottle_Glass");
            public static Texture MNBGlass => TexturesInc.Get<Texture>("M_NB_Glass");
            public static Texture MNBOldGlass => TexturesInc.Get<Texture>("M_NB_Old_Glass");
            public static Texture MNBWinebottleGlass => TexturesInc.Get<Texture>("M_NB_Winebottle_Glass");
            public static Texture MOrangeGlass => TexturesInc.Get<Texture>("M_Orange_Glass");
            public static Texture MRubyGlass => TexturesInc.Get<Texture>("M_Ruby_Glass");
            public static Texture MVicksBottleGlass => TexturesInc.Get<Texture>("M_Vicks_Bottle_Glass");
            public static Texture MWater => TexturesInc.Get<Texture>("M_Water");
            public static Texture MYellowGlass => TexturesInc.Get<Texture>("M_Yellow_Glass");
            public static Texture NBbeerbottle => TexturesInc.Get<Texture>("NBbeerbottle");
            public static Texture NBglass => TexturesInc.Get<Texture>("NBglass");
            public static Texture NBoldglass => TexturesInc.Get<Texture>("NBoldglass");
            public static Texture NBwinebottle => TexturesInc.Get<Texture>("NBwinebottle");
            public static Texture NewBrass => TexturesInc.Get<Texture>("New_Brass");
            public static Texture NewPenny => TexturesInc.Get<Texture>("New_Penny");
            public static Texture OrangeGlass => TexturesInc.Get<Texture>("Orange_Glass");
            public static Texture Peel => TexturesInc.Get<Texture>("Peel");
            public static Texture PineWood => TexturesInc.Get<Texture>("Pine_Wood");
            public static Texture PinkAlabaster => TexturesInc.Get<Texture>("PinkAlabaster");
            public static Texture PinkGranite => TexturesInc.Get<Texture>("Pink_Granite");
            public static Texture PinkGraniteMap => TexturesInc.Get<Texture>("Pink_Granite_Map");
            public static Texture PolishedBrass => TexturesInc.Get<Texture>("Polished_Brass");
            public static Texture PolishedChrome => TexturesInc.Get<Texture>("Polished_Chrome");
            public static Texture RedMarble => TexturesInc.Get<Texture>("Red_Marble");
            public static Texture RedMarbleMap => TexturesInc.Get<Texture>("Red_Marble_Map");
            public static Texture Rosewood => TexturesInc.Get<Texture>("Rosewood");
            public static Texture RubyGlass => TexturesInc.Get<Texture>("Ruby_Glass");
            public static Texture Rust => TexturesInc.Get<Texture>("Rust");
            public static Texture RustyIron => TexturesInc.Get<Texture>("Rusty_Iron");
            public static Texture Sandalwood => TexturesInc.Get<Texture>("Sandalwood");
            public static Texture SapphireAgate => TexturesInc.Get<Texture>("Sapphire_Agate");
            public static Texture SapphireAgateMap => TexturesInc.Get<Texture>("Sapphire_Agate_Map");
            public static Texture ShadowClouds => TexturesInc.Get<Texture>("Shadow_Clouds");
            public static Texture Silver1 => TexturesInc.Get<Texture>("Silver1");
            public static Texture Silver1Colour => TexturesInc.Get<Texture>("Silver1_Colour");
            public static Texture Silver2 => TexturesInc.Get<Texture>("Silver2");
            public static Texture Silver2Colour => TexturesInc.Get<Texture>("Silver2_Colour");
            public static Texture Silver3 => TexturesInc.Get<Texture>("Silver3");
            public static Texture Silver3Colour => TexturesInc.Get<Texture>("Silver3_Colour");
            public static Texture SilverFinish => TexturesInc.Get<Texture>("SilverFinish");
            public static Texture SilverMetal => TexturesInc.Get<Texture>("Silver_Metal");
            public static Texture SilverTexture => TexturesInc.Get<Texture>("Silver_Texture");
            public static Texture SoftSilver => TexturesInc.Get<Texture>("Soft_Silver");
            public static Texture SpunBrass => TexturesInc.Get<Texture>("Spun_Brass");
            public static Texture Starfield => TexturesInc.Get<Texture>("Starfield");
            public static Texture TanWood => TexturesInc.Get<Texture>("Tan_Wood");
            public static Texture TexturesIncTemp => TexturesInc.Get<Texture>("Textures_Inc_Temp");
            public static Texture TinnyBrass => TexturesInc.Get<Texture>("Tinny_Brass");
            public static Texture TomWood => TexturesInc.Get<Texture>("Tom_Wood");
            public static Texture VicksBottleGlass => TexturesInc.Get<Texture>("Vicks_Bottle_Glass");
            public static Texture Water => TexturesInc.Get<Texture>("Water");
            public static Interior WaterInterior => TexturesInc.Get<Interior>("Water_Int");
            public static Texture WhiteMarble => TexturesInc.Get<Texture>("White_Marble");
            public static Texture WhiteMarbleMap => TexturesInc.Get<Texture>("White_Marble_Map");
            public static Texture WhiteWood => TexturesInc.Get<Texture>("White_Wood");
            public static Texture XGradient => TexturesInc.Get<Texture>("X_Gradient");
            public static Texture YellowGlass => TexturesInc.Get<Texture>("Yellow_Glass");
            public static Texture YellowPine => TexturesInc.Get<Texture>("Yellow_Pine");

            public static Texture YGradient => TexturesInc.Get<Texture>("Y_Gradient");
            // ReSharper restore InconsistentNaming
        }
    }
}