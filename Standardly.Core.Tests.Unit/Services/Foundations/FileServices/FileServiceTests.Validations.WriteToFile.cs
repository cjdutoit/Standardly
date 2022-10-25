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
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnWriteToFileIfPathIsInvalid(
            string invalidPath)
        {
            // given
            string someContent = GetRandomString();

            var invalidFilePathException =
                new InvalidFilePathException(invalidPath);

            var expectedFileServiceValidationException =
                new FileValidationException(invalidFilePathException);

            // when
            Action checkIfDirectoryExistsAction = () =>
                this.fileService.WriteToFile(invalidPath, someContent);

            FileValidationException actualException = Assert.Throws<FileValidationException>(
                checkIfDirectoryExistsAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.WriteToFile(invalidPath, someContent),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnWriteToFileIfContentIsInvalid(string invalidContent)
        {
            // given
            string somePath = GetRandomString();

            var invalidFileContentException =
                new InvalidFileContentException();

            var expectedFileServiceValidationException =
                new FileValidationException(invalidFileContentException);

            // when
            Action checkIfDirectoryExistsAction = () =>
                this.fileService.WriteToFile(somePath, invalidContent);

            FileValidationException actualException = Assert.Throws<FileValidationException>(
                checkIfDirectoryExistsAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileServiceValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.WriteToFile(somePath, invalidContent),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
