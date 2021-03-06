﻿using System.ComponentModel;
using System.Net;
using System.Windows;


namespace Installer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Install_Click(object sender, RoutedEventArgs e)
        {
            MainController controller = new MainController(new ErrorHandler());
            controller.showInstallPage = ShowInstallWindow;
            controller.downloadProgress = Download_Progress;
            controller.downloadAllFilesCompleted = ShowFinishWindow;
            controller.Start();
        }

        private void Cancel_Install(object sender, RoutedEventArgs e)
        {
            InstallPage.Visibility = Visibility.Hidden;
            WelcomePage.Visibility = Visibility.Visible;
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            Utils.CloseApp();
        }

        private void Download_Progress(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress.Value = e.ProgressPercentage;
            ProgressText.Text = string.Format("{0}%", e.ProgressPercentage);
        }

        private void ShowFinishWindow(object sender, AsyncCompletedEventArgs e)
        {
            InstallPage.Visibility = Visibility.Hidden;
            FinishPage.Visibility = Visibility.Visible;
        }

        private void ShowInstallWindow()
        {
            WelcomePage.Visibility = Visibility.Hidden;
            InstallPage.Visibility = Visibility.Visible;
        }
    }
}
