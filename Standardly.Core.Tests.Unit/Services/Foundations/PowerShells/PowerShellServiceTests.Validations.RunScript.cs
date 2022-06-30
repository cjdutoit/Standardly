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
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnRunScriptsIfPathIsInvalid(string invalidPath)
        {
            // given
            string someKey = GetRandomString();
            string someValue = GetRandomString();

            List<PowerShellScript> someScripts = new List<PowerShellScript>();
            someScripts.Add(new PowerShellScript() { Name = someKey, Script = someValue });

            var invalidPowerShellException =
                new InvalidPowerShellException();

            invalidPowerShellException.AddData(
                key: "executionFolder",
                values: "Text is required");

            var expectedPowerShellValidationException =
                new PowerShellValidationException(invalidPowerShellException);

            // when
            Action runScriptsAction = () =>
                this.powerShellService.RunScript(someScripts, invalidPath);

            PowerShellValidationException actualException = Assert.Throws<PowerShellValidationException>(
                runScriptsAction);

            // then
            actualException.Should().BeEquivalentTo(expectedPowerShellValidationException);

            this.powerShellBrokerMock.Verify(broker =>
                broker.RunScript(someScripts, invalidPath),
                    Times.Never);

            this.powerShellBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowValidationExceptionOnRunScriptsIfScriptIsEmpty()
        {
            // given
            string somePath = GetRandomString();

            List<PowerShellScript> someScripts = new List<PowerShellScript>();

            var invalidPowerShellException =
                new InvalidPowerShellException();

            invalidPowerShellException.AddData(
                key: $"scripts",
                values: "Scripts is required");

            var expectedPowerShellValidationException =
                new PowerShellValidationException(invalidPowerShellException);

            // when
            Action runScriptsAction = () =>
                this.powerShellService.RunScript(someScripts, somePath);

            PowerShellValidationException actualException = Assert.Throws<PowerShellValidationException>(
                runScriptsAction);

            // then
            actualException.Should().BeEquivalentTo(expectedPowerShellValidationException);

            this.powerShellBrokerMock.Verify(broker =>
                broker.RunScript(someScripts, somePath),
                    Times.Never);

            this.powerShellBrokerMock.VerifyNoOtherCalls();
        }
    }
}
