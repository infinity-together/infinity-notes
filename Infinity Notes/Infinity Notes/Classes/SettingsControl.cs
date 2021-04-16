using System.Windows.Documents;

namespace Infinity_Notes
{
    class SettingsControl
    {
        public static string mainInputText = new TextRange(MainWindow.Components.mainInput.Document.ContentStart, MainWindow.Components.mainInput.Document.ContentEnd).Text;
    }
}
