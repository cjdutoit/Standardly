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
        public void ShouldReadFromFile()
        {
            // given
            string randomPath = GetRandomString();
            string inputFilePath = randomPath;
            string randomContent = GetRandomString();
            string expectedResult = randomContent;

            this.fileServiceMock.Setup(service =>
                service.ReadFromFile(randomPath))
                    .Returns(expectedResult);

            // when
            string actualResult = this.fileProcessingService.ReadFromFile(inputFilePath);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);

            this.fileServiceMock.Verify(service =>
                service.ReadFromFile(inputFilePath),
                    Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
