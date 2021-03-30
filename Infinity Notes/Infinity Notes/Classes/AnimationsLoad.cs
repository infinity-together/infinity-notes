using System.Windows.Media.Animation;
using System;
using System.Windows.Controls;

namespace Infinity_Notes
{
    public static class AnimationsLoad
    {
        public static void LoadAnimations()
        {
            if (Properties.Settings.Default.animationsWork == 1)
            {
                LoadSearchInputAnim();
            }
        }

        static void LoadSearchInputAnim()
        {
            DoubleAnimation searchInputAnim = new DoubleAnimation();
            searchInputAnim.From = 50;
            searchInputAnim.To = 200;
            searchInputAnim.Duration = TimeSpan.FromSeconds(0.6);
            MainWindow.Components.searchInput.BeginAnimation(Button.WidthProperty, searchInputAnim);
        }
    }
}
