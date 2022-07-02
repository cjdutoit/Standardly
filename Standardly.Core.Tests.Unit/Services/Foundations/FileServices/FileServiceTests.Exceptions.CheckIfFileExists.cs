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
        public void ShouldThrowDependencyValidationExceptionOnCheckIfFileExistsIfDependencyValidationErrorOccursAndLogIt(
            Exception dependencyValidationException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyValidationException);

            var expectedFileServiceDependencyValidationException =
                new FileServiceDependencyValidationException(invalidFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(somePath))
                    .Throws(dependencyValidationException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CheckIfFileExists(somePath);

            FileServiceDependencyValidationException actualException =
                Assert.Throws<FileServiceDependencyValidationException>(writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceDependencyValidationException);

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

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyException);

            var failedFileServiceDependencyException =
                new FailedFileServiceDependencyException(
                    invalidFileServiceDependencyException);

            var expectedFileServiceDependencyException =
                new FileServiceDependencyException(failedFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CheckIfFileExists(somePath);

            FileServiceDependencyException actualException = Assert.Throws<FileServiceDependencyException>(
                writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CheckIfFileExists(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(CriticalFileServiceDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnCheckIfFileExistsIfDependencyErrorOccursAndLogItCritical(
            Exception dependencyException)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileServiceDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyException);

            var failedFileServiceDependencyException =
                new FailedFileServiceDependencyException(
                    invalidFileServiceDependencyException);

            var expectedFileServiceDependencyException =
                new FileServiceDependencyException(failedFileServiceDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(somePath))
                    .Throws(dependencyException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CheckIfFileExists(somePath);

            FileServiceDependencyException actualException = Assert.Throws<FileServiceDependencyException>(
                writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceDependencyException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CheckIfFileExists(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShoudThrowServiceExceptionOnCheckIfFileExistsIfServiceErrorOccurs()
        {
            // given
            string somePath = GetRandomString();
            var serviceException = new Exception();

            var failedFileServiceException =
                new FailedFileServiceException(serviceException);

            var expectedFileServiceException =
                new FileServiceException(failedFileServiceException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(somePath))
                    .Throws(serviceException);

            // when
            Action writeToFileAction = () =>
                this.fileService.CheckIfFileExists(somePath);

            FileServiceException actualException = Assert.Throws<FileServiceException>(writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CheckIfFileExists(somePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
