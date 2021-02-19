using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Infinity_Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exportButton_Click(object sender, EventArgs e)
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

        private void openButton_Click(object sender, EventArgs e)
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
    }
}
