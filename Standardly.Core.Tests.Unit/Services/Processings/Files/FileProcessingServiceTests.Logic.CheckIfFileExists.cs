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
        public void ShouldCheckIfFileExists()
        {
            // given
            string randomPath = GetRandomString();
            string inputFilePath = randomPath;
            bool fileCheckResult = true;
            bool expectedResult = fileCheckResult;

            this.fileServiceMock.Setup(service =>
                service.CheckIfFileExists(randomPath))
                    .Returns(fileCheckResult);

            // when
            bool actualResult = this.fileProcessingService.CheckIfFileExists(inputFilePath);

            // then
            actualResult.Should().Be(expectedResult);

            this.fileServiceMock.Verify(service =>
                service.CheckIfFileExists(inputFilePath),
                    Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
