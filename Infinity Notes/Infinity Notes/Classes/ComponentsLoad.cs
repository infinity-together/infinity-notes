using System;
using System.Windows.Media;
using System.Windows;
using FontFamily = System.Windows.Media.FontFamily;

namespace Infinity_Notes
{
    public static class ComponentsLoad
    {
        public static void TextFontSizeLoad()
        {
            MainWindow.Components.mainInput.FontSize = Properties.Settings.Default.textFontSize;
        }

        public static void TextFontLoad()
        {
            void SetDefaultFont(string fontName)
            {
                MainWindow.Components.mainInput.FontFamily = new FontFamily(fontName);
            }

            void SetExternalFont(string fontName)
            {
                MainWindow.Components.mainInput.FontFamily = new FontFamily(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Fonts/#" + fontName, UriKind.Absolute), fontName);
            }

            switch (Properties.Settings.Default.textFont)
            {
                case 1:
                    SetDefaultFont("Segoe UI");
                    break;
                case 2:
                    SetDefaultFont("Cascadia Code");
                    break;
                case 3:
                    SetDefaultFont("Courier New");
                    break;
                case 4:
                    SetDefaultFont("Georgia");
                    break;
                case 5:
                    SetExternalFont("Inter");
                    break;
                case 6:
                    SetExternalFont("Raleway");
                    break;
            }
        }

        public static void DarkThemeLoad()
        {
            if (Properties.Settings.Default.colorTheme == 1)
            {
                MainWindow.Components.mainInput.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#2e2e2e");
                MainWindow.Components.mainInput.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#fafafa");
            }
        }

        public static void TextWrappingLoad()
        {
            if (Properties.Settings.Default.textWrapping == 1)
            {
                MainWindow.Components.mainInput.TextWrapping = TextWrapping.Wrap;
            }
            else
            {
                MainWindow.Components.mainInput.TextWrapping = TextWrapping.NoWrap;
            }
        }
    }
}
