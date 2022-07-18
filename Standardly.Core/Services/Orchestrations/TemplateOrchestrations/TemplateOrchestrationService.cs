﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Standardly.Core.Models.FileItems;
using Standardly.Core.Models.Templates;
using Standardly.Core.Services.Foundations.Executions;
using Standardly.Core.Services.Foundations.FileServices;
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

        public bool GenerateCodeFromTemplate(Template template, Dictionary<string, string> replacementDictionary) =>
            TryCatch(() =>
            {
                ValidateTemplateIsNotNull(template);

                var transformedStringTemplate = this.templateService
                    .TransformString(template.RawTemplate, replacementDictionary);

                this.templateService.ValidateTransformation(transformedStringTemplate);

                var transformedTemplate = this.templateService
                    .ConvertStringToTemplate(transformedStringTemplate);

                if (transformedTemplate.Tasks.Any())
                {
                    foreach (Models.Tasks.Task task in transformedTemplate.Tasks)
                    {
                        if (task.Actions.Any())
                        {
                            foreach (Models.Actions.Action action in task.Actions)
                            {
                                if (this.IsActionRequired(action) == true)
                                {
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

                                                if (fileExists == false || (fileExists == true && fileItem.Replace == true))
                                                {
                                                    this.fileService.WriteToFile(fileItem.Target, transformedSourceString);
                                                }
                                            }
                                        }
                                    }

                                    if (action.Executions.Any())
                                    {
                                        this.executionService.Run(action.Executions, action.ExecutionFolder);
                                    }
                                }
                            }
                        }
                    }
                }

                return true;
            });

        private bool IsActionRequired(Models.Actions.Action action)
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
