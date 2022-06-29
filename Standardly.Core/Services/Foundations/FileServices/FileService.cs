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
            this.fileSystemBroker.ReadFile(path);
    }
}
