// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

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
        public void ShouldThrowDependencyValidationExceptionOnDeleteDirectoryIfDependencyValidationErrorOccursAndLogIt(
            Exception dependencyValidationException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(dependencyValidationException);

            var expectedFileServiceDependencyValidationException =
                new FileServiceDependencyValidationException(invalidFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.DeleteDirectory(somePath, false))
                    .Throws(dependencyValidationException);

            // when
            Action writeToFileAction = () =>
                this.fileService.DeleteDirectory(somePath);

            FileServiceDependencyValidationException actualFileServiceDependencyValidationException =
                Assert.Throws<FileServiceDependencyValidationException>(writeToFileAction);

            // then
            actualFileServiceDependencyValidationException
                .Should().BeEquivalentTo(expectedFileServiceDependencyValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteDirectory(somePath, false),
                    Times.Exactly(this.retryConfig.MaxRetryAttempts));

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(FileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnDeleteDirectoryIfDependencyErrorOccursAndLogIt(
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
                broker.DeleteDirectory(somePath, false))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.DeleteDirectory(somePath);

            FileServiceDependencyException actualFileServiceDependencyException =
                Assert.Throws<FileServiceDependencyException>(writeToFileAction);

            // then
            actualFileServiceDependencyException.Should().BeEquivalentTo(expectedFileServiceDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteDirectory(somePath, false),
                    Times.Exactly(this.retryConfig.MaxRetryAttempts));

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(CriticalFileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnDeleteDirectoryIfDependencyErrorOccursAndLogItCritical(
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
                broker.DeleteDirectory(somePath, false))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.DeleteDirectory(somePath);

            FileServiceDependencyException actualFileServiceDependencyException =
                Assert.Throws<FileServiceDependencyException>(writeToFileAction);

            // then
            actualFileServiceDependencyException.Should().BeEquivalentTo(expectedFileServiceDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteDirectory(somePath, false),
                    Times.Exactly(this.retryConfig.MaxRetryAttempts));

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShoudThrowServiceExceptionOnDeleteDirectoryIfServiceErrorOccurs()
        {
            // given
            string somePath = GetRandomString();
            var serviceException = new Exception();

            var failedFileServiceException =
                new FailedFileServiceException(serviceException);

            var expectedFileServiceException =
                new FileServiceException(failedFileServiceException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.DeleteDirectory(somePath, false))
                    .Throws(serviceException);

            // when
            Action writeToFileAction = () =>
                this.fileService.DeleteDirectory(somePath);

            FileServiceException actualException = Assert.Throws<FileServiceException>(writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteDirectory(somePath, false),
                    Times.Exactly(this.retryConfig.MaxRetryAttempts));

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
