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
        [MemberData(nameof(FileServiceDependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionOnCheckIfFileExistsIfDependencyValidationErrorOccursAndLogIt(
        Exception dependencyValidationException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyValidationException);

            var expectedDependencyValidationException =
                new FileServiceDependencyValidationException(invalidFileDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(somePath))
                    .Throws(dependencyValidationException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CheckIfFileExists(somePath);

            FileServiceDependencyValidationException actualException =
                Assert.Throws<FileServiceDependencyValidationException>(writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedDependencyValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CheckIfFileExists(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(FileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnCheckIfFileExistsIfDependencyErrorOccursAndLogIt(
            Exception dependencyException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyException);

            var failedFileDependencyException =
                new FailedFileServiceDependencyException(
                    invalidFileDependencyException);

            var expectedFileDependencyException =
                new FileServiceDependencyException(failedFileDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CheckIfFileExists(somePath);

            FileServiceDependencyException actualException = Assert.Throws<FileServiceDependencyException>(
                writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CheckIfFileExists(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
