using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System;
using System.Windows.Input;

namespace Infinity_Notes
{
    public partial class SettingsPage : Page
    {
        public static SettingsPage Components { get; private set; }

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
            animationChose.SelectedIndex = Properties.Settings.Default.animationsWork;
            accountPasswordInput.Password = Properties.Settings.Default.accountPassword;
            passwordCheckChose.SelectedIndex = Properties.Settings.Default.passwordCheck;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.textFontSize = double.Parse(textSizeSettingsInput.Text);
            Properties.Settings.Default.textFont = fontsSettingsChose.SelectedIndex;
            Properties.Settings.Default.colorTheme = colorThemeChose.SelectedIndex;
            Properties.Settings.Default.animationsWork = animationChose.SelectedIndex;
            Properties.Settings.Default.accountPassword = accountPasswordInput.Password;
            Properties.Settings.Default.passwordCheck = passwordCheckChose.SelectedIndex;

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
            searchInput.BeginAnimation(WidthProperty, searchInputAnim);
        }

        void PasswordSecurityCheck()
        {
            if (accountPasswordInput.Password.Length <= 3)
            {
                badPasswordLabel.Visibility = Visibility.Visible;
                notBadPasswordLabel.Visibility = Visibility.Hidden;
                goodPasswordLabel.Visibility = Visibility.Hidden;
            }
            else if (accountPasswordInput.Password.Length <= 6)
            {
                badPasswordLabel.Visibility = Visibility.Hidden;
                notBadPasswordLabel.Visibility = Visibility.Visible;
                goodPasswordLabel.Visibility = Visibility.Hidden;
            }
            else if (accountPasswordInput.Password.Length >= 8)
            {
                badPasswordLabel.Visibility = Visibility.Hidden;
                notBadPasswordLabel.Visibility = Visibility.Hidden;
                goodPasswordLabel.Visibility = Visibility.Visible;
            }
        }

        void PasswordSecurityCheckHide()
        {
            badPasswordLabel.Visibility = Visibility.Hidden;
            notBadPasswordLabel.Visibility = Visibility.Hidden;
            goodPasswordLabel.Visibility = Visibility.Hidden;
        }

        private void accountPasswordInput_KeyUp(object sender, KeyEventArgs e)
        {
            PasswordSecurityCheck();
        }

        private void accountPasswordInput_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordSecurityCheckHide();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
    }
}
