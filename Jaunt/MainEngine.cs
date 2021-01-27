using System;
using System.Linq;
using System.Drawing;
using System.Text.RegularExpressions;
using Pastel;
using Colorful;
using Console = Colorful.Console;
using static Jaunt.Prefab;
using static Jaunt.SubEngine;

namespace Jaunt {
    class MainEngine {

        public static void WriteBanner(string[] bannerMessage, Color startColor, Color endColor, int delay = TextSpeed.Banner) {
            Console.CursorVisible = false;

            for(int i = 0;i < bannerMessage.Length;i++) {
                var centerText = new string(' ', (Console.WindowWidth - bannerMessage[i].Length) / 2);
                Console.WriteLine(centerText + bannerMessage[i], ColorLerp(startColor, endColor, (float)i / (bannerMessage.Length - 1)));
                PlayBeep(BeepFrequency.iBannerMinFreq, BeepFrequency.iBannerMaxFreq, delay);
            }

            Wait(TextSpeed.bannerEnd);
            Console.Clear();
            Console.CursorVisible = true;
        }

        public static void WriteText(string message, Formatter[] itemFormat, Color Color, int delay = TextSpeed.Fast) {
            var messageList = Regex.Split(message, @"{\d+}").Select(x => (x, Color)).ToList();

            for(int i = 0;i < itemFormat.Length;++i) {
                messageList.Insert(1 + i * 2, ((string)itemFormat[i].Target, itemFormat[i].Color));
            }

            foreach(var (subMessage, messageColor) in messageList) {
                foreach(char character in subMessage) {
                    PlayBeep(BeepFrequency.iTextMinFreq, BeepFrequency.iTextMaxFreq, delay);
                    Console.Write(character, messageColor);
                    Wait(delay);
                }
            }

            Wait(TextSpeed.Fast);
            Console.WriteLine();
        }

        public static void Advance(string message, string requiredMessage, Color color, int delay = TextSpeed.Fast) {
            foreach(char character in message) {
                PlayBeep(BeepFrequency.iTextMinFreq, BeepFrequency.iTextMaxFreq, delay);
                Console.Write(character, color);
                Wait(delay);
            }

            string input = Console.ReadLine();

            while(!input.Equals(requiredMessage, StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine("Incorrect Input".Pastel(MyColor(Palette.Purple)));
                input = Console.ReadLine();
            }
        }

    }
}