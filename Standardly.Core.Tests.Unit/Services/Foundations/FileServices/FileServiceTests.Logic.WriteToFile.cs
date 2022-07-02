// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Fact]
        public void ShouldWriteToFile()
        {
            // given
            string randomFilePath = GetRandomString();
            string inputFilePath = randomFilePath;
            string randomContent = GetRandomString();
            string inputContent = randomContent;

            // when
            this.fileService.WriteToFile(inputFilePath, inputContent);

            // then
            this.fileSystemBrokerMock.Verify(broker =>
                broker.WriteToFile(inputFilePath, inputContent),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
