using FluentAssertions;
using Moq;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public partial class FileServiceTests
    {
        [Fact]
        public void ShouldRetrieveListOfFiles()
        {
            // given
            string randomFilePath = GetRandomString();
            string inputFilePath = randomFilePath;
            string randomsearchPattern = GetRandomString();
            string inputSearchPattern = randomsearchPattern;
            string[] randomFileList = GetRandomStringArray();
            string[] expectedFileList = randomFileList;

            this.fileSystemBrokerMock.Setup(broker =>
                broker.GetListOfFiles(inputFilePath, inputSearchPattern))
                    .Returns(expectedFileList);

            // when
            string[] actualContent = this.fileService.RetrieveListOfFiles(inputFilePath, inputSearchPattern);

            // then
            actualContent.Should().BeEquivalentTo(expectedFileList);

            this.fileSystemBrokerMock.Verify(broker =>
                broker.GetListOfFiles(inputFilePath, inputSearchPattern),
                    Times.Once);
            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
