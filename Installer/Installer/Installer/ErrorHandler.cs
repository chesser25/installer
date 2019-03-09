using System.Windows;

namespace Installer
{
    class ErrorHandler : IErrorHandler
    {
        public void ShowError(string message)
        {
            MessageBox.Show(message, Constants.ERROR_CAPTION, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void ShowWarning(string message)
        {
            MessageBox.Show(message, Constants.WARNING_CAPTION, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public void ShowInfo(string message)
        {
            MessageBox.Show(message, Constants.INFO_CAPTION, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
