// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Processings.Templates.Exceptions;
using Standardly.Core.Services.Processings.Templates;

namespace Standardly.Core.Services.Foundations.Templates
{
    public partial class TemplateProcessingService : ITemplateProcessingService
    {
        private static void ValidateConvertStringToTemplate(string content)
        {
            Validate((Rule: IsInvalid(content), Parameter: nameof(content)));
        }

        private static void ValidateTemplateIsNotNull(Template template)
        {
            if (template is null)
            {
                throw new NullTemplateProcessingException();
            }
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidArgumentTemplateProcessingException =
                new InvalidArgumentTemplateProcessingException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidArgumentTemplateProcessingException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidArgumentTemplateProcessingException.ThrowIfContainsErrors();
        }
    }
}
