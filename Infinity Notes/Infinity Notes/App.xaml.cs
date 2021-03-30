using System;
using System.Windows;

namespace Infinity_Notes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (Infinity_Notes.Properties.Settings.Default.passwordCheck == 1)
            {
                StartupUri = new Uri("PasswordWindow.xaml", UriKind.Relative);
            }
            else
            {
                StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            }
        }
    }
}
