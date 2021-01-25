using Colorful;
using Console = Colorful.Console;
using static Jaunt.Engine;

namespace Jaunt
{
    class Prefabs
    {
        public static class TextSpeed
        {
            public const int
            tDelay = 25,
            Fast = 50,
            Banner = 150,
            Slow = 600,
            Turtle = 1200,
            bannerEnd = 2400;
        }

        public static class Beeps
        {
            public const int
            iBannerMinFreq = 300, iBannerMaxFreq = 350,
            iTextMinFreq = 300, iTextMaxFreq = 350;
        }

        public static class Hex
        {
            public const int
            Mint   = 0x89E6C6,            //Lightest
            Pink   = 0xEBA2DC,            //   |
            Orange = 0xF59A37,            //   V
            Blue   = 0x2F96E9,            //Darkest  
            Red    = 0xE71D36,
            Purple = 0x54428E;
        }

        public static Formatter[] Objects()
        {
            Formatter[] coloredText = new Formatter[]{
                                      new Formatter("shimmer", MyColor(Hex.Orange))
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
