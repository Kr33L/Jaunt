using static Jaunt.MainEngine;
using static Jaunt.SubEngine;
using static Jaunt.Dialogue;
using static Jaunt.Prefab;

namespace Jaunt {
    class Program {
        static void Main() {
            ConsoleFormat();
            WriteBanner(titleBanner, MyColor(Palette.Gold), MyColor(Palette.Black));
            WriteBanner(chapterOne, MyColor(Palette.Gray), MyColor(Palette.Gold));
            WriteText(ch1_01, Object(), MyColor(Palette.Green));
            Advance("What will you do?", "examine shimmer", MyColor(Palette.Gold));
        }
    }
}