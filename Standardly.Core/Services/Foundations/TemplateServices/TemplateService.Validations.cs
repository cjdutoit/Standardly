// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

                    actionRules.AddRange(GetFileItemValidationRules(actions[actionIndex], actionIndex));
                    actionRules.AddRange(GetScriptValidationRules(actions[actionIndex], actionIndex));
                }
            }

            return actionRules;
        }

        private List<(dynamic Rule, string Parameter)> GetFileItemValidationRules(Models.Actions.Action action, int actionIndex)
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

        private List<(dynamic Rule, string Parameter)> GetScriptValidationRules(Models.Actions.Action action, int actionIndex)
        {
            var scriptRules = new List<(dynamic Rule, string Parameter)>();

            if (action.Scripts.Any())
            {
                var scripts = action.Scripts;

                for (int scriptIndex = 0; scriptIndex <= scripts.Count - 1; scriptIndex++)
                {
                    scriptRules.Add(
                        (Rule: IsInvalid(scripts[scriptIndex].Name),
                            Parameter: $"Actions[{actionIndex}].Scripts[{scriptIndex}].Name"));

                    scriptRules.Add(
                        (Rule: IsInvalid(scripts[scriptIndex].Script),
                            Parameter: $"Actions[{actionIndex}].Scripts[{scriptIndex}].Script"));
                }
            }

            return scriptRules;
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
