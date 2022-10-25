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
        public void ShouldThrowValidationExceptionOnRetrieveListOfFilesIfPathIsInvalid(string invalidPath)
        {
            // given
            string randomSearchPattern = GetRandomString();
            string inputSearchPattern = randomSearchPattern;

            var invalidFilePathException =
                new InvalidFilePathException(invalidPath);

            var expectedFileServiceValidationException =
                new FileValidationException(invalidFilePathException);

            // when
            Action retrieveListOfFiles = () =>
                this.fileService.RetrieveListOfFiles(invalidPath, inputSearchPattern);

            FileValidationException actualFileServiceValidationException =
                Assert.Throws<FileValidationException>(retrieveListOfFiles);

            // then
            actualFileServiceValidationException.Should().BeEquivalentTo(expectedFileServiceValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.GetListOfFiles(invalidPath, inputSearchPattern),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnRetrieveListOfFilesIfSearchPatternIsInvalid(
            string invalidSearchPattern)
        {
            // given
            string randomPath = GetRandomString();
            string inputPath = randomPath;

            var invalidFileSearchPatternException =
                new InvalidFileSearchPatternException();

            var expectedFileServiceValidationException =
                new FileValidationException(invalidFileSearchPatternException);

            // when
            Action retrieveListOfFiles = () =>
                this.fileService.RetrieveListOfFiles(inputPath, invalidSearchPattern);

            // then
            FileValidationException actualFileServiceValidationException =
                Assert.Throws<FileValidationException>(retrieveListOfFiles);

            actualFileServiceValidationException.Should().BeEquivalentTo(expectedFileServiceValidationException);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.GetListOfFiles(inputPath, invalidSearchPattern),
                        Times.Never);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
