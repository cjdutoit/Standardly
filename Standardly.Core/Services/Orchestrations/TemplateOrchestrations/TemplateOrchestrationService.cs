// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Standardly.Core.Models.Foundations.FileItems;
using Standardly.Core.Models.Foundations.Tasks;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Services.Foundations.Executions;
using Standardly.Core.Services.Foundations.Files;
using Standardly.Core.Services.Foundations.TemplateServices;

namespace Standardly.Core.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationService : ITemplateOrchestrationService
    {
        private readonly IFileService fileService;
        private readonly IExecutionService executionService;
        private readonly ITemplateService templateService;
        public string TemplateFolder { get; private set; }
        private readonly string searchPattern = "Template.json";

        public TemplateOrchestrationService(
            IFileService fileService,
            IExecutionService executionService,
            ITemplateService templateService)
        {
            this.fileService = fileService;
            this.executionService = executionService;
            this.templateService = templateService;

            var assembly = Assembly.GetExecutingAssembly().Location;
            TemplateFolder = Path.Combine(Path.GetDirectoryName(assembly), "Templates");
        }

        public List<Template> FindAllTemplates() =>
            TryCatch(() =>
            {
                List<Template> templates = new List<Template>();

                var fileList = this.fileService
                    .RetrieveListOfFiles(this.TemplateFolder, searchPattern);

                foreach (string file in fileList)
                {
                    try
                    {
                        string rawTemplate = this.fileService.ReadFromFile(file);
                        Template template = this.templateService.ConvertStringToTemplate(rawTemplate);
                        templates.Add(template);
                    }
                    catch (Exception)
                    {
                    }
                }

                return templates;
            });

        public string GenerateCodeFromTemplate(Template template, Dictionary<string, string> replacementDictionary) =>
            TryCatch(() =>
            {
                ValidateTemplateIsNotNull(template);

                var transformedStringTemplate = this.templateService
                    .TransformString(template.RawTemplate, replacementDictionary);

                this.templateService.ValidateTransformation(transformedStringTemplate);

                var transformedTemplate = this.templateService
                    .ConvertStringToTemplate(transformedStringTemplate);

                StringBuilder output = new StringBuilder();

                if (transformedTemplate.Tasks.Any())
                {
                    foreach (Task task in transformedTemplate.Tasks)
                    {
                        output.AppendLine($"{DateTime.Now} - Starting on Task '{task.Name}'");

                        if (task.Actions.Any())
                        {
                            foreach (Models.Foundations.Actions.Action action in task.Actions)
                            {
                                if (this.IsActionRequired(action) == true)
                                {
                                    output.AppendLine(
                                        $"{DateTime.Now} - Starting on action '{task.Name} > {action.Name}'");

                                    if (action.FileItems.Any())
                                    {
                                        foreach (FileItem fileItem in action.FileItems)
                                        {
                                            if (!string.IsNullOrEmpty(fileItem.Template))
                                            {
                                                string sourceString = this.fileService.ReadFromFile(fileItem.Template);

                                                string transformedSourceString = this.templateService
                                                    .TransformString(sourceString, replacementDictionary)
                                                    .Replace("##n##", "\\n");

                                                this.templateService.ValidateTransformation(transformedSourceString);

                                                var fileExists = this.fileService.CheckIfFileExists(fileItem.Target);

                                                if (fileExists == false
                                                    || (fileExists == true && fileItem.Replace == true))
                                                {
                                                    output.AppendLine($"{DateTime.Now} - Adding file '{fileItem.Target}'");
                                                    this.fileService.WriteToFile(fileItem.Target, transformedSourceString);
                                                }
                                            }
                                        }
                                    }

                                    if (action.Executions.Any())
                                    {
                                        output.AppendLine(
                                            $"{DateTime.Now} - Starting on executions for '{task.Name} > {action.Name}'");

                                        output.AppendLine(
                                            this.executionService.Run(action.Executions, action.ExecutionFolder));
                                    }
                                }
                            }
                        }
                    }
                }

                return output.ToString();
            });

        private bool IsActionRequired(Models.Foundations.Actions.Action action)
        {
            if (!action.FileItems.Any())
            {
                return true;
            }

            List<FileItem> fileItems = new List<FileItem>();
            fileItems.AddRange(action.FileItems);

            foreach (FileItem fileItem in fileItems.ToList())
            {
                if (this.fileService.CheckIfFileExists(fileItem.Target) && fileItem.Replace == false)
                {
                    fileItems.Remove(fileItem);
                }
            }

            return fileItems.Any();
        }
    }
}
