// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Models.FileItems;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService : ITemplateService
    {
        private readonly IFileSystemBroker fileSystemBroker;

        public TemplateService(IFileSystemBroker fileSystemBroker)
        {
            this.fileSystemBroker = fileSystemBroker;
        }

        public string TransformString(string @string, Dictionary<string, string> replacementDictionary)
        {
            if (string.IsNullOrEmpty(@string))
            {
                return string.Empty;
            }

            string template = @string;

            if (replacementDictionary != null && replacementDictionary.Any())
            {
                foreach (var replacement in replacementDictionary)
                {
                    template = template.Replace(replacement.Key, replacement.Value);
                }
            }

            return template;
        }

        public void ValidateTransformation(string @string) =>
            TryCatch(() =>
            {
                ValidateTagReplacement(@string);
            });

        public Template ConvertStringToTemplate(string @string) =>
            TryCatch(() =>
            {
                ValidateStringTemplateIsNotNull(@string);

                Template template = JsonConvert.DeserializeObject<Template>(@string);
                template.RawTemplate = @string;
                ValidateTemplate(template);

                return template;
            });

        public void ValidateSourceFiles(Template template) =>
            TryCatch(() =>
            {
                List<(dynamic Rule, string Parameter)> validationRules = new List<(dynamic rule, string parameter)>();

                for (int taskCounter = 0; taskCounter <= template.Tasks.Count - 1; taskCounter++)
                {
                    Models.Tasks.Task task = template.Tasks[taskCounter];

                    for (int actionCounter = 0; actionCounter <= task.Actions.Count - 1; actionCounter++)
                    {
                        Models.Actions.Action action = task.Actions[actionCounter];

                        foreach (FileItem fileItem in action.FileItems)
                        {
                            validationRules.Add(
                                (Rule: IsInvalid(
                                        path: fileItem.Template,
                                        template: template.Name,
                                        task: task.Name ?? $"task[{taskCounter}]",
                                        action: action.Name ?? $"action[{actionCounter}]"),
                                    Parameter: nameof(FileItem.Template)));
                        }
                    }
                }
            });

        private dynamic IsInvalid(string path, string template, string task, string action) => new
        {
            Condition = IsInvalidFilePath(path),
            Message = $"File not found for {Environment.NewLine}" +
                $"Template: {template}{Environment.NewLine}" +
                $"Task: {task}{Environment.NewLine}" +
                $"Action: {action}{Environment.NewLine}" +
                $"Path: {path}{Environment.NewLine}{Environment.NewLine}"
        };

        private bool IsInvalidFilePath(string path) =>
            this.fileSystemBroker.CheckIfFileExists(path);
    }
}
