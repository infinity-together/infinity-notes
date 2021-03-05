using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System;

namespace Infinity_Notes
{
    public partial class SettingsPage : Page
    {

        public SettingsPage()
        {
            InitializeComponent();

            LoadAnimations();
        }

        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetSettings();
        }

        public void GetSettings()
        {
            textSizeSettingsInput.Text = Properties.Settings.Default.textFontSize.ToString();
            fontsSettingsChose.SelectedIndex = Properties.Settings.Default.textFont;
            colorThemeChose.SelectedIndex = Properties.Settings.Default.colorTheme;
            textWrappingChose.SelectedIndex = Properties.Settings.Default.textWrapping;
            animationChose.SelectedIndex = Properties.Settings.Default.animationsWork;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.textFontSize = double.Parse(textSizeSettingsInput.Text);
            Properties.Settings.Default.textFont = fontsSettingsChose.SelectedIndex;
            Properties.Settings.Default.colorTheme = colorThemeChose.SelectedIndex;
            Properties.Settings.Default.textWrapping = textWrappingChose.SelectedIndex;
            Properties.Settings.Default.animationsWork = animationChose.SelectedIndex;

            Properties.Settings.Default.Save();
        }

        private void settingSaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        void LoadAnimations()
        {
            if (Properties.Settings.Default.animationsWork == 1)
            {
                LoadSearchInputAnim();
            }    
        }

        void LoadSearchInputAnim()
        {
            DoubleAnimation searchInputAnim = new DoubleAnimation();
            searchInputAnim.From = 50;
            searchInputAnim.To = 200;
            searchInputAnim.Duration = TimeSpan.FromSeconds(0.6);
            searchInput.BeginAnimation(Button.WidthProperty, searchInputAnim);
        }
    }
}
