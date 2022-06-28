// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.PowerShellScripts;

namespace Standardly.Core.Brokers.PowerShells
{
    public interface IPowerShellBroker
    {
        string RunScript(List<PowerShellScript> scripts, string executionFolder);
    }
}
