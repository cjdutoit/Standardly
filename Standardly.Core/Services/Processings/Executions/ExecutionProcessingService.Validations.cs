// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.Executions;
using Standardly.Core.Models.Processings.Exceptions;

namespace Standardly.Core.Services.Processings.Executions
{
    public partial class ExecutionProcessingService : IExecutionProcessingService
    {
        private static void ValidateOnRun(List<Execution> executions, string executionFolder)
        {
            ValidateExecutionIsNotNull(executions);
        }

        private static void ValidateExecutionIsNotNull(List<Execution> executions)
        {
            if (executions is null)
            {
                throw new NullExecutionProcessingException();
            }
        }
    }
}
