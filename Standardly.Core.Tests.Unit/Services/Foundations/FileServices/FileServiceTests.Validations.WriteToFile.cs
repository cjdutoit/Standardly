using System;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.FileServices.Exceptions;
using Standardly.Core.Services.Foundations.FileServices;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnWriteToFileIfPathIsInvalid(
            string invalidPath)
        {
            // given
            string someContent = GetRandomString();

            var invalidFilePathException =
                new InvalidFilePathException();

            var expectedFileServiceValidationException =
                new FileServiceValidationException(invalidFilePathException);

            // when
            Action checkIfDirectoryExistsAction = () =>
                this.fileService.WriteToFile(invalidPath, someContent);

            FileServiceValidationException actualException = Assert.Throws<FileServiceValidationException>(
                checkIfDirectoryExistsAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.WriteToFile(invalidPath, someContent),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
