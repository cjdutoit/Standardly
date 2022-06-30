using FluentAssertions;
using Moq;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Fact]
        public void ShouldReadFromFile()
        {
            // given
            string randomFilePath = GetRandomString();
            string inputFilePath = randomFilePath;
            string randomContent = GetRandomString();
            string expectedContent = randomContent;

            this.fileSystemBrokerMock.Setup(broker =>
                broker.ReadFile(inputFilePath))
                    .Returns(expectedContent);

            // when
            string actualContent = this.fileService.ReadFromFile(inputFilePath);

            // then
            actualContent.Should().BeEquivalentTo(expectedContent);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.ReadFile(inputFilePath),
                    Times.Once);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
