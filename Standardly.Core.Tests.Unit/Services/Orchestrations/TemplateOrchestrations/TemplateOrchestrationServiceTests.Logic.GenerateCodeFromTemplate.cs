// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.FileItems;
using Standardly.Core.Models.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationServiceTests
    {
        [Fact]
        public void ShouldGenerateCodeFromTemplate()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;
            string randomTransformedStringTemplate = GetRandomString();
            string transformedStringTemplate = randomTransformedStringTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Template randomTransformedTemplate = CreateRandomTemplate();
            Template transformedTemplate = randomTemplate;

            string sourceTemplateString = GetRandomString();
            string targetTemplateString = GetRandomString();
            string executionMessage = GetRandomString();

            this.templateServiceMock.Setup(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary))
                    .Returns(transformedStringTemplate);

            this.templateServiceMock.Setup(templateService =>
                templateService.ConvertStringToTemplate(transformedStringTemplate))
                    .Returns(transformedTemplate);

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
                                        this.fileServiceMock.Setup(fileService =>
                                        fileService.ReadFromFile(fileItem.Template))
                                            .Returns(sourceTemplateString);

                                        this.templateServiceMock.Setup(templateService =>
                                            templateService
                                                .TransformString(sourceTemplateString, randomReplacementDictionary))
                                                    .Returns(targetTemplateString);
                                    }
                                }
                            }

                            if (action.Executions.Any())
                            {
                                this.executionServiceMock.Setup(executionService =>
                                    executionService.Run(action.Executions, action.ExecutionFolder))
                                        .Returns(executionMessage);
                            }
                        }
                    }
                }
            }

            // when
            string actualGenerateCodeFromTemplateResult = this.templateOrchestrationService
                .GenerateCodeFromTemplate(inputTemplate, randomReplacementDictionary);

            // then
            actualGenerateCodeFromTemplateResult.Should().NotBeNullOrEmpty();

            inputTemplate.Tasks.Count.Should().BeGreaterThan(0);

            this.templateServiceMock.Verify(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary),
                    Times.Once);

            this.templateServiceMock.Verify(templateService =>
                templateService.ValidateTransformation(transformedStringTemplate),
                    Times.Once);

            this.templateServiceMock.Verify(templateService =>
                templateService.ConvertStringToTemplate(transformedStringTemplate),
                    Times.Once);

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
                                        this.fileServiceMock.Verify(fileService =>
                                            fileService.CheckIfFileExists(fileItem.Target),
                                                Times.AtLeastOnce);

                                        this.fileServiceMock.Verify(fileService =>
                                            fileService.CheckIfFileExists(fileItem.Target),
                                                Times.AtMost(2));

                                        this.fileServiceMock.Verify(fileService =>
                                        fileService.ReadFromFile(fileItem.Template),
                                            Times.Once);

                                        this.templateServiceMock.Verify(templateService =>
                                            templateService
                                                .TransformString(sourceTemplateString, randomReplacementDictionary),
                                                    Times.AtLeastOnce);

                                        this.templateServiceMock.Verify(templateService =>
                                            templateService
                                                .ValidateTransformation(targetTemplateString),
                                                    Times.AtLeastOnce);

                                        this.fileServiceMock.Verify(fileService =>
                                            fileService.WriteToFile(fileItem.Target, targetTemplateString),
                                                Times.AtLeastOnce);
                                    }
                                }
                            }

                            if (action.Executions.Any())
                            {
                                this.executionServiceMock.Verify(executionService =>
                                executionService.Run(action.Executions, action.ExecutionFolder),
                                    Times.Once);
                            }
                        }
                    }
                }
            }

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.executionServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldNotExecuteActionWhereFilesExistsAndReplaceSetToFalse()
        {
            // given
            bool replaceFiles = false;
            Template randomTemplate = CreateRandomTemplate(replaceFiles);
            Template inputTemplate = randomTemplate;
            string randomTransformedStringTemplate = GetRandomString();
            string transformedStringTemplate = randomTransformedStringTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Template randomTransformedTemplate = CreateRandomTemplate();
            Template transformedTemplate = randomTemplate;

            string sourceTemplateString = GetRandomString();
            string targetTemplateString = GetRandomString();
            string executionMessage = GetRandomString();

            this.templateServiceMock.Setup(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary))
                    .Returns(transformedStringTemplate);

            this.templateServiceMock.Setup(templateService =>
                templateService.ConvertStringToTemplate(transformedStringTemplate))
                    .Returns(transformedTemplate);

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
                                    this.fileServiceMock.Setup(fileService =>
                                        fileService.CheckIfFileExists(fileItem.Target))
                                            .Returns(true);

                                    this.fileServiceMock.Setup(fileService =>
                                        fileService.ReadFromFile(fileItem.Template))
                                            .Returns(sourceTemplateString);

                                    this.templateServiceMock.Setup(templateService =>
                                        templateService
                                            .TransformString(sourceTemplateString, randomReplacementDictionary))
                                                .Returns(targetTemplateString);
                                }
                            }
                        }
                    }
                }
            }

            // when
            string actualGenerateCodeFromTemplateResult = this.templateOrchestrationService
                .GenerateCodeFromTemplate(inputTemplate, randomReplacementDictionary);

            // then
            actualGenerateCodeFromTemplateResult.Should().NotBeNullOrEmpty();

            inputTemplate.Tasks.Count.Should().BeGreaterThan(0);

            this.templateServiceMock.Verify(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary),
                    Times.Once);

            this.templateServiceMock.Verify(templateService =>
                templateService.ValidateTransformation(transformedStringTemplate),
                    Times.Once);

            this.templateServiceMock.Verify(templateService =>
                templateService.ConvertStringToTemplate(transformedStringTemplate),
                    Times.Once);

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
                                    this.fileServiceMock.Verify(fileService =>
                                        fileService.CheckIfFileExists(fileItem.Target),
                                            Times.Once);

                                    if (!string.IsNullOrEmpty(fileItem.Template))
                                    {
                                        this.fileServiceMock.Verify(fileService =>
                                        fileService.ReadFromFile(fileItem.Template),
                                            Times.Never);

                                        this.templateServiceMock.Verify(templateService =>
                                            templateService
                                                .TransformString(sourceTemplateString, randomReplacementDictionary),
                                                    Times.Never);

                                        this.templateServiceMock.Verify(templateService =>
                                            templateService
                                                .ValidateTransformation(targetTemplateString),
                                                    Times.Never);

                                        this.fileServiceMock.Verify(fileService =>
                                            fileService.WriteToFile(fileItem.Target, targetTemplateString),
                                                Times.Never);
                                    }
                                }
                            }

                            if (action.Executions.Any())
                            {
                                this.executionServiceMock.Verify(executionService =>
                                executionService.Run(action.Executions, action.ExecutionFolder),
                                    Times.Never);
                            }
                        }
                    }
                }
            }

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.executionServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldExecuteActionIfNoFilesPresentOnAction()
        {
            // given
            bool replaceFiles = false;
            Template randomTemplate = CreateRandomTemplate(replaceFiles);
            Template inputTemplate = randomTemplate;
            string randomTransformedStringTemplate = GetRandomString();
            string transformedStringTemplate = randomTransformedStringTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Template randomTransformedTemplate = CreateRandomTemplate();
            Template transformedTemplate = randomTemplate;

            string sourceTemplateString = GetRandomString();
            string targetTemplateString = GetRandomString();
            string executionMessage = GetRandomString();

            this.templateServiceMock.Setup(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary))
                    .Returns(transformedStringTemplate);

            this.templateServiceMock.Setup(templateService =>
                templateService.ConvertStringToTemplate(transformedStringTemplate))
                    .Returns(transformedTemplate);

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
                                action.FileItems.Clear();
                            }
                        }
                    }
                }
            }

            // when
            string actualGenerateCodeFromTemplateResult = this.templateOrchestrationService
                .GenerateCodeFromTemplate(inputTemplate, randomReplacementDictionary);

            // then
            actualGenerateCodeFromTemplateResult.Should().NotBeNullOrEmpty();

            inputTemplate.Tasks.Count.Should().BeGreaterThan(0);

            this.templateServiceMock.Verify(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary),
                    Times.Once);

            this.templateServiceMock.Verify(templateService =>
                templateService.ValidateTransformation(transformedStringTemplate),
                    Times.Once);

            this.templateServiceMock.Verify(templateService =>
                templateService.ConvertStringToTemplate(transformedStringTemplate),
                    Times.Once);

            if (transformedTemplate.Tasks.Any())
            {
                foreach (Models.Tasks.Task task in transformedTemplate.Tasks)
                {
                    if (task.Actions.Any())
                    {
                        foreach (Models.Actions.Action action in task.Actions)
                        {
                            if (action.Executions.Any())
                            {
                                this.executionServiceMock.Verify(executionService =>
                                executionService.Run(action.Executions, action.ExecutionFolder),
                                    Times.Once);
                            }
                        }
                    }
                }
            }

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.executionServiceMock.VerifyNoOtherCalls();
        }

    }
}
