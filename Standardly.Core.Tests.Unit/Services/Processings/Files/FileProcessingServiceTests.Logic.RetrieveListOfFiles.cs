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
        public void ShouldRetrieveListOfFiles()
        {
            // given
            string randomPath = GetRandomString();
            string inputFilePath = randomPath;
            string randomSearchPattern = GetRandomString();
            string inputSearchPattern = randomSearchPattern;
            string[] randomOutput = GetRandomListOfStrings();
            string[] expectedResult = randomOutput;

            this.fileServiceMock.Setup(service =>
                service.RetrieveListOfFiles(inputFilePath, inputSearchPattern))
                    .Returns(expectedResult);

            // when
            string[] actualResult = this.fileProcessingService.RetrieveListOfFiles(inputFilePath, inputSearchPattern);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);

            this.fileServiceMock.Verify(service =>
                service.RetrieveListOfFiles(inputFilePath, inputSearchPattern),
                    Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
