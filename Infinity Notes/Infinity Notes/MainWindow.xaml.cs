using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Infinity_Notes
{
    public partial class MainWindow : Window
    {
        public static MainWindow Components { get; private set; }

        bool settingsButtonFirstClick = true;
        string fileDialogFilter = "All Files (*.*)|*.*|Inote Files (*.inote)|*.inote|TXT Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";

        public MainWindow()
        {
            InitializeComponent();
            Components = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentsLoad.TextFontSizeLoad();
            ComponentsLoad.TextFontLoad();
            ComponentsLoad.DarkThemeLoad();
            ComponentsLoad.TextWrappingLoad();
        }

        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = fileDialogFilter;
            saveFileDialog.FilterIndex = 2;  
            saveFileDialog.Title = "Export";
            saveFileDialog.FileName = "Note";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, mainInput.Text);
            } 
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = fileDialogFilter;
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "Open";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                string openedFileText = File.ReadAllText(openFileDialog.FileName);
                mainInput.Text = openedFileText;
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (settingsButtonFirstClick == true)
            {
                mainFrame.Content = new SettingsPage();
                mainInput.Visibility = Visibility.Hidden;
                mainMenu.Visibility = Visibility.Hidden;
                settingsButtonFirstClick = false;
            }
            else
            {
                mainFrame.NavigationService.Navigate(null);
                mainInput.Visibility = Visibility.Visible;
                mainMenu.Visibility = Visibility.Visible;
                settingsButtonFirstClick = true;
            }
        }
    }
}
