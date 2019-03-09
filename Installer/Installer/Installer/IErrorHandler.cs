namespace Installer
{
    interface IErrorHandler
    {
        void ShowError(string message);
        void ShowWarning(string message);
    }
}
