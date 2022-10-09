using Colorful;
using Console = Colorful.Console;
using static Jaunt.SubEngine;

namespace Jaunt
{
    class Prefab
    {
        public static class TextSpeed
        {
            public const int
            Fast = 25,
            Medium = 75,
            Banner = 225,
            bannerEnd = 3000;
        }

        public static class BeepFrequency
        {
            public const int
            iBannerMinFreq = 300, iBannerMaxFreq = 345,
            iTextMinFreq = 275, iTextMaxFreq = 325;
        }

        public static class Palette
        {
            public const int
            Black = 0x000000,
            Gray = 0x646964,
            Purple = 0x55415f,
            Orange = 0xd77355,
            Gold = 0xe6c86e,
            Green = 0x64b964,
            Blue = 0x508cd7,
            Cyan = 0xdcf5ff;
        }

        public static Formatter[] Noun()
        {
            Formatter[] coloredText = new Formatter[]
            {
                                      new Formatter("Old Man:\n", MyColor(Palette.Blue)),
                                      new Formatter("shimmer", MyColor(Palette.Orange))


            };
            return coloredText;
        }

        public static void ConsoleFormat()
        {
            Console.Title = "";
            Console.WindowWidth = 50;
            Console.WindowHeight = 25;
            Console.BufferWidth = 50;
            Console.BufferHeight = 25;
        }
    }
}
