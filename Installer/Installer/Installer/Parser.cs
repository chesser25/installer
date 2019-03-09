using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Installer
{
    static class Parser
    {
        public static double ParseVersionFile(string file)
        {
            double version;
            string fileContent = File.ReadAllText(file);
            double.TryParse(fileContent, NumberStyles.Number, CultureInfo.InvariantCulture, out version);
            return version;
        }

        public static void ParseMasterFile(string file, out List<string> expertsUrls, out List<string> filesUrls)
        {
            expertsUrls = new List<string>();
            filesUrls = new List<string>();
            string fileContent = File.ReadAllText(file);
            Regex regx = new Regex(Constants.URL_PATTERN, RegexOptions.IgnoreCase);
            MatchCollection mactches = regx.Matches(fileContent);
            foreach (Match match in mactches)
            {
                if(Path.GetExtension(match.Value).Equals(Constants.EXPERTS_FILE_EXTENSION))
                {
                    expertsUrls.Add(match.Value);
                }
                else
                {
                    filesUrls.Add(match.Value);
                }
            }
        }
    }
}
