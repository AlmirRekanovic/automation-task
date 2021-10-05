using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Helpers
{
    public class FileHandler
    {
        private readonly string _fileName;
        public FileHandler(string fileName)
        {
            _fileName = fileName;
        }
        public string ReadFile()
        {
            var parameterFilePath = System.IO.Path.Combine(DirectoryHandler.AssemblyDirectory, _fileName);
            return File.ReadAllText(parameterFilePath);
        }

        public List<string> ReadFileAsList()
        {
            var parameterFilePath = System.IO.Path.Combine(DirectoryHandler.AssemblyDirectory, _fileName);
            return File.ReadAllLines(parameterFilePath).ToList();
        }

        public string CreateFile(string stringToWrite)
        {
            var filePath = Path.Combine(DirectoryHandler.AssemblyDirectory, _fileName);
            File.WriteAllText(filePath, stringToWrite);
            return filePath;
        }

        public string CreateFile(List<string> stringToWrite)
        {
            var filePath = Path.Combine(DirectoryHandler.AssemblyDirectory, _fileName);
            File.WriteAllLines(filePath, stringToWrite);
            return filePath;
        }


        public string[] GetFiles()
        {
            return Directory.GetFiles(DirectoryHandler.AssemblyDirectory, _fileName);
        }

        public string CopyFile(string sourceFile, string destinationFolder, string destinationFileName = null, bool shouldCreateDestinationFolder = false, bool shouldOverwriteFile = false)
        {
            var destinationFileAbsolutePath = string.Empty;
            var doesDestinationFolderExist = Directory.Exists(destinationFolder);
            sourceFile = Path.GetFullPath(sourceFile);
            destinationFolder = Path.GetFullPath(destinationFolder);

            if (string.IsNullOrEmpty(destinationFileName))
            {
                destinationFileName = Path.GetFileName(sourceFile);
            }

            if (shouldCreateDestinationFolder && !doesDestinationFolderExist)
            {
                Directory.CreateDirectory(destinationFolder);
            }

            destinationFileAbsolutePath = Path.Combine(destinationFolder, destinationFileName);

            File.Copy(sourceFile, destinationFileAbsolutePath, shouldOverwriteFile);

            return destinationFileAbsolutePath;
        }

        public List<string> SearchFilesByName(string folderAbsolutePath, string fileNameSearchCriteria, int searchTimeSpanSeconds = 0)
        {
            var localDateTime = DateTime.Now;
            var timeSpan = TimeSpan.FromSeconds(searchTimeSpanSeconds);
            var interval = localDateTime.Subtract(timeSpan);
            var listOfFoundedFiles = new List<string>();
            var dirInfo = new DirectoryInfo(folderAbsolutePath);
            folderAbsolutePath = Path.GetFullPath(folderAbsolutePath);

            try
            {
                var files = dirInfo.GetFiles(fileNameSearchCriteria, SearchOption.TopDirectoryOnly);

                if (searchTimeSpanSeconds != 0)
                {
                    files = files.Where(s => s.CreationTime >= interval).ToArray();
                }

                files.OrderBy(p => p.CreationTime);
                return files.Select(f => f.FullName).ToList();
            }
            catch
            {
                throw new FileNotFoundException($"File {fileNameSearchCriteria} is not found");
            }
        }

        public bool VerifyFileData(List<string> expectedData) 
        {
           List<string> fileProductNames = ReadFileAsList();

           return expectedData.SequenceEqual(fileProductNames);
        }
    }
}
