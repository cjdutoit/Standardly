// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

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
        TryCatch(() =>
        {
            ValidateInputs(scripts, executionFolder);
            return this.powerShellBroker.RunScript(scripts, executionFolder);
        });
    }
}
