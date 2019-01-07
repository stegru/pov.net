/*
 * The list of textures was extracted from 'woods.inc', part of the POV-Ray distribution:
 * 
 * https:///github.com/POV-Ray/povray/blob/master/distribution/include/woods.inc
 * 
 * This work is licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
 * To view a copy of this license, visit http:///creativecommons.org/licenses/by-sa/3.0/ or send a
 * letter to Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
namespace PovScene.Libraries
{
    using SceneDescription.Items.ObjectModifiers;

    public partial class Library
    {
        public static class Woods
        {
            public static class Textures
            {
                // ReSharper disable InconsistentNaming
                /// Natural oak (light)
                public static Texture Wood1 => WoodsInc.Get<Texture>("T_Wood1");

                /// Dark brown
                public static Texture Wood2 => WoodsInc.Get<Texture>("T_Wood2");

                /// Bleached oak (white)
                public static Texture Wood3 => WoodsInc.Get<Texture>("T_Wood3");

                /// Mahogany (purplish-red)
                public static Texture Wood4 => WoodsInc.Get<Texture>("T_Wood4");

                /// Dark yellow with reddish overgrain
                public static Texture Wood5 => WoodsInc.Get<Texture>("T_Wood5");

                /// Cocabola (red)
                public static Texture Wood6 => WoodsInc.Get<Texture>("T_Wood6");

                /// Yellow pine (ragged grain)
                public static Texture Wood7 => WoodsInc.Get<Texture>("T_Wood7");

                /// Dark brown. Walnut?    
                public static Texture Wood8 => WoodsInc.Get<Texture>("T_Wood8");

                /// Yellowish-brown burl (heavily turbulated)
                public static Texture Wood9 => WoodsInc.Get<Texture>("T_Wood9");

                /// Soft pine (light yellow, smooth grain)
                public static Texture Wood10 => WoodsInc.Get<Texture>("T_Wood10");

                /// Spruce (yellowish, very straight, fine grain)
                public static Texture Wood11 => WoodsInc.Get<Texture>("T_Wood11");

                /// Another very dark brown.  Walnut-stained pine, perhaps?
                public static Texture Wood12 => WoodsInc.Get<Texture>("T_Wood12");

                /// Very straight grained, whitish
                public static Texture Wood13 => WoodsInc.Get<Texture>("T_Wood13");

                /// Red, rough grain
                public static Texture Wood14 => WoodsInc.Get<Texture>("T_Wood14");

                /// Medium brown
                public static Texture Wood15 => WoodsInc.Get<Texture>("T_Wood15");

                /// Medium brown
                public static Texture Wood16 => WoodsInc.Get<Texture>("T_Wood16");

                /// Medium brown
                public static Texture Wood17 => WoodsInc.Get<Texture>("T_Wood17");

                /// Orange
                public static Texture Wood18 => WoodsInc.Get<Texture>("T_Wood18");

                ///  M_Woods 1,3,7,8,10,14,15,17,18,19 work well, also.
                public static Texture Wood19 => WoodsInc.Get<Texture>("T_Wood19");

                public static Texture Wood20 => WoodsInc.Get<Texture>("T_Wood20");
                public static Texture Wood21 => WoodsInc.Get<Texture>("T_Wood21");
                public static Texture Wood22 => WoodsInc.Get<Texture>("T_Wood22");
                public static Texture Wood23 => WoodsInc.Get<Texture>("T_Wood23");
                public static Texture Wood24 => WoodsInc.Get<Texture>("T_Wood24");
                public static Texture Wood25 => WoodsInc.Get<Texture>("T_Wood25");
                public static Texture Wood26 => WoodsInc.Get<Texture>("T_Wood26");
                public static Texture Wood27 => WoodsInc.Get<Texture>("T_Wood27");
                public static Texture Wood28 => WoodsInc.Get<Texture>("T_Wood28");
                public static Texture Wood29 => WoodsInc.Get<Texture>("T_Wood29");

                public static Texture Wood30 => WoodsInc.Get<Texture>("T_Wood30");

                /// A light tan wood - heavily grained (variable coloration)
                public static Texture Wood31 => WoodsInc.Get<Texture>("T_Wood31");

                ///A rich dark reddish wood, like rosewood, with smooth-flowing grain
                public static Texture Wood32 => WoodsInc.Get<Texture>("T_Wood32");

                /// Similar to T_WoodB, but brighter
                public static Texture Wood33 => WoodsInc.Get<Texture>("T_Wood33");

                /// Reddish-orange, large, smooth grain.
                public static Texture Wood34 => WoodsInc.Get<Texture>("T_Wood34");

                /// Orangish, with a grain more like a veneer than a plank
                public static Texture Wood35 => WoodsInc.Get<Texture>("T_Wood35");



                // ReSharper restore InconsistentNaming
            }

            public static class Pigments
            {
                // ReSharper disable InconsistentNaming
                public static Pigment WoodGrain1A => WoodsInc.Get<Pigment>("P_WoodGrain1A");
                public static Pigment WoodGrain1B => WoodsInc.Get<Pigment>("P_WoodGrain1B");
                public static Pigment WoodGrain2A => WoodsInc.Get<Pigment>("P_WoodGrain2A");
                public static Pigment WoodGrain2B => WoodsInc.Get<Pigment>("P_WoodGrain2B");
                public static Pigment WoodGrain3A => WoodsInc.Get<Pigment>("P_WoodGrain3A");
                public static Pigment WoodGrain3B => WoodsInc.Get<Pigment>("P_WoodGrain3B");
                public static Pigment WoodGrain4A => WoodsInc.Get<Pigment>("P_WoodGrain4A");
                public static Pigment WoodGrain4B => WoodsInc.Get<Pigment>("P_WoodGrain4B");
                public static Pigment WoodGrain5A => WoodsInc.Get<Pigment>("P_WoodGrain5A");
                public static Pigment WoodGrain5B => WoodsInc.Get<Pigment>("P_WoodGrain5B");
                public static Pigment WoodGrain6A => WoodsInc.Get<Pigment>("P_WoodGrain6A");
                public static Pigment WoodGrain6B => WoodsInc.Get<Pigment>("P_WoodGrain6B");
                public static Pigment WoodGrain7A => WoodsInc.Get<Pigment>("P_WoodGrain7A");
                public static Pigment WoodGrain7B => WoodsInc.Get<Pigment>("P_WoodGrain7B");
                public static Pigment WoodGrain8A => WoodsInc.Get<Pigment>("P_WoodGrain8A");
                public static Pigment WoodGrain8B => WoodsInc.Get<Pigment>("P_WoodGrain8B");
                public static Pigment WoodGrain9A => WoodsInc.Get<Pigment>("P_WoodGrain9A");
                public static Pigment WoodGrain9B => WoodsInc.Get<Pigment>("P_WoodGrain9B");
                public static Pigment WoodGrain10A => WoodsInc.Get<Pigment>("P_WoodGrain10A");
                public static Pigment WoodGrain10B => WoodsInc.Get<Pigment>("P_WoodGrain10B");
                public static Pigment WoodGrain11A => WoodsInc.Get<Pigment>("P_WoodGrain11A");
                public static Pigment WoodGrain11B => WoodsInc.Get<Pigment>("P_WoodGrain11B");
                public static Pigment WoodGrain12A => WoodsInc.Get<Pigment>("P_WoodGrain12A");
                public static Pigment WoodGrain12B => WoodsInc.Get<Pigment>("P_WoodGrain12B");
                public static Pigment WoodGrain13A => WoodsInc.Get<Pigment>("P_WoodGrain13A");
                public static Pigment WoodGrain13B => WoodsInc.Get<Pigment>("P_WoodGrain13B");
                public static Pigment WoodGrain14A => WoodsInc.Get<Pigment>("P_WoodGrain14A");
                public static Pigment WoodGrain14B => WoodsInc.Get<Pigment>("P_WoodGrain14B");
                public static Pigment WoodGrain15A => WoodsInc.Get<Pigment>("P_WoodGrain15A");
                public static Pigment WoodGrain15B => WoodsInc.Get<Pigment>("P_WoodGrain15B");
                public static Pigment WoodGrain16A => WoodsInc.Get<Pigment>("P_WoodGrain16A");
                public static Pigment WoodGrain16B => WoodsInc.Get<Pigment>("P_WoodGrain16B");
                public static Pigment WoodGrain17A => WoodsInc.Get<Pigment>("P_WoodGrain17A");
                public static Pigment WoodGrain17B => WoodsInc.Get<Pigment>("P_WoodGrain17B");
                public static Pigment WoodGrain18A => WoodsInc.Get<Pigment>("P_WoodGrain18A");
                public static Pigment WoodGrain18B => WoodsInc.Get<Pigment>("P_WoodGrain18B");
                public static Pigment WoodGrain19A => WoodsInc.Get<Pigment>("P_WoodGrain19A");
                public static Pigment WoodGrain19B => WoodsInc.Get<Pigment>("P_WoodGrain19B");
                // ReSharper disable InconsistentNaming

            }

            public static class ColorMaps
            {
                // ReSharper disable InconsistentNaming
                public static ColorMap Wood1A => WoodsInc.Get<ColorMap>("M_Wood1A");
                public static ColorMap Wood1B => WoodsInc.Get<ColorMap>("M_Wood1B");
                public static ColorMap Wood2A => WoodsInc.Get<ColorMap>("M_Wood2A");
                public static ColorMap Wood2B => WoodsInc.Get<ColorMap>("M_Wood2B");
                public static ColorMap Wood3A => WoodsInc.Get<ColorMap>("M_Wood3A");
                public static ColorMap Wood3B => WoodsInc.Get<ColorMap>("M_Wood3B");
                public static ColorMap Wood4A => WoodsInc.Get<ColorMap>("M_Wood4A");
                public static ColorMap Wood4B => WoodsInc.Get<ColorMap>("M_Wood4B");
                public static ColorMap Wood5A => WoodsInc.Get<ColorMap>("M_Wood5A");
                public static ColorMap Wood5B => WoodsInc.Get<ColorMap>("M_Wood5B");
                public static ColorMap Wood6A => WoodsInc.Get<ColorMap>("M_Wood6A");
                public static ColorMap Wood6B => WoodsInc.Get<ColorMap>("M_Wood6B");
                public static ColorMap Wood7A => WoodsInc.Get<ColorMap>("M_Wood7A");
                public static ColorMap Wood7B => WoodsInc.Get<ColorMap>("M_Wood7B");
                public static ColorMap Wood8A => WoodsInc.Get<ColorMap>("M_Wood8A");
                public static ColorMap Wood8B => WoodsInc.Get<ColorMap>("M_Wood8B");
                public static ColorMap Wood9A => WoodsInc.Get<ColorMap>("M_Wood9A");
                public static ColorMap Wood9B => WoodsInc.Get<ColorMap>("M_Wood9B");
                public static ColorMap Wood10A => WoodsInc.Get<ColorMap>("M_Wood10A");
                public static ColorMap Wood10B => WoodsInc.Get<ColorMap>("M_Wood10B");
                public static ColorMap Wood11A => WoodsInc.Get<ColorMap>("M_Wood11A");
                public static ColorMap Wood11B => WoodsInc.Get<ColorMap>("M_Wood11B");
                public static ColorMap Wood12A => WoodsInc.Get<ColorMap>("M_Wood12A");
                public static ColorMap Wood12B => WoodsInc.Get<ColorMap>("M_Wood12B");
                public static ColorMap Wood13A => WoodsInc.Get<ColorMap>("M_Wood13A");
                public static ColorMap Wood13B => WoodsInc.Get<ColorMap>("M_Wood13B");
                public static ColorMap Wood14A => WoodsInc.Get<ColorMap>("M_Wood14A");
                public static ColorMap Wood14B => WoodsInc.Get<ColorMap>("M_Wood14B");
                public static ColorMap Wood15A => WoodsInc.Get<ColorMap>("M_Wood15A");
                public static ColorMap Wood15B => WoodsInc.Get<ColorMap>("M_Wood15B");
                public static ColorMap Wood16A => WoodsInc.Get<ColorMap>("M_Wood16A");
                public static ColorMap Wood16B => WoodsInc.Get<ColorMap>("M_Wood16B");
                public static ColorMap Wood17A => WoodsInc.Get<ColorMap>("M_Wood17A");
                public static ColorMap Wood17B => WoodsInc.Get<ColorMap>("M_Wood17B");
                public static ColorMap Wood18A => WoodsInc.Get<ColorMap>("M_Wood18A");
                public static ColorMap Wood18B => WoodsInc.Get<ColorMap>("M_Wood18B");
                public static ColorMap Wood19A => WoodsInc.Get<ColorMap>("M_Wood19A");
                public static ColorMap Wood19B => WoodsInc.Get<ColorMap>("M_Wood19B");

                // ReSharper disable InconsistentNaming
            }
        }
    }
}