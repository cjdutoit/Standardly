// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Files
{
    public partial class FileProcessingServiceTests
    {
        [Fact]
        public void ShouldDeleteDirectory()
        {
            // given
            string randomPath = GetRandomString();
            string inputFilePath = randomPath;
            bool recursive = true;

            // when
            this.fileProcessingService.DeleteDirectory(inputFilePath, recursive);

            // then
            this.fileServiceMock.Verify(service =>
                service.DeleteDirectory(inputFilePath, recursive),
                    Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
