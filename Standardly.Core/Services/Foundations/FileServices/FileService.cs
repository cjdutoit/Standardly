// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Helpers.Retries;
using Standardly.Core.Models.RetryConfig;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public partial class FileService : IFileService
    {
        private readonly IFileSystemBroker fileSystemBroker;
        private readonly IRetryConfig retryConfig;

        public FileService(IFileSystemBroker fileSystemBroker, IRetryConfig retryConfig)
        {
            this.fileSystemBroker = fileSystemBroker;
            this.retryConfig = retryConfig;
        }

        public bool CheckIfFileExists(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                return Retry.RetryOnException(
                    this.retryConfig.MaxRetryAttempts,
                    this.retryConfig.PauseBetweenFailures,
                    () =>
                    {
                        return this.fileSystemBroker.CheckIfFileExists(path);
                    });
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

                Retry.RetryOnException(
                    this.retryConfig.MaxRetryAttempts,
                    this.retryConfig.PauseBetweenFailures,
                    () =>
                    {
                        this.fileSystemBroker.WriteToFile(path, content);
                    });
            });

        public string ReadFromFile(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                return Retry.RetryOnException(
                    this.retryConfig.MaxRetryAttempts,
                    this.retryConfig.PauseBetweenFailures,
                    () =>
                    {
                        return this.fileSystemBroker.ReadFile(path);
                    });
            });

        public void DeleteFile(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                Retry.RetryOnException(
                    this.retryConfig.MaxRetryAttempts,
                    this.retryConfig.PauseBetweenFailures,
                    () =>
                    {
                        this.fileSystemBroker.DeleteFile(path);
                    });
            });

        public string[] RetrieveListOfFiles(string path, string searchPattern = "*") =>
            TryCatch(() =>
            {
                ValidateSearchInputs(path, searchPattern);

                return Retry.RetryOnException(
                    this.retryConfig.MaxRetryAttempts,
                    this.retryConfig.PauseBetweenFailures,
                    () =>
                    {
                        return this.fileSystemBroker.GetListOfFiles(path, searchPattern);
                    });
            });

        public bool CheckIfDirectoryExists(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                return Retry.RetryOnException(
                    this.retryConfig.MaxRetryAttempts,
                    this.retryConfig.PauseBetweenFailures,
                    () =>
                    {
                        return this.fileSystemBroker.CheckIfDirectoryExists(path);
                    });
            });

        public void CreateDirectory(string path) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                Retry.RetryOnException(
                   this.retryConfig.MaxRetryAttempts,
                    this.retryConfig.PauseBetweenFailures,
                    () =>
                    {
                        this.fileSystemBroker.CreateDirectory(path);
                    });
            });

        public void DeleteDirectory(string path, bool recursive = false) =>
            TryCatch(() =>
            {
                ValidatePath(path);

                Retry.RetryOnException(
                    this.retryConfig.MaxRetryAttempts,
                    this.retryConfig.PauseBetweenFailures,
                    () =>
                    {
                        this.fileSystemBroker.DeleteDirectory(path, recursive);
                    });
            });
    }
}
