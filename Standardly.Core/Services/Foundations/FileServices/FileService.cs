using System.IO;
using Standardly.Core.Brokers.FileSystems;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public partial class FileService : IFileService
    {
        private readonly IFileSystemBroker fileSystemBroker;

        public FileService(IFileSystemBroker fileSystemBroker)
        {
            this.fileSystemBroker = fileSystemBroker;
        }

        public bool CheckIfFileExists(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                return this.fileSystemBroker.CheckIfFileExists(path);
            });

        public void WriteToFile(string path, string content) =>
            TryCatch(() =>
            {
                ValidateInputs(path, content);

                var fileInfo = new FileInfo(path);
                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                this.fileSystemBroker.WriteToFile(path, content);
            });

        public string ReadFromFile(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                return this.fileSystemBroker.ReadFile(path);
            });

        public string[] RetrieveListOfFiles(string path, string searchPattern = "*") =>
            TryCatch(() =>
            {
                ValidateSearchInputs(path, searchPattern);

                return this.fileSystemBroker.GetListOfFiles(path, searchPattern);
            });

        public bool CheckIfDirectoryExists(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                return this.fileSystemBroker.CheckIfDirectoryExists(path);
            });

        public void CreateDirectory(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);
                this.fileSystemBroker.CreateDirectory(path);
            });
    }
}
