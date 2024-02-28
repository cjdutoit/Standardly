// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standardly.Core.Models.Services.Orchestrations.TemplateGenerations.Exceptions;
using Standardly.Models.Foundations.Templates;

namespace Standardly.Services.Foundations.Templates
{
    internal partial class TemplateService : ITemplateService
    {
        private void ValidateProcessedEventHandler(
            Func<TemplateGenerationInfo, ValueTask> processedEventHandler)
        {
            if (processedEventHandler is null)
            {
                throw new NullTemplateGenerationInfoEventHandlerException(
                    message: "Template generation event handler is null.");
            }
        }

        private static void ValidateTemplateGenerationInfo(TemplateGenerationInfo templateGenerationInfo)
        {
            ValidateTemplateGenerationInfoIsNotNull(templateGenerationInfo);

            Validate(
                (Rule: IsInvalid(templateGenerationInfo.Templates),
                    Parameter: nameof(templateGenerationInfo.Templates)),
                (Rule: IsInvalid(templateGenerationInfo.ReplacementDictionary),
                    Parameter: nameof(templateGenerationInfo.ReplacementDictionary)));
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(List<Template> templates) => new
        {
            Condition = templates == null || templates.Count == 0,
            Message = "Templates is required"
        };

        private static dynamic IsInvalid(Dictionary<string, string> replacementDictionary) => new
        {
            Condition = replacementDictionary == null,
            Message = "Dictionary values is required"
        };

        private static void ValidateTemplateGenerationInfoIsNotNull(TemplateGenerationInfo templateGenerationInfo)
        {
            if (templateGenerationInfo is null)
            {
                throw new NullTemplateGenerationInfoException(message: "Template generation info is null.");
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidArgumentTemplateGenerationOrchestrationException =
                new InvalidArgumentTemplateGenerationOrchestrationException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidArgumentTemplateGenerationOrchestrationException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidArgumentTemplateGenerationOrchestrationException.ThrowIfContainsErrors();
        }
    }
}
