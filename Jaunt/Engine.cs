using System;
using System.Linq;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using Pastel;
using Colorful;
using Console = Colorful.Console;

namespace Jaunt
{
    class Engine
    {
        public static void Sleep(int ms) => Thread.Sleep(ms);

        public static void ConsoleFormat()
        {
            Console.Title = "";
            Console.WindowWidth = 50;
            Console.WindowHeight = 25;
            Console.BufferWidth = 50;
            Console.BufferHeight = 25;
        }

        public static void SoundBeep(int startRnd, int endRnd, int delay)
        {
            Random rnd = new Random();
            int freq = rnd.Next(startRnd, endRnd);
            Console.Beep(freq, delay);
        }

        public static class Speed
        {
            public const int
            Faster = 25,
            Fast = 50,
            Medium = 150,
            Slow = 600,
            Turtle = 1200,
            Banner = 2400;
        }

        public static void BannerAnimation(string[] bannerStrings, Color startColor, Color endColor, int delay = (int)Speed.Medium)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < bannerStrings.Length; i++)
            {
                var padding = new string(' ', (Console.WindowWidth - bannerStrings[i].Length) / 2);
                Console.Write(padding);
                Console.WriteLine(bannerStrings[i].Pastel(ColorLerp(startColor, endColor, (float)i / (bannerStrings.Length - 1))));
                SoundBeep(150, 350, delay);
            }
            Sleep(Speed.Banner);
            Console.Clear();
            Console.CursorVisible = true;
        }
        public static void TextDelayF(string message, Color color, Formatter[] formatter, int delay = (int)Speed.Faster)
        {
            var messageList = Regex.Split(message, @"{\d+}").Select(x => (x, color)).ToList();
            for (int i = 0; i < formatter.Length; ++i)
            {
                messageList.Insert(1 + i * 2, ((string)formatter[i].Target, formatter[i].Color));
            }
            foreach (var (subMessage, messageColor) in messageList)
            {

                foreach (char character in subMessage)
                {
                    SoundBeep(150, 350, delay);
                    Console.Write(character, messageColor);
                    Thread.Sleep(delay);
                }
            }
            Sleep(Speed.Slow);
            Console.WriteLine();
        }

        public static void TextDelay(string message, Color color, int delay = (int)Speed.Faster)
        {
            foreach (char character in message)
            {
                SoundBeep(150, 350, delay);
                Console.Write(character, color);
                Thread.Sleep(delay);
            }

        }

        public static Formatter[] Objects()
        {
            Formatter[] coloredText = new Formatter[]
            {
                new Formatter("shimmer", Color.GreenYellow)
            };
            return coloredText;
        }

        public static void Advance(string writeOutput, string required)
        {
            string input;
            Console.WriteLine(writeOutput, Color.BlanchedAlmond);
            input = Console.ReadLine();

            while (!input.Equals(required, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Try Again".Pastel(Color.Red));
                input = Console.ReadLine();
            }
        }

        public static float Lerp(float value1, float value2, float lerpAmount)
        {
            float x = value2 - value1;
            x *= lerpAmount;
            return value1 + x;
        }
        public static Color ColorLerp(Color startColor, Color endColor, float lerpAmount)
                   => Color.FromArgb((byte)Lerp(startColor.R, endColor.R, lerpAmount),
                                     (byte)Lerp(startColor.G, endColor.G, lerpAmount),
                                     (byte)Lerp(startColor.B, endColor.B, lerpAmount));

    }
}
