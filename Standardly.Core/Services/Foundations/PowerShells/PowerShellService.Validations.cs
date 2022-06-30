using System;
using System.Collections.Generic;
using Standardly.Core.Models.PowerShellScripts;
using Standardly.Core.Models.PowerShellScripts.Exceptions;

namespace Standardly.Core.Services.Foundations.PowerShells
{
    public partial class PowerShellService
    {
        private void ValidateInputs(List<PowerShellScript> scripts, string executionFolder)
        {
            Validate(GetValidationInputRules(scripts, executionFolder));
        }

        private (dynamic Rule, string Parameter)[] GetValidationInputRules(List<PowerShellScript> scripts, string executionFolder)
        {
            var rules = new List<(dynamic Rule, string Parameter)>();
            rules.Add((Rule: IsInvalid(executionFolder), Parameter: "executionFolder"));
            rules.Add((Rule: IsInvalid(scripts), Parameter: "scripts"));

            return rules.ToArray();
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(List<PowerShellScript> scripts) => new
        {
            Condition = scripts.Count == 0,
            Message = "Scripts is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidPowerShellException = new InvalidPowerShellException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidPowerShellException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidPowerShellException.ThrowIfContainsErrors();
        }
    }
}
