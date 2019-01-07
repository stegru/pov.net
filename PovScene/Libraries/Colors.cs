/*
 * The list of colours was extracted from 'colors.inc', part of the POV-Ray distribution:
 * 
 * https://github.com/POV-Ray/povray/blob/master/distribution/include/colors.inc
 * 
 * This work is licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-sa/3.0/ or send a
 * letter to Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
namespace PovScene.Libraries
{
    using SceneDescription.Values;

    public sealed class Colors : Library
    {
        public Colors() : base("colors.inc")
        {
        }

        public static Color Aquamarine => ColorsInc.Get<Color>("Aquamarine");
        public static Color BakersChoc => ColorsInc.Get<Color>("BakersChoc");
        public static Color Black => ColorsInc.Get<Color>("Black");
        public static Color Blue => ColorsInc.Get<Color>("Blue");
        public static Color BlueViolet => ColorsInc.Get<Color>("BlueViolet");
        public static Color Brass => ColorsInc.Get<Color>("Brass");
        public static Color BrightGold => ColorsInc.Get<Color>("BrightGold");
        public static Color Bronze2 => ColorsInc.Get<Color>("Bronze2");
        public static Color Bronze => ColorsInc.Get<Color>("Bronze");
        public static Color Brown => ColorsInc.Get<Color>("Brown");
        public static Color CadetBlue => ColorsInc.Get<Color>("CadetBlue");
        public static Color Clear => ColorsInc.Get<Color>("Clear");
        public static Color CoolCopper => ColorsInc.Get<Color>("CoolCopper");
        public static Color Copper => ColorsInc.Get<Color>("Copper");
        public static Color Coral => ColorsInc.Get<Color>("Coral");
        public static Color CornflowerBlue => ColorsInc.Get<Color>("CornflowerBlue");
        public static Color Cyan => ColorsInc.Get<Color>("Cyan");
        public static Color DarkBrown => ColorsInc.Get<Color>("DarkBrown");
        public static Color DarkGreen => ColorsInc.Get<Color>("DarkGreen");
        public static Color DarkOliveGreen => ColorsInc.Get<Color>("DarkOliveGreen");
        public static Color DarkOrchid => ColorsInc.Get<Color>("DarkOrchid");
        public static Color DarkPurple => ColorsInc.Get<Color>("DarkPurple");
        public static Color DarkSlateBlue => ColorsInc.Get<Color>("DarkSlateBlue");
        public static Color DarkSlateGray => ColorsInc.Get<Color>("DarkSlateGray");
        public static Color DarkSlateGrey => ColorsInc.Get<Color>("DarkSlateGrey");
        public static Color DarkTan => ColorsInc.Get<Color>("DarkTan");
        public static Color DarkTurquoise => ColorsInc.Get<Color>("DarkTurquoise");
        public static Color DarkWood => ColorsInc.Get<Color>("DarkWood");
        public static Color DimGray => ColorsInc.Get<Color>("DimGray");
        public static Color DimGrey => ColorsInc.Get<Color>("DimGrey");
        public static Color DkGreenCopper => ColorsInc.Get<Color>("DkGreenCopper");
        public static Color DustyRose => ColorsInc.Get<Color>("DustyRose");
        public static Color Feldspar => ColorsInc.Get<Color>("Feldspar");
        public static Color Firebrick => ColorsInc.Get<Color>("Firebrick");
        public static Color Flesh => ColorsInc.Get<Color>("Flesh");
        public static Color ForestGreen => ColorsInc.Get<Color>("ForestGreen");
        public static Color Goldenrod => ColorsInc.Get<Color>("Goldenrod");
        public static Color Gold => ColorsInc.Get<Color>("Gold");
        public static Color Gray05 => ColorsInc.Get<Color>("Gray05");
        public static Color Gray10 => ColorsInc.Get<Color>("Gray10");
        public static Color Gray15 => ColorsInc.Get<Color>("Gray15");
        public static Color Gray20 => ColorsInc.Get<Color>("Gray20");
        public static Color Gray25 => ColorsInc.Get<Color>("Gray25");
        public static Color Gray30 => ColorsInc.Get<Color>("Gray30");
        public static Color Gray35 => ColorsInc.Get<Color>("Gray35");
        public static Color Gray40 => ColorsInc.Get<Color>("Gray40");
        public static Color Gray45 => ColorsInc.Get<Color>("Gray45");
        public static Color Gray50 => ColorsInc.Get<Color>("Gray50");
        public static Color Gray55 => ColorsInc.Get<Color>("Gray55");
        public static Color Gray60 => ColorsInc.Get<Color>("Gray60");
        public static Color Gray65 => ColorsInc.Get<Color>("Gray65");
        public static Color Gray70 => ColorsInc.Get<Color>("Gray70");
        public static Color Gray75 => ColorsInc.Get<Color>("Gray75");
        public static Color Gray80 => ColorsInc.Get<Color>("Gray80");
        public static Color Gray85 => ColorsInc.Get<Color>("Gray85");
        public static Color Gray90 => ColorsInc.Get<Color>("Gray90");
        public static Color Gray95 => ColorsInc.Get<Color>("Gray95");
        public static Color Gray => ColorsInc.Get<Color>("Gray");
        public static Color GreenCopper => ColorsInc.Get<Color>("GreenCopper");
        public static Color Green => ColorsInc.Get<Color>("Green");
        public static Color GreenYellow => ColorsInc.Get<Color>("GreenYellow");
        public static Color Grey => ColorsInc.Get<Color>("Grey");
        public static Color HuntersGreen => ColorsInc.Get<Color>("HuntersGreen");
        public static Color IndianRed => ColorsInc.Get<Color>("IndianRed");
        public static Color Khaki => ColorsInc.Get<Color>("Khaki");
        public static Color LightBlue => ColorsInc.Get<Color>("LightBlue");
        public static Color LightGray => ColorsInc.Get<Color>("LightGray");
        public static Color LightGrey => ColorsInc.Get<Color>("LightGrey");
        public static Color LightPurple => ColorsInc.Get<Color>("Light_Purple");
        public static Color LightSteelBlue => ColorsInc.Get<Color>("LightSteelBlue");
        public static Color LightWood => ColorsInc.Get<Color>("LightWood");
        public static Color LimeGreen => ColorsInc.Get<Color>("LimeGreen");
        public static Color Magenta => ColorsInc.Get<Color>("Magenta");
        public static Color MandarinOrange => ColorsInc.Get<Color>("MandarinOrange");
        public static Color Maroon => ColorsInc.Get<Color>("Maroon");
        public static Color MediumAquamarine => ColorsInc.Get<Color>("MediumAquamarine");
        public static Color MediumBlue => ColorsInc.Get<Color>("MediumBlue");
        public static Color MediumForestGreen => ColorsInc.Get<Color>("MediumForestGreen");
        public static Color MediumGoldenrod => ColorsInc.Get<Color>("MediumGoldenrod");
        public static Color MediumOrchid => ColorsInc.Get<Color>("MediumOrchid");
        public static Color MediumSeaGreen => ColorsInc.Get<Color>("MediumSeaGreen");
        public static Color MediumSlateBlue => ColorsInc.Get<Color>("MediumSlateBlue");
        public static Color MediumSpringGreen => ColorsInc.Get<Color>("MediumSpringGreen");
        public static Color MediumTurquoise => ColorsInc.Get<Color>("MediumTurquoise");
        public static Color MediumVioletRed => ColorsInc.Get<Color>("MediumVioletRed");
        public static Color MediumWood => ColorsInc.Get<Color>("MediumWood");
        public static Color MedPurple => ColorsInc.Get<Color>("Med_Purple");
        public static Color Mica => ColorsInc.Get<Color>("Mica");
        public static Color MidnightBlue => ColorsInc.Get<Color>("MidnightBlue");
        public static Color NavyBlue => ColorsInc.Get<Color>("NavyBlue");
        public static Color Navy => ColorsInc.Get<Color>("Navy");
        public static Color NeonBlue => ColorsInc.Get<Color>("NeonBlue");
        public static Color NeonPink => ColorsInc.Get<Color>("NeonPink");
        public static Color NewMidnightBlue => ColorsInc.Get<Color>("NewMidnightBlue");
        public static Color NewTan => ColorsInc.Get<Color>("NewTan");
        public static Color OldGold => ColorsInc.Get<Color>("OldGold");
        public static Color Orange => ColorsInc.Get<Color>("Orange");
        public static Color OrangeRed => ColorsInc.Get<Color>("OrangeRed");
        public static Color Orchid => ColorsInc.Get<Color>("Orchid");
        public static Color PaleGreen => ColorsInc.Get<Color>("PaleGreen");
        public static Color Pink => ColorsInc.Get<Color>("Pink");
        public static Color Plum => ColorsInc.Get<Color>("Plum");
        public static Color Quartz => ColorsInc.Get<Color>("Quartz");
        public static Color Red => ColorsInc.Get<Color>("Red");
        public static Color RichBlue => ColorsInc.Get<Color>("RichBlue");
        public static Color Salmon => ColorsInc.Get<Color>("Salmon");
        public static Color Scarlet => ColorsInc.Get<Color>("Scarlet");
        public static Color SeaGreen => ColorsInc.Get<Color>("SeaGreen");
        public static Color SemiSweetChoc => ColorsInc.Get<Color>("SemiSweetChoc");
        public static Color Sienna => ColorsInc.Get<Color>("Sienna");
        public static Color Silver => ColorsInc.Get<Color>("Silver");
        public static Color SkyBlue => ColorsInc.Get<Color>("SkyBlue");
        public static Color SlateBlue => ColorsInc.Get<Color>("SlateBlue");
        public static Color SpicyPink => ColorsInc.Get<Color>("SpicyPink");
        public static Color SpringGreen => ColorsInc.Get<Color>("SpringGreen");
        public static Color SteelBlue => ColorsInc.Get<Color>("SteelBlue");
        public static Color SummerSky => ColorsInc.Get<Color>("SummerSky");
        public static Color Tan => ColorsInc.Get<Color>("Tan");
        public static Color Thistle => ColorsInc.Get<Color>("Thistle");
        public static Color Turquoise => ColorsInc.Get<Color>("Turquoise");
        public static Color VeryDarkBrown => ColorsInc.Get<Color>("VeryDarkBrown");
        public static Color VeryLightPurple => ColorsInc.Get<Color>("Very_Light_Purple");
        public static Color Violet => ColorsInc.Get<Color>("Violet");
        public static Color VioletRed => ColorsInc.Get<Color>("VioletRed");
        public static Color VLightGray => ColorsInc.Get<Color>("VLightGray");
        public static Color VLightGrey => ColorsInc.Get<Color>("VLightGrey");
        public static Color Wheat => ColorsInc.Get<Color>("Wheat");
        public static Color White => ColorsInc.Get<Color>("White");
        public static Color YellowGreen => ColorsInc.Get<Color>("YellowGreen");
        public static Color Yellow => ColorsInc.Get<Color>("Yellow");
    }
}