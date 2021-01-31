using static Jaunt.MainEngine;
using static Jaunt.SubEngine;
using static Jaunt.Dialogue;
using static Jaunt.Prefab;

namespace Jaunt {
    class Program {
        static void Main() {
            ConsoleFormat();
            WriteBanner(titleBanner, MyColor(Palette.Orange), MyColor(Palette.Green));
            WriteBanner(chapterOne, MyColor(Palette.Black), MyColor(Palette.Gold));
            WriteText(ch1_01, Object(), MyColor(Palette.Orange));
            Advance("What will you do?", "examine shimmer", MyColor(Palette.Gold));
        }
    }
}