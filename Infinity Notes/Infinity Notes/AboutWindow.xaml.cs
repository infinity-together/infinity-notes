using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Infinity_Notes
{
    public partial class AboutWindow : Window
    {
        string licenseUri = "https://www.gnu.org/licenses/gpl-3.0.en.html";
        string sourceCodeUri = "https://github.com/infinity-together/infinity-notes";

        public AboutWindow()
        {
            InitializeComponent();
        }

        private void LicenseLink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("explorer", licenseUri);
        }

        private void sourceCodeName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("explorer", sourceCodeUri);
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}