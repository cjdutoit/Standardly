// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using Moq;
using Standardly.Core.Models.Processings.Files.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Files
{
    public partial class FileProcessingServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnWriteToFileIfInputsIsInvalidAndLogItAsync(
            string invalidInput)
        {
            // given
            string invalidPath = invalidInput;
            string invalidContent = invalidInput;

            var invalidFilesProcessingException =
                new InvalidFileProcessingException();

            invalidFilesProcessingException.AddData(
                key: "path",
                values: "Text is required");

            invalidFilesProcessingException.AddData(
                key: "content",
                values: "Text is required");

            var expectedFilesProcessingValidationException =
                new FileProcessingValidationException(invalidFilesProcessingException);

            // when
            System.Action runAction = () =>
                this.fileProcessingService.WriteToFile(path: invalidPath, content: invalidContent);

            FileProcessingValidationException actualException =
                Assert.Throws<FileProcessingValidationException>(runAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFilesProcessingValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFilesProcessingValidationException))),
                        Times.Once);

            this.fileServiceMock.Verify(broker =>
                broker.WriteToFile(invalidPath, invalidContent),
                    Times.Never);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
