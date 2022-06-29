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
        [MemberData(nameof(FileDependencyValidationExceptions))]
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
    }
}
