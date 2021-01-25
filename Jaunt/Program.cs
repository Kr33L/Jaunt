using static Jaunt.Engine;
using static Jaunt.Dialog;
using static Jaunt.Prefabs;

namespace Jaunt
{
    class Program
    {
        static void Main()
        {
            ConsoleFormat();
            BannerAnimation(jaunt, MyColor(Hex.Mint), MyColor(Hex.Purple));
            TextDelay(ch1_01, Objects(), MyColor(Hex.Blue));
            Advance("What will you do?", "examine shimmer", MyColor(Hex.Pink));
        }
    }
}