using System.Net;
using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Installer
{
    class Downloader
    {
        private static Downloader downloader;
        private IErrorHandler errorHandler;

        private Downloader(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public void Download(Uri url, string destination, DownloadProgressChangedEventHandler downloadProgress, AsyncCompletedEventHandler downloadCompleted)
        {
            try
            {
                if (Utils.IsInternetAvailable)
                {
                    Dispatcher.CurrentDispatcher.InvokeAsync(() =>
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadProgressChanged += downloadProgress;
                        webClient.DownloadFileCompleted += downloadCompleted;
                        webClient.DownloadFileAsync(url, destination);
                    });
                }
                else
                {
                    errorHandler.ShowWarning(Constants.INTERNET_IS_DISABLED_MESSAGE);
                    Utils.CloseApp();
                }
            }
            catch(Exception exc)
            {
                errorHandler.ShowError(exc.Message);
            }
        }

        public static Downloader Instance
        {
            get
            {
                return downloader == null ? new Downloader(new ErrorHandler()) : downloader;
            }
        }
    }
}
