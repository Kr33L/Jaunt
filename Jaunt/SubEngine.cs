using System;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;


namespace Jaunt {
    class SubEngine {
        public static void PlayBeep(int minFrequency, int maxFrequency, int delay) {
            Random randomF = new Random();
            int frequency = randomF.Next(minFrequency, maxFrequency);
            Console.Beep(frequency, delay);
        }

        public static float LinearInterpolation(float value1, float value2, float lerpAmount) {
            float x = value2 - value1;
            x *= lerpAmount;
            return value1 + x;
        }

        public static Color ColorLerp(Color startColor, Color endColor, float lerpAmount)
                   => Color.FromArgb((byte)LinearInterpolation(startColor.R, endColor.R, lerpAmount),
                                     (byte)LinearInterpolation(startColor.G, endColor.G, lerpAmount),
                                     (byte)LinearInterpolation(startColor.B, endColor.B, lerpAmount));

        public static Color MyColor(int hexCode) => ColorTranslator.FromHtml(hexCode.ToString());

        public static void Wait(int ms) => Thread.Sleep(ms);

    }
}