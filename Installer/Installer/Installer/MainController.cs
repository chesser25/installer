using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Linq;

namespace Installer
{
    class MainController
    {
        public DownloadProgressChangedEventHandler downloadProgress;
        public AsyncCompletedEventHandler downloadAllFilesCompleted;
        public void Start()
        {
            DownloadVersionFile();
        }

        private void DownloadVersionFile()
        {
            Downloader.Instance.Download(new Uri(Constants.VERSION_FILE_URL), Constants.VERSION_FILE, downloadProgress, DownloadVersionFileCompleted);
        }

        private void DownloadVersionFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (VersionChecker.Instance.IsNewVersionAvailable)
            {
                DownloadMasterFile();
            }
        }

        private void DownloadMasterFile()
        {
            Downloader.Instance.Download(new Uri(Constants.MASTER_FILE_URL), Constants.MASTER_FILE, downloadProgress, DownloadMasterFileCompleted);
        }

        private void DownloadMasterFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            List<string> expertsUrls;
            List<string> filesUrls;
            Parser.ParseMasterFile(Constants.MASTER_FILE, out expertsUrls, out filesUrls);
            DownloadExpertsFiles(expertsUrls);
            DownloadFiles(filesUrls);
            VersionChecker.Instance.SaveNewVersion();
            Utils.RemoveJunkFiles();
        }

        private void DownloadExpertsFiles(List<string> expertsUrls)
        {
            Directory.CreateDirectory(Constants.EXPERTS_DESTINATION_DIRECTORY);
            expertsUrls.ForEach(expertsUrl =>
            {
                Downloader.Instance.Download(new Uri(expertsUrl), Path.Combine(Constants.EXPERTS_DESTINATION_DIRECTORY, Path.GetFileName(expertsUrl)), downloadProgress, null);
            });
        }

        private void DownloadFiles(List<string> fileUrls)
        {
            Directory.CreateDirectory(Constants.FILES_DESTINATION_DIRECTORY);
            for (int index = 0; index < fileUrls.Count; index++)
            {
                Downloader.Instance.Download(new Uri(fileUrls[index]), Path.Combine(Constants.FILES_DESTINATION_DIRECTORY, string.Format("{0}.zip", index.ToString())), downloadProgress, fileUrls[index] == fileUrls.Last() ? downloadAllFilesCompleted : null);
            }
        }
    }
}
