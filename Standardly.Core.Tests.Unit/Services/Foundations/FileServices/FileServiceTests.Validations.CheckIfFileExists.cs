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
        public void ShouldThrowValidationExceptionOnCheckIfFileExistsIfPathIsInvalid(
            string invalidPath)
        {
            // given
            var invalidFilePathException =
                new InvalidFilePathException();

            var expectedFileValidationException =
                new FileValidationException(
                    invalidFilePathException);

            // when
            Action checkIfDirectoryExistsAction = () =>
                this.fileService.CheckIfFileExists(invalidPath);

            FileValidationException actualException = Assert.Throws<FileValidationException>(
                checkIfDirectoryExistsAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CheckIfFileExists(
                    It.IsAny<string>()),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
