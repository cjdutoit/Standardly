// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Brokers.Loggings;
using Standardly.Core.Services.Processings.Files;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public partial class FileProcessingService : IFileProcessingService
    {
        private readonly IFileService fileService;
        private readonly ILoggingBroker loggingBroker;

        public FileProcessingService(IFileService fileService, ILoggingBroker loggingBroker)
        {
            this.fileService = fileService;
            this.loggingBroker = loggingBroker;
        }
        public bool CheckIfFileExists(string path) =>
            TryCatch(() =>
            {
                ValidateCheckIfFileExists(path);

                return this.fileService.CheckIfFileExists(path);
            });

        public void WriteToFile(string path, string content) =>
            TryCatch(() =>
            {
                ValidateWriteToFile(path, content);
                this.fileService.WriteToFile(path, content);
            });

        public string ReadFromFile(string path) =>
            TryCatch(() =>
            {
                ValidateReadFromFile(path);

                return this.fileService.ReadFromFile(path);
            });

        public void DeleteFile(string path) =>
            TryCatch(() =>
            {
                ValidateDeleteFile(path);
                this.fileService.DeleteFile(path);
            });

        public string[] RetrieveListOfFiles(string path, string searchPattern = "*") =>
            TryCatch(() =>
            {
                ValidateRetrieveListOfFiles(path, searchPattern);

                return this.fileService.RetrieveListOfFiles(path, searchPattern);
            });

        public bool CheckIfDirectoryExists(string path) =>
            TryCatch(() =>
            {
                ValidateCheckIfDirectoryExists(path);

                return this.fileService.CheckIfDirectoryExists(path);
            });

        public void CreateDirectory(string path) =>
            this.fileService.CreateDirectory(path);

        public void DeleteDirectory(string path, bool recursive = false) =>
            throw new System.NotImplementedException();
    }
}
