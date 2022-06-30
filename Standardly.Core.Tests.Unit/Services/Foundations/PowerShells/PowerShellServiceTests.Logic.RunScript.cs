using System.Collections.Generic;
using Moq;
using Standardly.Core.Models.PowerShellScripts;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.PowerShells
{
    public partial class PowerShellServiceTests
    {
        [Fact]
        public void ShouldRunScript()
        {
            // given
            string randomFilePath = GetRandomString();
            string inputFilePath = randomFilePath;
            string randomContent = GetRandomString();
            string inputName = randomContent;
            string inputValue = randomContent;

            List<PowerShellScript> inputDictionary = new List<PowerShellScript>();
            inputDictionary.Add(new PowerShellScript() { Name = inputName, Script = inputValue });

            // when
            this.powerShellService.RunScript(inputDictionary, inputFilePath);

            // then
            this.powerShellBrokerMock.Verify(broker =>
                broker.RunScript(inputDictionary, inputFilePath),
                    Times.Once);

            this.powerShellBrokerMock.VerifyNoOtherCalls();
        }
    }
}
