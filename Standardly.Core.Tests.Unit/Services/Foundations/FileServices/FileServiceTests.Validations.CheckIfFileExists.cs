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
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnCheckIfFileExistsIfPathIsInvalid(string invalidPath)
        {
            // given
            var invalidFilePathException =
                new InvalidFilePathException(invalidPath);

            var expectedFileValidationException =
                new FileValidationException(invalidFilePathException);

            // when
            Action checkIfFileExistsAction = () =>
                this.fileService.CheckIfFileExists(invalidPath);

            FileValidationException actualException =
                Assert.Throws<FileValidationException>(checkIfFileExistsAction);

            // then
            actualException.Should().BeEquivalentTo(expectedFileValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CheckIfFileExists(
                    It.IsAny<string>()),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
