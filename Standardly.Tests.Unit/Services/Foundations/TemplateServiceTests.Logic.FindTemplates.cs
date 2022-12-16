// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Models.Foundations;
using Xunit;
using ExternalAction = Standardly.Core.Models.Foundations.Templates.Tasks.Actions.Action;
using ExternalAppend = Standardly.Core.Models.Foundations.Templates.Tasks.Actions.Appends.Append;
using ExternalExecution = Standardly.Core.Models.Foundations.Executions.Execution;
using ExternalFile = Standardly.Core.Models.Foundations.Templates.Tasks.Actions.Files.File;
using ExternalTask = Standardly.Core.Models.Foundations.Templates.Tasks.Task;
using ExternalTemplate = Standardly.Core.Models.Foundations.Templates.Template;
using InternalAction = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Actions.Action;
using InternalAppend = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Actions.Appends.Append;

using InternalExecution = Standardly.Models.Foundations.TemplateGenerations.Templates
    .Tasks.Actions.Executions.Execution;

using InternalFile = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Actions.Files.File;
using InternalTask = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Task;
using InternalTemplate = Standardly.Models.Foundations.TemplateGenerations.Templates.Template;


namespace Standardly.Tests.Unit.Services.Foundations
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldFindTemplates()
        {
            // given
            dynamic randomTemplateProperties = CreateRandomTemplateProperties();
            List<ExternalTemplate> returnedTemplates = MapToExternalTemplate(randomTemplateProperties);
            List<InternalTemplate> expectedTemplates = MapToInternalTemplate(randomTemplateProperties);

            TemplateGeneration expectedTemplateGeneration =
                new TemplateGeneration
                {
                    Templates = expectedTemplates,
                    EntityModelDefinition = null,
                    ReplacementDictionary = null,
                    ScriptExecutionIsEnabled = false,
                };

            this.standardlyClientBrokerMock.Setup(broker =>
                broker.FindAllTemplates())
                    .Returns(returnedTemplates);

            // when
            TemplateGeneration actualTemplateGeneration =
                this.templateService.FindAllTemplates();

            // then
            actualTemplateGeneration.Templates.Should().BeEquivalentTo(expectedTemplates);

            this.standardlyClientBrokerMock.Verify(broker =>
                broker.FindAllTemplates(),
                    Times.Once());
        }

        private static List<InternalTemplate> MapToInternalTemplate(dynamic randomTemplateProperties)
        {
            return new List<InternalTemplate>
            {
                new InternalTemplate
                {
                    RawTemplate = randomTemplateProperties.RawTemplate,
                    ModelSingularName = randomTemplateProperties.ModelSingularName,
                    ModelPluralName = randomTemplateProperties.ModelPluralName,
                    Name = randomTemplateProperties.Name,
                    Description = randomTemplateProperties.Description,
                    TemplateType = randomTemplateProperties.TemplateType,
                    SortOrder = randomTemplateProperties.SortOrder,
                    ProjectsRequired = randomTemplateProperties.ProjectsRequired,
                    Tasks =
                        new List<InternalTask>
                        {
                            new InternalTask
                            {
                                Name = randomTemplateProperties.Tasks[0].Name,
                                BranchName = randomTemplateProperties.Tasks[0].BranchName,
                                Actions = new List<InternalAction>
                                {
                                    new InternalAction
                                    {
                                        Name = randomTemplateProperties.Tasks[0].Actions[0].Name,
                                        ExecutionFolder = randomTemplateProperties.Tasks[0].Actions[0].ExecutionFolder,
                                        Files = new List<InternalFile>
                                        {
                                            new InternalFile
                                            {
                                                Template =
                                                    randomTemplateProperties.Tasks[0].Actions[0].Files[0].Template,
                                                Target = randomTemplateProperties.Tasks[0].Actions[0].Files[0].Template,
                                                Replace = randomTemplateProperties.Tasks[0].Actions[0].Files[0].Replace,
                                            }
                                        },
                                        Appends = new List<InternalAppend>
                                        {
                                            new InternalAppend
                                            {
                                                Target =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].Target,
                                                DoesNotContainContent =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].DoesNotContainContent,
                                                RegexToMatchForAppend =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].RegexToMatchForAppend,
                                                ContentToAppend =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].ContentToAppend,
                                                AppendToBeginning =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].AppendToBeginning,
                                                AppendEvenIfContentAlreadyExist =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].AppendEvenIfContentAlreadyExist,
                                            }
                                        },
                                        Executions = new List<InternalExecution>
                                        {
                                            new InternalExecution
                                            {
                                                Name = randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Executions[0].Name,
                                                Instruction = randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Executions[0].Instruction,
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    CleanupTasks = randomTemplateProperties.CleanupTasks,
                }
            };
        }

        private static List<ExternalTemplate> MapToExternalTemplate(dynamic randomTemplateProperties)
        {
            return new List<ExternalTemplate>
            {
                new ExternalTemplate
                {
                    RawTemplate = randomTemplateProperties.RawTemplate,
                    ModelSingularName = randomTemplateProperties.ModelSingularName,
                    ModelPluralName = randomTemplateProperties.ModelPluralName,
                    Name = randomTemplateProperties.Name,
                    Description = randomTemplateProperties.Description,
                    TemplateType = randomTemplateProperties.TemplateType,
                    SortOrder = randomTemplateProperties.SortOrder,
                    ProjectsRequired = randomTemplateProperties.ProjectsRequired,
                    Tasks =
                        new List<ExternalTask>
                        {
                            new ExternalTask
                            {
                                Name = randomTemplateProperties.Tasks[0].Name,
                                BranchName = randomTemplateProperties.Tasks[0].BranchName,
                                Actions = new List<ExternalAction>
                                {
                                    new ExternalAction
                                    {
                                        Name = randomTemplateProperties.Tasks[0].Actions[0].Name,
                                        ExecutionFolder = randomTemplateProperties.Tasks[0].Actions[0].ExecutionFolder,
                                        Files = new List<ExternalFile>
                                        {
                                            new ExternalFile
                                            {
                                                Template =
                                                    randomTemplateProperties.Tasks[0].Actions[0].Files[0].Template,
                                                Target = randomTemplateProperties.Tasks[0].Actions[0].Files[0].Template,
                                                Replace = randomTemplateProperties.Tasks[0].Actions[0].Files[0].Replace,
                                            }
                                        },
                                        Appends = new List<ExternalAppend>
                                        {
                                            new ExternalAppend
                                            {
                                                Target =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].Target,
                                                DoesNotContainContent =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].DoesNotContainContent,
                                                RegexToMatchForAppend =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].RegexToMatchForAppend,
                                                ContentToAppend =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].ContentToAppend,
                                                AppendToBeginning =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].AppendToBeginning,
                                                AppendEvenIfContentAlreadyExist =
                                                    randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Appends[0].AppendEvenIfContentAlreadyExist,
                                            }
                                        },
                                        Executions = new List<ExternalExecution>
                                        {
                                            new ExternalExecution
                                            {
                                                Name = randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Executions[0].Name,
                                                Instruction = randomTemplateProperties.Tasks[0].Actions[0]
                                                        .Executions[0].Instruction,
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    CleanupTasks = randomTemplateProperties.CleanupTasks,
                }
            };
        }
    }
}
