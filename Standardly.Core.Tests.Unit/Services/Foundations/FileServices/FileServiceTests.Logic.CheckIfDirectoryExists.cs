// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using Moq;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Fact]
        public void ShouldCheckIfDirectoryExists()
        {
            // given
            string randomFilePath = GetRandomString();
            string inputFilePath = randomFilePath;

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfDirectoryExists(inputFilePath))
                    .Returns(true);

            // when
            bool directoryExists = this.fileService.CheckIfDirectoryExists(inputFilePath);

            // then
            directoryExists.Should().BeTrue();

            this.fileSystemBrokerMock.Verify(broker =>
                broker.CheckIfDirectoryExists(inputFilePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
