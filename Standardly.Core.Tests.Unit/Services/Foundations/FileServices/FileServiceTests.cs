using System;
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

        public static TheoryData FileDependencyValidationExceptions()
        {
            return new TheoryData<Exception>()
            {
                new ArgumentNullException(),
                new ArgumentOutOfRangeException(),
                new ArgumentException()
            };
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
