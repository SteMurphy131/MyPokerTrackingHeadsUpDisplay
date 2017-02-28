using System.Windows.Controls;
using System.Windows.Media;

namespace MyPokerTrackingHeadsUpDisplay
{
    public static class ExtensionMethods
    {
        public static void SetColour(this ProgressBar bar, double percent)
        {
            bar.Foreground = percent > 15
                ? new SolidColorBrush(Colors.Green)
                : new SolidColorBrush(Colors.Red);
        }
    }
}