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
        public void ShouldThrowDependencyValidationExceptionOnReadFromFileIfDependencyValidationErrorOccursAndLogIt(
            Exception dependencyValidationException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(dependencyValidationException);

            var expectedFileServiceDependencyValidationException =
                new FileServiceDependencyValidationException(invalidFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.ReadFile(somePath))
                    .Throws(dependencyValidationException);

            // when
            Action writeToFileAction = () =>
                this.fileService.ReadFromFile(somePath);

            FileServiceDependencyValidationException actualFileServiceDependencyValidationException =
                Assert.Throws<FileServiceDependencyValidationException>(writeToFileAction);

            // then
            actualFileServiceDependencyValidationException.Should()
                .BeEquivalentTo(expectedFileServiceDependencyValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.ReadFile(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(FileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnReadFromFileIfDependencyErrorOccursAndLogIt(
            Exception dependencyException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyException);

            var failedFileServiceDependencyException =
                new FailedFileServiceDependencyException(invalidFileServiceDependencyException);

            var expectedFileServiceDependencyException =
                new FileServiceDependencyException(failedFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.ReadFile(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.ReadFromFile(somePath);

            FileServiceDependencyException actualFileServiceDependencyException =
                Assert.Throws<FileServiceDependencyException>(writeToFileAction);

            // then
            actualFileServiceDependencyException.Should().BeEquivalentTo(expectedFileServiceDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.ReadFile(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(CriticalFileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnReadFromFileIfDependencyErrorOccursAndLogItCritical(
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
                broker.ReadFile(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.ReadFromFile(somePath);

            FileServiceDependencyException actualFileServiceDependencyException =
                Assert.Throws<FileServiceDependencyException>(writeToFileAction);

            // then
            actualFileServiceDependencyException.Should().BeEquivalentTo(expectedFileServiceDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.ReadFile(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShoudThrowServiceExceptionOnReadFromFileIfServiceErrorOccurs()
        {
            // given
            string somePath = GetRandomString();
            var serviceException = new Exception();

            var failedFileServiceException =
                new FailedFileServiceException(serviceException);

            var expectedFileServiceException =
                new FileServiceException(failedFileServiceException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.ReadFile(somePath))
                    .Throws(serviceException);

            // when
            Action writeToFileAction = () =>
                this.fileService.ReadFromFile(somePath);

            FileServiceException actualFileServiceException = Assert.Throws<FileServiceException>(writeToFileAction);

            // then
            actualFileServiceException.Should().BeEquivalentTo(expectedFileServiceException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.ReadFile(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
