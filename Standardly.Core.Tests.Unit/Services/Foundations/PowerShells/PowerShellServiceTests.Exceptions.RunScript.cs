using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.PowerShellScripts;
using Standardly.Core.Models.PowerShellScripts.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.PowerShells
{
    public partial class PowerShellServiceTests
    {
        [Fact]
        public void ShoudThrowServiceExceptionOnRunScriptIfServiceErrorOccurs()
        {
            // given
            string somePath = GetRandomString();
            string someKey = GetRandomString();
            string someValue = GetRandomString();

            List<PowerShellScript> someScripts =
                new List<PowerShellScript>();

            someScripts.Add(new PowerShellScript() { Name = someKey, Script = someValue });
            var serviceException = new Exception();

            var failedPowerShellServiceException =
                new FailedPowerShellServiceException(serviceException);

            var expectedPowerShellServiceException =
                new PowerShellServiceException(failedPowerShellServiceException);

            this.powerShellBrokerMock.Setup(broker =>
                broker.RunScript(someScripts, somePath))
                    .Throws(serviceException);

            // when
            Action writeToFileAction = () =>
                this.powerShellService.RunScript(someScripts, somePath);

            PowerShellServiceException actualException = Assert
                .Throws<PowerShellServiceException>(writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedPowerShellServiceException);

            this.powerShellBrokerMock.Verify(broker =>
                broker.RunScript(someScripts, somePath),
                    Times.Once);

            this.powerShellBrokerMock.VerifyNoOtherCalls();
        }
    }
}
