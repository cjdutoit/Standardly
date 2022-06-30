using System;
using System.Collections.Generic;
using Standardly.Core.Models.Templates;
using Standardly.Core.Models.Templates.Exceptions;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService
    {
        private void ValidateTemplate(Template template)
        {
            Validate(
                (Rule: IsInvalid(template.Name), Parameter: "Template Name"),
                (Rule: IsInvalid(template.Description), Parameter: "Template Description"),
                (Rule: IsInvalid(template.TemplateType), Parameter: "Template Type"),
                (Rule: IsInvalid(template.ProjectsRequired), Parameter: "Template Projects Required"),
                (Rule: IsInvalid(template.Tasks), Parameter: "Template Tasks"));
        }

        private static dynamic IsInvalid(string text, bool condition = true) => new
        {
            Condition = String.IsNullOrWhiteSpace(text) && condition,
            Message = "Text is required"
        };

        private static dynamic IsInvalid(List<Models.Tasks.Task> tasks) => new
        {
            Condition = tasks.Count == 0,
            Message = "Tasks is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTemplateException = new InvalidTemplateException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTemplateException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTemplateException.ThrowIfContainsErrors();
        }
    }
}
