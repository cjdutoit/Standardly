using System;
using System.Collections.Generic;
using Standardly.Core.Brokers.PowerShells;
using Standardly.Core.Models.PowerShellScripts;

namespace Standardly.Core.Services.Foundations.PowerShells
{
    public partial class PowerShellService : IPowerShellService
    {
        private readonly IPowerShellBroker powerShellBroker;

        public PowerShellService(
            IPowerShellBroker powerShellBroker)
        {
            this.powerShellBroker = powerShellBroker;
        }

        public string RunScript(List<PowerShellScript> scripts, string executionFolder) =>
            throw new NotImplementedException();
    }
}
