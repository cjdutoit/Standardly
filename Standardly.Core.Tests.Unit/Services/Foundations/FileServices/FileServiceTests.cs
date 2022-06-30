using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Moq;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Services.Foundations.FileServices;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        private readonly Mock<IFileSystemBroker> fileSystemBrokerMock;
        private readonly IFileService fileService;

        public FileServiceTests()
        {
            fileSystemBrokerMock = new Mock<IFileSystemBroker>();
            this.fileService = new FileService(fileSystemBroker: this.fileSystemBrokerMock.Object);
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

        public static TheoryData CriticalFileServiceDependencyExceptions()
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
