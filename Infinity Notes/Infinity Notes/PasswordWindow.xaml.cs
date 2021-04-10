using System.Windows;
using System.Windows.Controls;

namespace Infinity_Notes
{
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void showPassword_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                pwdTextBox.Text = pwdPasswordBox.Password; 
                pwdTextBox.Visibility = Visibility.Visible; 
                pwdPasswordBox.Visibility = Visibility.Hidden; 
            }
            else
            {
                pwdPasswordBox.Password = pwdTextBox.Text; 
                pwdTextBox.Visibility = Visibility.Hidden; 
                pwdPasswordBox.Visibility = Visibility.Visible; 
            }
        }

        private void authentificateButton_Click(object sender, RoutedEventArgs e)
        {
            Authentificate();
        }

        void Authentificate()
        {
            if (Properties.Settings.Default.accountPassword == pwdPasswordBox.Password || Properties.Settings.Default.accountPassword == pwdTextBox.Text)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                incorrectPasswordLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
