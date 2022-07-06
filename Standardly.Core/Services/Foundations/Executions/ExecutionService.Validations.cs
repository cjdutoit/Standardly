// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using Standardly.Core.Models.Executions;
using Standardly.Core.Models.Executions.Exceptions;

namespace Standardly.Core.Services.Foundations.Executions
{
    public partial class ExecutionService
    {
        private void ValidateInputs(List<Execution> executions, string executionFolder)
        {
            Validate(GetValidationInputRules(executions, executionFolder));
        }

        private (dynamic Rule, string Parameter)[] GetValidationInputRules(
            List<Execution> execution, string executionFolder)
        {
            var rules = new List<(dynamic Rule, string Parameter)>();
            rules.Add((Rule: IsInvalid(executionFolder), Parameter: "executionFolder"));
            rules.Add((Rule: IsInvalid(execution), Parameter: "executions"));

            foreach (Execution item in execution)
            {
                rules.Add((Rule: IsInvalid(item), Parameter: $"Execution[{item.Name}]"));
            }

            return rules.ToArray();
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(List<Execution> executions) => new
        {
            Condition = executions.Count == 0,
            Message = "Executions is required"
        };

        private static dynamic IsInvalid(Execution execution) => new
        {
            Condition = String.IsNullOrWhiteSpace(execution.Name) || String.IsNullOrWhiteSpace(execution.Instruction),
            Message = $"Execution required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidExecutionException = new InvalidExecutionException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidExecutionException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidExecutionException.ThrowIfContainsErrors();
        }
    }
}
