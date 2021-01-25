using System;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Text.RegularExpressions;
using Pastel;
using Colorful;
using Console = Colorful.Console;
using static Jaunt.Prefabs;

namespace Jaunt
{
    class Engine
    {
        /// <summary>
        /// Method for banner animation
        /// </summary>
        /// <param name="bannerStrings">array of strings used for banner</param>
        /// <param name="startColor">starting color for the linear interpolation</param>
        /// <param name="endColor">end color for the linear interpolation</param>
        /// <param name="delay">How fast the text is supposed to animate </param>
        public static void BannerAnimation(string[] bannerStrings, Color startColor, Color endColor, int delay = TextSpeed.Banner)
        {
            Console.CursorVisible = false;
           
            for(int i = 0; i < bannerStrings.Length; i++){
                var padding = new string(' ', (Console.WindowWidth - bannerStrings[i].Length) / 2);
                Console.WriteLine(padding + bannerStrings[i], ColorLerp(startColor, endColor, (float)i / (bannerStrings.Length - 1)));
                SoundBeep(Beeps.iBannerMinFreq, Beeps.iBannerMaxFreq, delay);
            }

            Wait(TextSpeed.bannerEnd);
            Console.Clear();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="formatter"></param>
        /// <param name="color"></param>
        /// <param name="delay"></param>
        public static void TextDelay(string message, Formatter[] formatter, Color color, int delay = TextSpeed.tDelay)
        {
            var messageList = Regex.Split(message, @"{\d+}").Select(x => (x, color)).ToList();
            for(int i = 0; i < formatter.Length; ++i) {
                messageList.Insert(1 + i * 2, ((string)formatter[i].Target, formatter[i].Color));
            }

            foreach(var (subMessage, messageColor) in messageList) {
                foreach(char character in subMessage) {
                    SoundBeep(Beeps.iTextMinFreq, Beeps.iTextMaxFreq, delay);
                    Console.Write(character, messageColor);
                    Wait(delay);
                }
            }
            Wait(TextSpeed.Fast);
            Console.WriteLine();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writeOutput"></param>
        /// <param name="required"></param>
        /// <param name="color"></param>
        /// <param name="delay"></param>
        public static void Advance(string writeOutput, string required, Color color, int delay = TextSpeed.tDelay)
        {
            foreach(char character in writeOutput) {
                SoundBeep(Beeps.iTextMinFreq, Beeps.iTextMaxFreq, delay);
                Console.Write(character, color);
                Wait(delay);
            }

            string input = Console.ReadLine();
            while(!input.Equals(required, StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine("Incorrect Input".Pastel(Color.FromArgb(0xE71D36)));
                input = Console.ReadLine();
            }
        }

        public static void SoundBeep(int startRnd, int endRnd, int delay)
        {
            Random rnd = new Random();
            int frequency = rnd.Next(startRnd, endRnd);
            Console.Beep(frequency, delay);
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

        public static Func<int, Color> MyColor = (int hexcode) => ColorTranslator.FromHtml(hexcode.ToString());
        
        //public static Color MyColor(int hexcode) => ColorTranslator.FromHtml(hexcode.ToString());// <<<<< Same as above

        public static void Wait(int ms) => Thread.Sleep(ms);

    }
}