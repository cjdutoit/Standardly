using System;
using Moq;
using Standardly.Core.Models.FileServices.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Theory]
        [MemberData(nameof(FileServiceDependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionOnWriteIfDependencyValidationErrorOccursAndLogIt(
            Exception dependencyValidationException)
        {
            // given
            string somePath = GetRandomString();
            string someContent = GetRandomString();

            var invalidFileDependencyException =
                new InvalidFileServiceDependencyException(
                    dependencyValidationException);

            var expectedDependencyValidationException =
                new FileServiceDependencyValidationException(
                    invalidFileDependencyException);

            this.fileSystemBrokerMock.Setup(broker =>
                broker.WriteToFile(somePath, someContent))
                    .Throws(dependencyValidationException);

            // when
            Action writeToFileAction = () =>
                this.fileService.WriteToFile(somePath, someContent);

            // then
            Assert.Throws<FileServiceDependencyValidationException>(
                writeToFileAction);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.WriteToFile(somePath, someContent),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
