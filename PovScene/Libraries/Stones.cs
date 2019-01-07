/*
 * The list of textures was extracted from 'stones1.inc' and 'stones2.inc, part of the POV-Ray distribution:
 * 
 * https:///github.com/POV-Ray/povray/blob/master/distribution/include/stones1.inc
 * https:///github.com/POV-Ray/povray/blob/master/distribution/include/stones2.inc
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
        public static class Stones
        {
            // ReSharper disable InconsistentNaming
            /// Gray Tan with Rose
            public static Texture Granite0 => StonesInc.Get<Texture>("T_Grnt0");

            /// Creamy Whites with yellow & light gray
            public static Texture Granite1 => StonesInc.Get<Texture>("T_Grnt1");

            /// Deep Cream with light rose, yellow orchid & tan
            public static Texture Granite2 => StonesInc.Get<Texture>("T_Grnt2");

            /// Warm tans olive & light rose with cream
            public static Texture Granite3 => StonesInc.Get<Texture>("T_Grnt3");

            /// Orchid sand & mouve
            public static Texture Granite4 => StonesInc.Get<Texture>("T_Grnt4");

            /// Medium Mauve Med.Rose & deep cream
            public static Texture Granite5 => StonesInc.Get<Texture>("T_Grnt5");

            /// Med. Orchid Olive & Dark Tan "mud pie"
            public static Texture Granite6 => StonesInc.Get<Texture>("T_Grnt6");

            /// Dark Orchid Olive & Dark Putty
            public static Texture Granite7 => StonesInc.Get<Texture>("T_Grnt7");

            /// Rose & Light cream Yellows
            public static Texture Granite8 => StonesInc.Get<Texture>("T_Grnt8");

            /// Light Steely Grays
            public static Texture Granite9 => StonesInc.Get<Texture>("T_Grnt9");

            /// Gray Creams & lavender tans
            public static Texture Granite10 => StonesInc.Get<Texture>("T_Grnt10");

            /// Creams & Grays Kakhi
            public static Texture Granite11 => StonesInc.Get<Texture>("T_Grnt11");

            /// Tan Cream & Red Rose
            public static Texture Granite12 => StonesInc.Get<Texture>("T_Grnt12");

            /// Cream Rose orange
            public static Texture Granite13 => StonesInc.Get<Texture>("T_Grnt13");

            /// Cream Rose & light moss & light Violet
            public static Texture Granite14 => StonesInc.Get<Texture>("T_Grnt14");

            /// Black with subtle chroma
            public static Texture Granite15 => StonesInc.Get<Texture>("T_Grnt15");

            /// White Cream & Peach
            public static Texture Granite16 => StonesInc.Get<Texture>("T_Grnt16");

            /// Bug Juice & Green
            public static Texture Granite17 => StonesInc.Get<Texture>("T_Grnt17");

            /// Rose & cream yellow
            public static Texture Granite18 => StonesInc.Get<Texture>("T_Grnt18");

            /// Gray Marble with White feather Viens
            public static Texture Granite19 => StonesInc.Get<Texture>("T_Grnt19");

            /// White Marble with Gray feather Viens
            public static Texture Granite20 => StonesInc.Get<Texture>("T_Grnt20");

            /// Green Jade
            public static Texture Granite21 => StonesInc.Get<Texture>("T_Grnt21");

            /// Clear with White feather Viens ----- This one does contain Transmit
            public static Texture Granite22 => StonesInc.Get<Texture>("T_Grnt22");

            /// Light Tan to Mouve
            public static Texture Granite23 => StonesInc.Get<Texture>("T_Grnt23");

            /// Light Grays
            public static Texture Granite24 => StonesInc.Get<Texture>("T_Grnt24");

            /// Moss Greens & Tan
            public static Texture Granite25 => StonesInc.Get<Texture>("T_Grnt25");

            /// Salmon with thin Green Viens
            public static Texture Granite26 => StonesInc.Get<Texture>("T_Grnt26");

            /// Dark Green & Browns
            public static Texture Granite27 => StonesInc.Get<Texture>("T_Grnt27");

            /// Red Swirl
            public static Texture Granite28 => StonesInc.Get<Texture>("T_Grnt28");

            /// White Tan & thin Reds
            public static Texture Granite29 => StonesInc.Get<Texture>("T_Grnt29");

            /// Translucent Granite0
            public static Texture Granite0a => StonesInc.Get<Texture>("T_Grnt0a");

            /// Translucent Granite1
            public static Texture Granite1a => StonesInc.Get<Texture>("T_Grnt1a");

            /// Translucent Granite2
            public static Texture Granite2a => StonesInc.Get<Texture>("T_Grnt2a");

            /// Translucent Granite3
            public static Texture Granite3a => StonesInc.Get<Texture>("T_Grnt3a");

            /// Translucent Granite4
            public static Texture Granite4a => StonesInc.Get<Texture>("T_Grnt4a");

            /// Translucent Granite5
            public static Texture Granite5a => StonesInc.Get<Texture>("T_Grnt5a");

            /// Translucent Granite6
            public static Texture Granite6a => StonesInc.Get<Texture>("T_Grnt6a");

            /// Translucent Granite7
            public static Texture Granite7a => StonesInc.Get<Texture>("T_Grnt7a");

            /// Aqua Tints
            public static Texture Granite8a => StonesInc.Get<Texture>("T_Grnt8a");

            /// Transmit Creams With Cracks
            public static Texture Granite9a => StonesInc.Get<Texture>("T_Grnt9a");

            /// Transmit Cream Rose & light yellow
            public static Texture Granite10a => StonesInc.Get<Texture>("T_Grnt10a");

            /// Transmit Light Grays
            public static Texture Granite11a => StonesInc.Get<Texture>("T_Grnt11a");

            /// Transmit Creams & Tans
            public static Texture Granite12a => StonesInc.Get<Texture>("T_Grnt12a");

            /// Transmit Creams & Grays
            public static Texture Granite13a => StonesInc.Get<Texture>("T_Grnt13a");

            /// Cream Rose & light moss
            public static Texture Granite14a => StonesInc.Get<Texture>("T_Grnt14a");

            /// Transmit Sand & light Orange
            public static Texture Granite15a => StonesInc.Get<Texture>("T_Grnt15a");

            /// Cream Rose & light moss
            public static Texture Granite16a => StonesInc.Get<Texture>("T_Grnt16a");

            public static Texture Granite17a => StonesInc.Get<Texture>("T_Grnt17a");
            public static Texture Granite18a => StonesInc.Get<Texture>("T_Grnt18a");

            /// Gray Marble with White feather Viens with Transmit
            public static Texture Granite19a => StonesInc.Get<Texture>("T_Grnt19a");

            /// White Feature Viens
            public static Texture Granite20a => StonesInc.Get<Texture>("T_Grnt20a");

            /// Thinner White Feature Viens
            public static Texture Granite21a => StonesInc.Get<Texture>("T_Grnt21a");

            public static Texture Granite22a => StonesInc.Get<Texture>("T_Grnt22a");

            /// Transparent Green Moss Colors
            public static Texture Granite23a => StonesInc.Get<Texture>("T_Grnt23a");

            public static Texture Granite24a => StonesInc.Get<Texture>("T_Grnt24a");

            /// Crack & OverTint /Red
            public static Texture Crack1 => StonesInc.Get<Texture>("T_Crack1");

            /// Transmit  Dark Cracks
            public static Texture Crack2 => StonesInc.Get<Texture>("T_Crack2");

            /// Overtint Green with Black Cracks
            public static Texture Crack3 => StonesInc.Get<Texture>("T_Crack3");

            /// Overtint with White Crack
            public static Texture Crack4 => StonesInc.Get<Texture>("T_Crack4");

            /// Deep Rose & Green Marble with large White Swirls
            public static Texture Stone1 => StonesInc.Get<Texture>("T_Stone1");

            /// Light Greenish Tan Marble with Agate style veining
            public static Texture Stone2 => StonesInc.Get<Texture>("T_Stone2");

            /// Rose & Yellow Marble with fog white veining
            public static Texture Stone3 => StonesInc.Get<Texture>("T_Stone3");

            /// Tan Marble with Rose patches
            public static Texture Stone4 => StonesInc.Get<Texture>("T_Stone4");

            /// White Cream Marble with Pink veining
            public static Texture Stone5 => StonesInc.Get<Texture>("T_Stone5");

            /// Rose & Yellow Cream Marble
            public static Texture Stone6 => StonesInc.Get<Texture>("T_Stone6");

            /// Light Coffee Marble with darker patches
            public static Texture Stone7 => StonesInc.Get<Texture>("T_Stone7");

            /// Gray Granite with white patches
            public static Texture Stone8 => StonesInc.Get<Texture>("T_Stone8");

            /// White & Light Blue Marble with light violets
            public static Texture Stone9 => StonesInc.Get<Texture>("T_Stone9");

            /// Dark Brown & Tan swirl Granite with gray undertones
            public static Texture Stone10 => StonesInc.Get<Texture>("T_Stone10");

            /// Rose & White Marble with dark tan swirl
            public static Texture Stone11 => StonesInc.Get<Texture>("T_Stone11");

            /// White & Pinkish Tan Marble
            public static Texture Stone12 => StonesInc.Get<Texture>("T_Stone12");

            /// Medium Gray Blue Marble
            public static Texture Stone13 => StonesInc.Get<Texture>("T_Stone13");

            /// Tan & Olive Marble with gray white veins
            public static Texture Stone14 => StonesInc.Get<Texture>("T_Stone14");

            /// Deep Gray Marble with white veining
            public static Texture Stone15 => StonesInc.Get<Texture>("T_Stone15");

            /// Peach & Yellow Marble with white veining
            public static Texture Stone16 => StonesInc.Get<Texture>("T_Stone16");

            /// White Marble with gray veining
            public static Texture Stone17 => StonesInc.Get<Texture>("T_Stone17");

            /// Green Jade with white veining
            public static Texture Stone18 => StonesInc.Get<Texture>("T_Stone18");

            /// Peach Granite with white patches & green trim
            public static Texture Stone19 => StonesInc.Get<Texture>("T_Stone19");

            /// Brown & Olive Marble with white veining
            public static Texture Stone20 => StonesInc.Get<Texture>("T_Stone20");

            /// Red Marble with gray & white veining
            public static Texture Stone21 => StonesInc.Get<Texture>("T_Stone21");

            /// Dark Tan Marble with gray & white veining
            public static Texture Stone22 => StonesInc.Get<Texture>("T_Stone22");

            /// Peach & Cream Marble with orange veining
            public static Texture Stone23 => StonesInc.Get<Texture>("T_Stone23");

            /// Green & Tan Moss Marble
            public static Texture Stone24 => StonesInc.Get<Texture>("T_Stone24");

            public static Texture Stone25 => StonesInc.Get<Texture>("T_Stone25");
            public static Texture Stone26 => StonesInc.Get<Texture>("T_Stone26");
            public static Texture Stone27 => StonesInc.Get<Texture>("T_Stone27");
            public static Texture Stone28 => StonesInc.Get<Texture>("T_Stone28");
            public static Texture Stone29 => StonesInc.Get<Texture>("T_Stone29");
            public static Texture Stone30 => StonesInc.Get<Texture>("T_Stone30");
            public static Texture Stone31 => StonesInc.Get<Texture>("T_Stone31");
            public static Texture Stone32 => StonesInc.Get<Texture>("T_Stone32");
            public static Texture Stone33 => StonesInc.Get<Texture>("T_Stone33");
            public static Texture Stone34 => StonesInc.Get<Texture>("T_Stone34");

            /// White marble
            public static Texture Stone35 => StonesInc.Get<Texture>("T_Stone35");

            /// Creamy coffee w/greenish-grey veins & faint avacado swirls
            public static Texture Stone36 => StonesInc.Get<Texture>("T_Stone36");

            /// Olive greens w/lighter swirls & hints of salmon
            public static Texture Stone37 => StonesInc.Get<Texture>("T_Stone37");

            /// Deep rich coffee w/darker veins & lots of creamy swirl
            public static Texture Stone38 => StonesInc.Get<Texture>("T_Stone38");

            /// Light mauve w/large plum swirls
            public static Texture Stone39 => StonesInc.Get<Texture>("T_Stone39");

            /// Creamy aqua w/green hi-lites & subtle hints of grey
            public static Texture Stone40 => StonesInc.Get<Texture>("T_Stone40");

            /// Dark powder blue w/steel blue & grey swirls
            public static Texture Stone41 => StonesInc.Get<Texture>("T_Stone41");

            /// Brick red w/yellow-green swirls
            public static Texture Stone42 => StonesInc.Get<Texture>("T_Stone42");

            /// Rusty red w/cream swirls and duck overtones
            public static Texture Stone43 => StonesInc.Get<Texture>("T_Stone43");

            /// Its a dark, dull, bumpy rock texture.
            public static Texture Stone44 => StonesInc.Get<Texture>("T_Stone44");

            // ReSharper enable InconsistentNaming
        }
    }
}
