using System.IO;

namespace Installer
{
    public static class Utils
    {
        public static void RemoveJunkFiles()
        {
            File.Delete(Constants.VERSION_FILE);
            File.Delete(Constants.MASTER_FILE);
        }

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsInternetAvailable
        {
            get
            {
                int desc;
                return InternetGetConnectedState(out desc, 0);
            }
        }
    }
}
