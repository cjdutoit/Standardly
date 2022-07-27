// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using Standardly.Core.Models.Executions;

namespace Standardly.Core.Brokers.ExecutionBroker
{
    public class CliExecutionBroker : IExecutionBroker
    {
        public string Run(List<Execution> executions, string executionFolder)
        {
            List<Execution> executionList = new List<Execution>();
            executionList.Add(new Execution("Execution Folder", $"cd /d \"{executionFolder}\""));
            executionList.AddRange(executions);

            StringBuilder outputMessages = new StringBuilder();

            using (CmdService cmdService =
                new CmdService(
                    "cmd.exe",
                    "/k \"C:\\Program Files\\Microsoft Visual Studio\\2022\\Enterprise\\Common7\\Tools\\VsDevCmd.bat\""))
            {
                foreach (Execution execution in executionList)
                {
                    string output = cmdService.ExecuteCommand(execution.Instruction);
                    outputMessages.AppendLine(output);
                }
            }

            return outputMessages.ToString();
        }
    }
}
