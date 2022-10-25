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
        public void ShouldThrowValidationExceptionOnDeleteFileIfPathIsInvalid(string invalidPath)
        {
            // given
            var invalidFilePathException =
                new InvalidFilePathException(invalidPath);

            var expectedFileServiceValidationException =
                new FileValidationException(invalidFilePathException);

            // when
            Action checkIfFileExistsAction = () =>
                this.fileService.DeleteFile(invalidPath);

            FileValidationException actualFileServiceValidationException =
                Assert.Throws<FileValidationException>(checkIfFileExistsAction);

            // then
            actualFileServiceValidationException.Should().BeEquivalentTo(expectedFileServiceValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteFile(
                    It.IsAny<string>()),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
