using System.Drawing;
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
            TextDelayFormatter(ch1_01, Objects(), Color.Turquoise);
            Advance("What will you do?", "examine shimmer", Color.DodgerBlue);
        }
    }
}