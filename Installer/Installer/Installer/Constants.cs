namespace Installer
{
    public static class Constants
    {
        public const string VERSION_FILE_URL = "https://drive.google.com/uc?export=download&id=1yXE4mCz-5hJ10S-qgB8TQytcKiJNfhzt";
        public const string VERSION_FILE = @"C:\Windows\Temp\version.txt";
        public const string MASTER_FILE_URL = "https://drive.google.com/uc?export=download&id=1yVHP0qXLoqyRVjFv83KgPB2iZtQUcByF";
        public const string MASTER_FILE = @"C:\Windows\Temp\master.txt";
        public const string REGISTRY_PATH = @"SOFTWARE\Microsoft\WindowsNT\CurrentVersion";
        public const string VERSION_KEY = "installerVersion";
        public const string EXPERTS_DESTINATION_DIRECTORY = "C:/tmp/Experts/";
        public const string FILES_DESTINATION_DIRECTORY = "C:/tmp/Files/";
        public const string ERROR_CAPTION = "Error";
        public const string WARNING_CAPTION = "Error";
        public const string URL_PATTERN = "https://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?";
        public const string EXPERTS_FILE_EXTENSION = ".ex4";
        public const string INTERNET_IS_DISABLED_MESSAGE = "There is no internet on your PC. Please check it and try again.";

    }
}
