// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using Moq;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Files
{
    public partial class FileProcessingServiceTests
    {
        [Fact]
        public void ShouldCheckIfDirectoryExists()
        {
            // given
            string randomPath = GetRandomString();
            string inputFilePath = randomPath;
            bool expectedResult = true;

            this.fileServiceMock.Setup(service =>
                service.CheckIfDirectoryExists(randomPath))
                    .Returns(expectedResult);

            // when
            bool actualResult = this.fileProcessingService.CheckIfDirectoryExists(inputFilePath);

            // then
            actualResult.Should().Be(expectedResult);

            this.fileServiceMock.Verify(service =>
                service.CheckIfDirectoryExists(inputFilePath),
                    Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
