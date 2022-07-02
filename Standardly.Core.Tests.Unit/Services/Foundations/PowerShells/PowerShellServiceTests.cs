// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Standardly.Core.Brokers.PowerShells;
using Standardly.Core.Services.Foundations.PowerShells;
using Tynamix.ObjectFiller;

namespace Standardly.Core.Tests.Unit.Services.Foundations.PowerShells
{
    public partial class PowerShellServiceTests
    {
        private readonly Mock<IPowerShellBroker> powerShellBrokerMock;
        private readonly IPowerShellService powerShellService;

        public PowerShellServiceTests()
        {
            powerShellBrokerMock = new Mock<IPowerShellBroker>();

            this.powerShellService = new PowerShellService(
                powerShellBroker: this.powerShellBrokerMock.Object);
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
