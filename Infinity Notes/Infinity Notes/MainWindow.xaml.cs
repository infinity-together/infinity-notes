using Microsoft.Win32;
using System;
using System.Drawing;
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
