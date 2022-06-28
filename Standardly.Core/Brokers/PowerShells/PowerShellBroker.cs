// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using Standardly.Core.Models.PowerShellScripts;

namespace Standardly.Core.Brokers.PowerShells
{
    public class PowerShellBroker : IPowerShellBroker
    {
        private RunspacePool RsPool { get; set; }

        public string RunScript(List<PowerShellScript> scripts, string executionFolder)
        {
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell
                    .AddScript($"cd {executionFolder}");

                foreach (PowerShellScript script in scripts)
                {
                    powershell.AddScript($"{script.Script}");
                }

                List<PSObject> PSOutput = powershell.Invoke().ToList();
                var sb = new StringBuilder();

                foreach (PSObject obj in PSOutput)
                {
                    if (obj != null)
                    {
                        try
                        {
                            string message = obj.Properties["Message"]?.Value.ToString();
                            if (!string.IsNullOrWhiteSpace(message))
                            {
                                sb.AppendLine(message);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                return sb.ToString();
            }
        }
    }
}
