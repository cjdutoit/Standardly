// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Standardly.Core.Models.Executions;

namespace Standardly.Core.Brokers.ExecutionBroker
{
    public class PowerShellExecutionBroker : IExecutionBroker
    {
        public string Run(List<Execution> executions, string executionFolder)
        {
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell
                    .AddScript($"cd {executionFolder}");

                foreach (Execution script in executions)
                {
                    powershell.AddScript($"{script.Instruction}");
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
