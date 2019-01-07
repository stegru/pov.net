namespace PovScene.Util
{
    using System.Globalization;

    public static class Extensions
    {
        public static int FromHex(this string str)
        {
            return int.TryParse(str, NumberStyles.HexNumber, null, out int result) ? result : 0;
        }
        public static int FromHex(this char ch)
        {
            return ch.ToString().FromHex();
        }
    }
}