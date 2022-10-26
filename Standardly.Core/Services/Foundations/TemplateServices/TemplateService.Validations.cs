// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Standardly.Core.Models.Foundations.Executions;
using Standardly.Core.Models.Foundations.Tasks;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Foundations.Templates.Exceptions;

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

        private void ValidateTagReplacement(string template)
        {
            var regex = @"\$([a-zA-Z]*)\$";
            var matches = Regex.Matches(template, regex);
            List<string> tags = new List<string>();

            foreach (Match match in matches)
            {
                if (!tags.Contains(match.Value))
                {
                    tags.Add(match.Value);
                }
            }

            var invalidReplacementException = new InvalidReplacementException();

            foreach (string tag in tags)
            {
                invalidReplacementException.UpsertDataList(
                    key: tag,
                    value: $"Found '{tag}' that was not in the replacement dictionary, " +
                        $"fix the errors and try again.");
            }

            invalidReplacementException.ThrowIfContainsErrors();
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

        private List<(dynamic Rule, string Parameter)> GetActionValidationRules(Task task)
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
                        (Rule: IsInvalid(actions[actionIndex].Executions),
                            Parameter: $"Actions[{actionIndex}].Executions"));

                    actionRules.AddRange(GetFileItemValidationRules(actions[actionIndex], actionIndex));
                    actionRules.AddRange(GetExecutionValidationRules(actions[actionIndex], actionIndex));
                }
            }

            return actionRules;
        }

        private List<(dynamic Rule, string Parameter)> GetFileItemValidationRules(Models.Foundations.Actions.Action action, int actionIndex)
        {
            var fileItemRules = new List<(dynamic Rule, string Parameter)>();

            if (action.FileItems.Any())
            {
                var fileItems = action.FileItems;

                for (int fileItemIndex = 0; fileItemIndex <= fileItems.Count - 1; fileItemIndex++)
                {
                    fileItemRules.Add(
                        (Rule: IsInvalid(fileItems[fileItemIndex].Target),
                            Parameter: $"Actions[{actionIndex}].FileItems[{fileItemIndex}].Target"));

                    fileItemRules.Add(
                        (Rule: IsInvalid(fileItems[fileItemIndex].Template),
                            Parameter: $"Actions[{actionIndex}].FileItems[{fileItemIndex}].Template"));
                }
            }

            return fileItemRules;
        }

        private List<(dynamic Rule, string Parameter)> GetExecutionValidationRules(Models.Foundations.Actions.Action action, int actionIndex)
        {
            var executionRules = new List<(dynamic Rule, string Parameter)>();

            if (action.Executions.Any())
            {
                var executions = action.Executions;

                for (int executionIndex = 0; executionIndex <= executions.Count - 1; executionIndex++)
                {
                    executionRules.Add(
                        (Rule: IsInvalid(executions[executionIndex].Name),
                            Parameter: $"Actions[{actionIndex}].Executions[{executionIndex}].Name"));

                    executionRules.Add(
                        (Rule: IsInvalid(executions[executionIndex].Instruction),
                            Parameter: $"Actions[{actionIndex}].Executions[{executionIndex}].Instruction"));
                }
            }

            return executionRules;
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

        private static dynamic IsInvalid(List<Task> tasks) => new
        {
            Condition = tasks.Count == 0,
            Message = "Tasks is required"
        };

        private static dynamic IsInvalid(List<Models.Foundations.Actions.Action> actions) => new
        {
            Condition = actions.Count == 0,
            Message = "Actions is required"
        };

        private static dynamic IsInvalid(List<Execution> executions) => new
        {
            Condition = executions.Count == 0,
            Message = "Executions is required"
        };

        private static void ValidateSouceFiles(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTemplateSourceException = new InvalidTemplateSourceException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTemplateSourceException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTemplateSourceException.ThrowIfContainsErrors();
        }

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
