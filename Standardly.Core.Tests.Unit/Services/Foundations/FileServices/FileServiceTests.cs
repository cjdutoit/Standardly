// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Moq;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Models.Configurations.RetryConfig;
using Standardly.Core.Services.Foundations.Files;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        private readonly Mock<IFileSystemBroker> fileSystemBrokerMock;
        private readonly IRetryConfig retryConfig;
        private readonly IFileService fileService;

        public FileServiceTests()
        {
            int maxRetryAttempts = 3;
            TimeSpan pauseBetweenFailures = TimeSpan.FromMilliseconds(10);
            this.retryConfig = new RetryConfig(maxRetryAttempts, pauseBetweenFailures);
            fileSystemBrokerMock = new Mock<IFileSystemBroker>();

            this.fileService = new FileService(
                fileSystemBroker: this.fileSystemBrokerMock.Object,
                retryConfig: this.retryConfig);
        }

        public static TheoryData FileServiceDependencyValidationExceptions()
        {
            return new TheoryData<Exception>()
            {
                new ArgumentNullException(),
                new ArgumentOutOfRangeException(),
                new ArgumentException()
            };
        }

        public static TheoryData FileServiceDependencyExceptions()
        {
            return new TheoryData<Exception>()
            {
                new SerializationException(),
                new IOException(),
            };
        }

        public static TheoryData CriticalFileDependencyExceptions()
        {
            return new TheoryData<Exception>()
            {
                new OutOfMemoryException(),
                new UnauthorizedAccessException()
            };
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static string[] GetRandomStringArray()
        {
            return Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(item =>
                {
                    return GetRandomString();
                }).ToArray();
        }
    }
}
