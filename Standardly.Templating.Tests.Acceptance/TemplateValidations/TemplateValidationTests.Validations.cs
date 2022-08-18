// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Standardly.Core.Models.Templates;
using Standardly.Core.Models.Templates.Exceptions;
using Xunit;

namespace Standardly.Templating.Tests.Acceptance.TemplateValidations
{
    public partial class TemplateValidationTests
    {
        [Fact]
        public void ShouldVerifyThatAllTemplateDeserialise()
        {
            // given
            string searchPattern = "Template.json";
            StringBuilder errorList = new StringBuilder();

            var assembly = Assembly.GetExecutingAssembly().Location;
            var templateFolder = Path.Combine(Path.GetDirectoryName(assembly), "Templates");

            var fileList = this.fileService
                .RetrieveListOfFiles(templateFolder, searchPattern);

            for (int fileCounter = 0; fileCounter <= fileList.Length - 1; fileCounter++)
            {
                try
                {
                    string rawTemplate = this.fileService.ReadFromFile(fileList[fileCounter]);
                    Template template = this.templateService.ConvertStringToTemplate(rawTemplate);
                }
                catch (TemplateValidationException ex)
                {
                    foreach (DictionaryEntry dictionaryEntry in ex.InnerException.Data)
                    {
                        foreach (string value in dictionaryEntry.Value as List<string>)
                        {
                            errorList
                                .AppendLine($"Template[{fileCounter}].{dictionaryEntry.Key} -> {value}"
                                + Environment.NewLine +
                                $"Path: {fileList[fileCounter].Substring(Path.GetDirectoryName(assembly).Length)}"
                                + Environment.NewLine);
                        }
                    }
                }
            }

            Assert.False(errorList.Length > 0, errorList.ToString());
        }


        [Fact]
        public void ShouldVerifyThatAllTemplateDefinitionsArePresent()
        {
            InvalidTemplateException expectedInvalidTemplateException = new InvalidTemplateException();

            try
            {
                // given
                List<(dynamic Rule, string Parameter)> validationRules = new List<(dynamic rule, string parameter)>();
                Dictionary<string, string> replacementsDictionary = new Dictionary<string, string>();
                List<Template> templates = this.templateOrchestrationService.FindAllTemplates();
                var assembly = Assembly.GetExecutingAssembly().Location;
                var templateFolder = Path.Combine(Path.GetDirectoryName(assembly), "Templates");
                replacementsDictionary.Add("$templateFolder$", templateFolder.Replace("\\", "\\\\"));

                for (int templateCounter = 0; templateCounter <= templates.Count - 1; templateCounter++)
                {
                    Template template = templates[templateCounter];

                    string rawTransformedTemplate = this.templateService
                        .TransformString(template.RawTemplate, replacementsDictionary);

                    Template transformedTemplate = this.templateService
                        .ConvertStringToTemplate(rawTransformedTemplate);

                    for (int taskCounter = 0; taskCounter <= transformedTemplate.Tasks.Count - 1; taskCounter++)
                    {
                        Core.Models.Tasks.Task task = transformedTemplate.Tasks[taskCounter];

                        for (int actionCounter = 0; actionCounter <= task.Actions.Count - 1; actionCounter++)
                        {
                            Core.Models.Actions.Action action = task.Actions[actionCounter];

                            foreach (Core.Models.FileItems.FileItem fileItem in action.FileItems)
                            {
                                validationRules.Add(
                                    (Rule: IsInvalid(
                                            path: fileItem.Template,
                                            template: transformedTemplate.Name ?? $"template[{templateCounter}]",
                                            task: task.Name ?? $"task[{taskCounter}]",
                                            action: action.Name ?? $"action[{actionCounter}]"),
                                        Parameter: nameof(Core.Models.FileItems.FileItem.Template)));
                            }
                        }
                    }
                }

                // when
                Validate(validationRules.ToArray());
            }
            catch (InvalidTemplateException ex)
            {
                foreach (DictionaryEntry dictionaryEntry in ex.Data)
                {
                    string errors = ((List<string>)dictionaryEntry.Value)
                           .Select(value => value).Aggregate((t1, t2) => t1 + $"{Environment.NewLine}" + t2);

                    Assert.True(false, errors);
                }
            }
        }

        [Fact]
        public void ShouldVerifyThatAllTemplatesOnlyHaveTheStandardReplacementVariables()
        {
            InvalidReplacementException invalidReplacementException = new InvalidReplacementException();

            // given
            List<(dynamic Rule, string Parameter)> validationRules = new List<(dynamic rule, string parameter)>();
            Dictionary<string, string> replacementsDictionary = GetReplacementDictionaryWithRandomValues();
            List<Template> templates = this.templateOrchestrationService.FindAllTemplates();

            // when
            for (int templateCounter = 0; templateCounter <= templates.Count - 1; templateCounter++)
            {
                Template template = templates[templateCounter];

                string rawTransformedTemplate = this.templateService
                    .TransformString(template.RawTemplate, replacementsDictionary);

                try
                {
                    this.templateService.ValidateTransformation(rawTransformedTemplate);
                }
                catch (TemplateValidationException templateValidationException)
                {
                    var templateName = template.Name ?? templateCounter.ToString();
                    foreach (DictionaryEntry dictionaryEntry in templateValidationException.InnerException.Data)
                    {
                        invalidReplacementException.Data
                            .Add($"Template[{templateName}].{dictionaryEntry.Key}", dictionaryEntry.Value);
                    }
                }
            }

            // then
            if (invalidReplacementException.Data.Count > 0)
            {
                StringBuilder errorMessages = new StringBuilder();

                foreach (DictionaryEntry dictionaryEntry in invalidReplacementException.Data)
                {
                    string errors = ((List<string>)dictionaryEntry.Value)
                           .Select(value => value).Aggregate((t1, t2) => t1 + $"{Environment.NewLine}" + t2);

                    errorMessages.AppendLine($"{dictionaryEntry.Key}");
                }

                Assert.True(false, errorMessages.ToString());
            }
        }
    }
}

