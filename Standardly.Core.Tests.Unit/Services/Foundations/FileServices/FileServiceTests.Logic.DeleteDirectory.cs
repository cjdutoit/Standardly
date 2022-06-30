using Moq;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Fact]
        public void ShouldDeleteDirectory()
        {
            // given
            string randomFilePath = GetRandomString();
            string inputFilePath = randomFilePath;

            // when
            this.fileService.DeleteDirectory(inputFilePath);

            // then
            this.fileSystemBrokerMock.Verify(broker =>
                broker.DeleteDirectory(inputFilePath, false),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
