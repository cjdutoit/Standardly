// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Moq;
using Standardly.Core.Models.Processings.Files.Exceptions;
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Files
{
    public partial class FileProcessingServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationOnDeleteDirectoryIfDependencyValidationErrorOccursAndLogItAsync(
            Xeption dependencyValidationException)
        {
            // given
            string randomPath = GetRandomString();
            string inputPath = randomPath;
            bool recursive = true;

            var expectedFileProcessingDependencyValidationException =
                new FileProcessingDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.fileServiceMock.Setup(service =>
                service.DeleteDirectory(inputPath, recursive))
                    .Throws(dependencyValidationException);

            // when
            System.Action runAction = () =>
                this.fileProcessingService.DeleteDirectory(inputPath, recursive);

            // then
            FileProcessingDependencyValidationException actualException =
                Assert.Throws<FileProcessingDependencyValidationException>(runAction);

            this.fileServiceMock.Verify(service =>
                service.DeleteDirectory(inputPath, recursive),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFileProcessingDependencyValidationException))),
                        Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyOnDeleteDirectoryIfDependencyErrorOccursAndLogItAsync(
            Xeption dependencyException)
        {
            // given
            string randomPath = GetRandomString();
            string inputPath = randomPath;
            bool recursive = true;

            var expectedFileProcessingDependencyException =
                new FileProcessingDependencyException(
                    dependencyException.InnerException as Xeption);

            this.fileServiceMock.Setup(service =>
                service.DeleteDirectory(inputPath, recursive))
                    .Throws(dependencyException);

            // when
            System.Action runAction = () =>
                this.fileProcessingService.DeleteDirectory(inputPath, recursive);

            // then
            FileProcessingDependencyException actualException =
                Assert.Throws<FileProcessingDependencyException>(runAction);

            this.fileServiceMock.Verify(service =>
                service.DeleteDirectory(inputPath, recursive),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFileProcessingDependencyException))),
                        Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnDeleteDirectoryIfServiceErrorOccursAndLogItAsync()
        {
            // given
            string randomPath = GetRandomString();
            string inputPath = randomPath;
            bool recursive = true;

            var serviceException = new Exception();

            var failedFileProcessingServiceException =
                new FailedFileProcessingServiceException(serviceException);

            var expectedFileProcessingServiveException =
                new FileProcessingServiceException(
                    failedFileProcessingServiceException);

            this.fileServiceMock.Setup(service =>
                service.DeleteDirectory(inputPath, recursive))
                    .Throws(serviceException);

            // when
            System.Action runAction = () =>
                this.fileProcessingService.DeleteDirectory(inputPath, recursive);

            // then
            FileProcessingServiceException actualException =
                Assert.Throws<FileProcessingServiceException>(runAction);

            this.fileServiceMock.Verify(service =>
                service.DeleteDirectory(inputPath, recursive),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFileProcessingServiveException))),
                        Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
