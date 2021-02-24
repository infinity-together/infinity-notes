using System.Windows;
using System.Windows.Controls;

namespace Infinity_Notes
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetSettings();
        }

        public void GetSettings()
        {
            textSizeSettingsInput.Text = Properties.Settings.Default.textFontSize.ToString();
            fontsSettingsChose.SelectedIndex = Properties.Settings.Default.textFont;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.textFontSize = double.Parse(textSizeSettingsInput.Text);
            Properties.Settings.Default.textFont = fontsSettingsChose.SelectedIndex;

            Properties.Settings.Default.Save();
        }

        private void settingSaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }
    }
}
