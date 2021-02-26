using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using FontFamily = System.Windows.Media.FontFamily;

namespace Infinity_Notes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            double textFontSize = Properties.Settings.Default.textFontSize;

            mainInput.FontSize = textFontSize;

            if (Properties.Settings.Default.textFont == 1)
            {
                mainInput.FontFamily = new FontFamily("Segoe UI");
            }
            else if (Properties.Settings.Default.textFont == 2)
            {
                mainInput.FontFamily = new FontFamily(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Fonts/#" + "Cascadia Code", UriKind.Absolute), "Cascadia Code"); 
            }
            else if (Properties.Settings.Default.textFont == 3)
            {
                mainInput.FontFamily = new FontFamily(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Fonts/#" + "Courier New", UriKind.Absolute), "Courier New"); 
            }
            else if (Properties.Settings.Default.textFont == 4)
            {
                mainInput.FontFamily = new FontFamily(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Fonts/#" + "Georgia", UriKind.Absolute), "Georgia"); 
            }

            if (Properties.Settings.Default.colorTheme == 1) // Dark Theme
            {
                mainInput.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#2e2e2e");
                mainInput.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#fafafa");

                mainFrame.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#2e2e2e");
            }
        }

        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All Files (*.*)|*.*|Inote Files (*.inote)|*.inote|TXT Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
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
            openFileDialog.Filter = "All Files (*.*)|*.*|Inote Files (*.inote)|*.inote|TXT Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "Open";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                string openedFileText = File.ReadAllText(openFileDialog.FileName);
                mainInput.Text = openedFileText;
            }
        }

        bool settingsButtonFirstClick = true;

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (settingsButtonFirstClick == true)
            {
                mainFrame.Content = new SettingsPage();
                mainInput.Visibility = Visibility.Hidden; 
                mainInput.IsEnabled = false;
                settingsButtonFirstClick = false;
            }
            else
            {
                mainFrame.NavigationService.Navigate(null);
                mainInput.Visibility = Visibility.Visible;
                mainInput.IsEnabled = true;
                settingsButtonFirstClick = true;
            }
        }
    }
}
