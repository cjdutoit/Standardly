using System.Collections.Generic;
using Standardly.Core.Models.PowerShellScripts;

namespace Standardly.Core.Services.Foundations.PowerShells
{
    public interface IPowerShellService
    {
        string RunScript(List<PowerShellScript> scripts, string executionFolder);
    }
}
