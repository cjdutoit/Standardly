using System;
using System.Collections.Generic;
using System.Linq;
using Standardly.Core.Models.PowerShellScripts;
using Standardly.Core.Models.Templates;
using Standardly.Core.Models.Templates.Exceptions;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService
    {
        private void ValidateTemplate(Template template)
        {
            var templateRules = new List<(dynamic Rule, string Parameter)>()
            {
                (Rule: IsInvalid(template.Name), Parameter: "Template Name"),
                (Rule: IsInvalid(template.Description), Parameter: "Template Description"),
                (Rule: IsInvalid(template.TemplateType), Parameter: "Template Type"),
                (Rule: IsInvalid(template.ProjectsRequired), Parameter: "Template Projects Required"),
                (Rule: IsInvalid(template.Tasks), Parameter: "Template Tasks")
            };

            templateRules.AddRange(GetTaskValidationRules(template));

            Validate(templateRules.ToArray());
        }

        private List<(dynamic Rule, string Parameter)> GetTaskValidationRules(Template template)
        {
            var taskRules = new List<(dynamic Rule, string Parameter)>();

            if (template.Tasks.Any())
            {
                var tasks = template.Tasks;

                for (int taskIndex = 0; taskIndex <= tasks.Count - 1; taskIndex++)
                {
                    taskRules.Add((Rule: IsInvalid(tasks[taskIndex].Name), Parameter: $"Tasks[{taskIndex}].Name"));
                    taskRules.Add((Rule: IsInvalid(tasks[taskIndex].Actions), Parameter: $"Tasks[{taskIndex}].Actions"));
                    taskRules.AddRange(GetActionValidationRules(tasks[taskIndex]));
                }
            }

            return taskRules;
        }

        private List<(dynamic Rule, string Parameter)> GetActionValidationRules(Models.Tasks.Task task)
        {
            var actionRules = new List<(dynamic Rule, string Parameter)>();

            if (task.Actions.Any())
            {
                var actions = task.Actions;

                for (int actionIndex = 0; actionIndex <= actions.Count - 1; actionIndex++)
                {
                    actionRules.Add(
                        (Rule: IsInvalid(actions[actionIndex].Name),
                                Parameter: $"Actions[{actionIndex}].Name"));

                    actionRules.Add(
                        (Rule: IsInvalid(actions[actionIndex].Scripts),
                            Parameter: $"Actions[{actionIndex}].Scripts"));
                }
            }

            return actionRules;
        }

        private static void ValidateStringTemplateIsNotNull(string stringTemplate)
        {
            if (string.IsNullOrWhiteSpace(stringTemplate))
            {
                throw new NullTemplateException();
            }
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(List<Models.Tasks.Task> tasks) => new
        {
            Condition = tasks.Count == 0,
            Message = "Tasks is required"
        };

        private static dynamic IsInvalid(List<Models.Actions.Action> actions) => new
        {
            Condition = actions.Count == 0,
            Message = "Actions is required"
        };

        private static dynamic IsInvalid(List<PowerShellScript> scripts) => new
        {
            Condition = scripts.Count == 0,
            Message = "Scripts is required"
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
