using System;
using System.Drawing;
using Pastel;
using static Jaunt.Engine;
using static Jaunt.Dialog;

namespace Jaunt
{
    class Program
    {
        static void Main()

        {
            ConsoleFormat();
            BannerAnimation(jaunt, Color.Turquoise, Color.BlueViolet);
            TextDelay(ch1_01, Color.Turquoise, Objects());
            Advance("What will you do?".Pastel(Color.Tomato), "examine shimmer");
        }
    }
}