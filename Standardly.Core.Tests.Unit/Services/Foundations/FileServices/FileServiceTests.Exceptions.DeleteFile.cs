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
        public void ShouldThrowDependencyValidationExceptionOnDeleteFileIfDependencyValidationErrorOccursAndLogIt(
            Exception dependencyValidationException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(dependencyValidationException);

            var expectedFileServiceDependencyValidationException =
                new FileServiceDependencyValidationException(invalidFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.DeleteFile(somePath))
                    .Throws(dependencyValidationException);

            // when
            Action writeToFileAction = () =>
                this.fileService.DeleteFile(somePath);

            FileServiceDependencyValidationException actualFileServiceDependencyValidationException =
                Assert.Throws<FileServiceDependencyValidationException>(writeToFileAction);

            // then
            actualFileServiceDependencyValidationException
                .Should().BeEquivalentTo(expectedFileServiceDependencyValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteFile(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(FileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnDeleteFileIfDependencyErrorOccursAndLogIt(
            Exception dependencyException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(dependencyException);

            var failedFileServiceDependencyException =
                new FailedFileServiceDependencyException(invalidFileServiceDependencyException);

            var expectedFileServiceDependencyException =
                new FileServiceDependencyException(failedFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.DeleteFile(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.DeleteFile(somePath);

            FileServiceDependencyException actualFileServiceDependencyException =
                Assert.Throws<FileServiceDependencyException>(writeToFileAction);

            // then
            actualFileServiceDependencyException.Should().BeEquivalentTo(expectedFileServiceDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteFile(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(CriticalFileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnDeleteFileIfDependencyErrorOccursAndLogItCritical(
            Exception dependencyException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(dependencyException);

            var failedFileServiceDependencyException =
                new FailedFileServiceDependencyException(invalidFileServiceDependencyException);

            var expectedFileServiceDependencyException =
                new FileServiceDependencyException(failedFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.DeleteFile(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.DeleteFile(somePath);

            FileServiceDependencyException actualFileServiceDependencyException =
                Assert.Throws<FileServiceDependencyException>(writeToFileAction);

            // then
            actualFileServiceDependencyException.Should().BeEquivalentTo(expectedFileServiceDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteFile(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShoudThrowServiceExceptionOnDeleteFileIfServiceErrorOccurs()
        {
            // given
            string somePath = GetRandomString();
            var serviceException = new Exception();

            var failedFileServiceException =
                new FailedFileServiceException(serviceException);

            var expectedFileServiceException =
                new FileServiceException(failedFileServiceException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.DeleteFile(somePath))
                    .Throws(serviceException);

            // when
            Action writeToFileAction = () =>
                this.fileService.DeleteFile(somePath);

            FileServiceException actualException = Assert.Throws<FileServiceException>(writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteFile(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
