using System;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.FileServices.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnRetrieveListOfFilesIfPathIsInvalid(string invalidPath)
        {
            // given
            string randomSearchPattern = GetRandomString();
            string inputSearchPattern = randomSearchPattern;

            var invalidFilePathException =
                new InvalidFilePathException();

            var expectedFileServiceValidationException =
                new FileServiceValidationException(invalidFilePathException);

            // when
            Action retrieveListOfFiles = () =>
                this.fileService.RetrieveListOfFiles(invalidPath, inputSearchPattern);

            FileServiceValidationException actualFileServiceValidationException =
                Assert.Throws<FileServiceValidationException>(retrieveListOfFiles);

            // then
            actualFileServiceValidationException.Should().BeEquivalentTo(expectedFileServiceValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.GetListOfFiles(invalidPath, inputSearchPattern),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
