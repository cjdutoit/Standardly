// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.PowerShellScripts;

namespace Standardly.Core.Services.Foundations.PowerShells
{
    public interface IPowerShellService
    {
        string RunScript(List<PowerShellScript> scripts, string executionFolder);
    }
}
