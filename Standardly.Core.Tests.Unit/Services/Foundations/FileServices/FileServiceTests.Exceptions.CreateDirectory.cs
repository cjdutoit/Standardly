// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Foundations.Files.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Theory]
        [MemberData(nameof(FileServiceDependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionOnCreateDirectoryIfDependencyValidationErrorOccursAndLogIt(
            Exception dependencyValidationException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(dependencyValidationException);

            var expectedFileDependencyValidationException =
                new FileDependencyValidationException(invalidFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CreateDirectory(somePath))
                    .Throws(dependencyValidationException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CreateDirectory(somePath);

            FileDependencyValidationException actualFileDependencyValidationException =
                Assert.Throws<FileDependencyValidationException>(writeToFileAction);

            // then
            actualFileDependencyValidationException
                .Should().BeEquivalentTo(expectedFileDependencyValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CreateDirectory(somePath),
                    Times.Exactly(this.retryConfig.MaxRetryAttempts));

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(FileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnCreateDirectoryIfDependencyErrorOccursAndLogIt(
            Exception dependencyException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyException);

            var failedFileDependencyException =
                new FailedFileDependencyException(invalidFileServiceDependencyException);

            var expectedFileDependencyException =
                new FileDependencyException(failedFileDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CreateDirectory(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CreateDirectory(somePath);

            FileDependencyException actualFileDependencyException =
                Assert.Throws<FileDependencyException>(writeToFileAction);

            // then
            actualFileDependencyException.Should().BeEquivalentTo(expectedFileDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CreateDirectory(somePath),
                    Times.Exactly(this.retryConfig.MaxRetryAttempts));

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(CriticalFileDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnCreateDirectoryIfDependencyErrorOccursAndLogItCritical(
            Exception dependencyException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyException);

            var failedFileDependencyException =
                new FailedFileDependencyException(invalidFileServiceDependencyException);

            var expectedFileDependencyException =
                new FileDependencyException(failedFileDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CreateDirectory(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CreateDirectory(somePath);

            FileDependencyException actualFileDependencyException =
                Assert.Throws<FileDependencyException>(writeToFileAction);

            // then
            actualFileDependencyException.Should().BeEquivalentTo(expectedFileDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CreateDirectory(somePath),
                    Times.Exactly(this.retryConfig.MaxRetryAttempts));

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShoudThrowServiceExceptionOnCreateDirectoryIfServiceErrorOccurs()
        {
            // given
            string somePath = GetRandomString();
            var serviceException = new Exception();

            var failedFileServiceException =
                new FailedFileServiceException(serviceException);

            var expectedFileServiceException =
                new FileServiceException(failedFileServiceException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CreateDirectory(somePath))
                    .Throws(serviceException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CreateDirectory(somePath);

            FileServiceException actualException = Assert.Throws<FileServiceException>(writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CreateDirectory(somePath),
                    Times.Exactly(this.retryConfig.MaxRetryAttempts));

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
