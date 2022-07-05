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
using Standardly.Core.Models.FileItems;
using Standardly.Core.Models.Templates;
using Standardly.Core.Services.Foundations.FileServices;
using Standardly.Core.Services.Foundations.PowerShells;
using Standardly.Core.Services.Foundations.TemplateServices;

namespace Standardly.Core.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationService : ITemplateOrchestrationService
    {
        private readonly IFileService fileService;
        private readonly IPowerShellService powerShellService;
        private readonly ITemplateService templateService;
        public string TemplateFolder { get; private set; }
        private readonly string searchPattern = "Template.json";

        public TemplateOrchestrationService(
            IFileService fileService,
            IPowerShellService powerShellService,
            ITemplateService templateService)
        {
            this.fileService = fileService;
            this.powerShellService = powerShellService;
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
                    catch (Exception ex)
                    {
                        // throw new Exception($"Failed to convert raw template {file} to template", ex);
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
                                if (action.FileItems.Any())
                                {
                                    foreach (FileItem fileItem in action.FileItems)
                                    {
                                        if (!string.IsNullOrEmpty(fileItem.Template))
                                        {
                                            string sourceString = this.fileService.ReadFromFile(fileItem.Template);

                                            string transformedSourceString = this.templateService
                                                .TransformString(sourceString, replacementDictionary);

                                            this.templateService.ValidateTransformation(transformedSourceString);

                                            var fileExists = this.fileService.CheckIfFileExists(fileItem.Target);

                                            if (fileExists == false || (fileExists == true && fileItem.Replace == true))
                                            {
                                                this.fileService.WriteToFile(fileItem.Target, transformedSourceString);
                                            }
                                        }
                                    }
                                }

                                if (action.Scripts.Any())
                                {
                                    this.powerShellService.RunScript(action.Scripts, action.ExecutionFolder);
                                }
                            }
                        }
                    }
                }

                return true;
            });
    }
}
