// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Models.Foundations.Actions;
using Standardly.Core.Models.Foundations.FileItems;
using Standardly.Core.Models.Foundations.Tasks;
using Standardly.Core.Models.Foundations.Templates;

namespace Standardly.Core.Services.Foundations.Templates
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
                    Task task = template.Tasks[taskCounter];

                    for (int actionCounter = 0; actionCounter <= task.Actions.Count - 1; actionCounter++)
                    {
                        Action action = task.Actions[actionCounter];

                        foreach (FileItem fileItem in action.FileItems)
                        {
                            var fileInfo = new FileInfo(fileItem.Template);

                            validationRules.Add(
                                (Rule: IsInvalid(
                                        path: fileItem.Template,
                                        template: template.Name,
                                        task: task.Name ?? $"task[{taskCounter}]",
                                        action: action.Name ?? $"action[{actionCounter}]"),
                                    Parameter: fileInfo.Name));
                        }
                    }
                }

                ValidateSouceFiles(validationRules.ToArray());
            });

        private dynamic IsInvalid(string path, string template, string task, string action) => new
        {
            Condition = IsInvalidFilePath(path),
            Message = $"File not found for " +
                $"Template[{template}]." +
                $"Task[{task}]." +
                $"Action[{action}]." +
                $"Path: {path}"
        };

        private bool IsInvalidFilePath(string path) =>
            !this.fileSystemBroker.CheckIfFileExists(path);
    }
}
