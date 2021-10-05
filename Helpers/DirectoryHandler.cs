using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Helpers
{
    public static class DirectoryHandler
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string CreateDirectory(string directoryName)
        {
            string directory = string.Format("{0}\\{1}", AssemblyDirectory, directoryName);
            if (VerifyDirectoryExists(directory))
            {
                DeleteDirectory(directory);
            }
            DirectoryInfo parentDirectoryInfo = new DirectoryInfo(directory);
            parentDirectoryInfo.Create();
            parentDirectoryInfo.Attributes &= ~FileAttributes.ReadOnly;
            return directory;
        }

        public static void DeleteDirectory(string directoryName)
        {
            DirectoryInfo di = new DirectoryInfo(directoryName);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private static bool VerifyDirectoryExists(string directoryName)
        {
            DirectoryInfo parentDirectoryInfo = new DirectoryInfo(directoryName);
            return parentDirectoryInfo.Exists;
        }
    }
}
