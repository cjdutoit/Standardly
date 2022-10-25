// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using Standardly.Core.Models.Executions;
using Standardly.Core.Models.Processings.Executions.Exceptions;

namespace Standardly.Core.Services.Processings.Executions
{
    public partial class ExecutionProcessingService : IExecutionProcessingService
    {
        private static void ValidateOnRun(List<Execution> executions, string executionFolder)
        {
            ValidateExecutionIsNotNull(executions);
            ValidateExecutionFolderIsValid(executionFolder);
        }

        private static bool IsInvalid(string @string) =>
            String.IsNullOrWhiteSpace(@string);

        private static void ValidateExecutionIsNotNull(List<Execution> executions)
        {
            if (executions is null)
            {
                throw new NullExecutionProcessingException();
            }
        }

        private static void ValidateExecutionFolderIsValid(string executionFolder)
        {
            if (String.IsNullOrWhiteSpace(executionFolder))
            {
                throw new InvalidPathExecutionProcessingException();
            }
        }

    }
}
