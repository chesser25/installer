using Microsoft.Win32;

namespace Installer
{
    class VersionChecker
    {
        private double newVersion;
        private static VersionChecker versionChecker;

        public static VersionChecker Instance
        {
            get
            {
                return new VersionChecker();
            }
        }

        private double GetNewVersion()
        {
            newVersion = Parser.ParseVersionFile(Constants.VERSION_FILE);
            return newVersion;
        }

        private double GetOldVersion()
        {
            double oldVersion;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(Constants.REGISTRY_PATH);
            double.TryParse(key?.GetValue(Constants.VERSION_KEY).ToString(), out oldVersion);
            return oldVersion;
        }

        public bool IsNewVersionAvailable
        {
            get
            {
                return GetNewVersion() > GetOldVersion();
            }
        }

        public void SaveNewVersion()
        {
            using (RegistryKey key = Registry.LocalMachine
               .OpenSubKey(Constants.REGISTRY_PATH))
            {
                key?.SetValue(Constants.VERSION_KEY, newVersion);
            }
        }
    }
}
