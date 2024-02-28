// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standardly.Brokers;
using Standardly.Models.Foundations.Templates.ProcessedEvents;
using ExternalAction = Standardly.Core.Models.Services.Foundations.Templates.Tasks.Actions.Action;
using ExternalAppend = Standardly.Core.Models.Services.Foundations.Templates.Tasks.Actions.Appends.Append;
using ExternalEntityModel = Standardly.Core.Models.Services.Foundations.Templates.EntityModels.EntityModel;
using ExternalExecution = Standardly.Core.Models.Services.Foundations.Executions.Execution;
using ExternalFile = Standardly.Core.Models.Services.Foundations.Templates.Tasks.Actions.Files.File;
using ExternalTask = Standardly.Core.Models.Services.Foundations.Templates.Tasks.Task;
using ExternalTemplateGenerationInfo = Standardly.Core.Models.Services.Orchestrations
    .TemplateGenerations.TemplateGenerationInfo;
using ExternalTemplates = Standardly.Core.Models.Services.Foundations.Templates.Template;
using InternalEntityModel = Standardly.Models.Foundations.Templates.EntityModels.EntityModel;
using LocalAction = Standardly.Models.Foundations.Templates.Tasks.Actions.Action;
using LocalAppend = Standardly.Models.Foundations.Templates.Tasks.Actions.Appends.Append;
using LocalExecution = Standardly.Models.Foundations.Templates.Tasks.Actions.Executions.Execution;
using LocalFile = Standardly.Models.Foundations.Templates.Tasks.Actions.Files.File;
using LocalTask = Standardly.Models.Foundations.Templates.Tasks.Task;
using LocalTemplate = Standardly.Models.Foundations.Templates.Template;
using LocalTemplateGenerationInfo = Standardly.Models.Foundations.Templates.TemplateGenerationInfo;

namespace Standardly.Services.Foundations.Templates
{
    internal partial class TemplateService : ITemplateService
    {
        private readonly ICodeGenerationBroker codeGenerationBroker;

        public TemplateService(ICodeGenerationBroker codeGenerationBroker)
        {
            this.codeGenerationBroker = codeGenerationBroker;
        }

        public ValueTask<LocalTemplateGenerationInfo> FindAllTemplatesAsync() =>
            TryCatch(async () =>
            {
                List<ExternalTemplates> externalTemplates = await this.codeGenerationBroker.FindAllTemplatesAsync();
                LocalTemplateGenerationInfo templateGenerationInfo = new LocalTemplateGenerationInfo
                {
                    Templates = MapToLocalTemplates(externalTemplates)
                };

                return templateGenerationInfo;
            });

        private List<LocalTemplate> MapToLocalTemplates(List<ExternalTemplates> externalTemplates)
        {
            List<LocalTemplate> localTemplates = new List<LocalTemplate>();

            foreach (ExternalTemplates externalTemplate in externalTemplates)
            {
                LocalTemplate localTemplate = MapToLocalTemplate(externalTemplate);
                localTemplates.Add(localTemplate);
            }

            return localTemplates;
        }

        private LocalTemplate MapToLocalTemplate(ExternalTemplates externalTemplate)
        {
            LocalTemplate localTemplate = new LocalTemplate
            {
                RawTemplate = externalTemplate.RawTemplate,
                ModelSingularName = externalTemplate.ModelSingularName,
                ModelPluralName = externalTemplate.ModelPluralName,
                Name = externalTemplate.Name,
                Description = externalTemplate.Description,
                Organisation = externalTemplate.Organisation,
                Stack = externalTemplate.Stack,
                Language = externalTemplate.Language,
                TemplateType = externalTemplate.TemplateType,
                SortOrder = externalTemplate.SortOrder,
                ProjectsRequired = externalTemplate.ProjectsRequired,
                Tasks = MapToLocalTasks(externalTemplate.Tasks),
                CleanupTasks = externalTemplate.CleanupTasks,
                ReplacementDictionary = externalTemplate.ReplacementDictionary,

            };

            return localTemplate;
        }

        private List<LocalTask> MapToLocalTasks(List<ExternalTask> externalTasks)
        {
            List<LocalTask> localTasks = new List<LocalTask>();

            foreach (ExternalTask externalTask in externalTasks)
            {
                LocalTask localTask = MapToLocalTask(externalTask);
                localTasks.Add(localTask);
            }

            return localTasks;
        }

        private LocalTask MapToLocalTask(ExternalTask externalTask)
        {
            LocalTask localTask = new LocalTask
            {
                Name = externalTask.Name,
                BranchName = externalTask.BranchName,
                Actions = MapToLocalActions(externalTask.Actions),
            };

            return localTask;
        }

        private List<LocalAction> MapToLocalActions(List<ExternalAction> actions)
        {
            List<LocalAction> localActions = new List<LocalAction>();

            foreach (ExternalAction externalAction in actions)
            {
                LocalAction localAction = MapToLocalAction(externalAction);
                localActions.Add(localAction);
            }

            return localActions;
        }

        private LocalAction MapToLocalAction(ExternalAction externalAction)
        {
            LocalAction localAction = new LocalAction
            {
                Name = externalAction.Name,
                ExecutionFolder = externalAction.ExecutionFolder,
                Files = MapToLocalFiles(externalAction.Files),
                Appends = MapToLocalAppends(externalAction.Appends),
                Executions = MapToLocalExecutions(externalAction.Executions)
            };

            return localAction;
        }

        private List<LocalExecution> MapToLocalExecutions(List<ExternalExecution> executions)
        {
            List<LocalExecution> localExecutions = new List<LocalExecution>();

            foreach (ExternalExecution externalExecution in executions)
            {
                LocalExecution localExecution = new LocalExecution
                {
                    Name = externalExecution.Name,
                    Instruction = externalExecution.Instruction
                };

                localExecutions.Add(localExecution);
            }

            return localExecutions;
        }

        private List<LocalAppend> MapToLocalAppends(List<ExternalAppend> appends)
        {
            List<LocalAppend> localAppends = new List<LocalAppend>();

            foreach (ExternalAppend externalAppend in appends)
            {
                LocalAppend localAppend = new LocalAppend
                {
                    Target = externalAppend.Target,
                    DoesNotContainContent = externalAppend.DoesNotContainContent,
                    RegexToMatchForAppend = externalAppend.RegexToMatchForAppend,
                    ContentToAppend = externalAppend.ContentToAppend,
                    AppendToBeginning = externalAppend.AppendToBeginning,
                    AppendEvenIfContentAlreadyExist = externalAppend.AppendEvenIfContentAlreadyExist
                };

                localAppends.Add(localAppend);
            }

            return localAppends;
        }

        private List<LocalFile> MapToLocalFiles(List<ExternalFile> files)
        {
            List<LocalFile> localFiles = new List<LocalFile>();

            foreach (ExternalFile file in files)
            {
                LocalFile localFile = new LocalFile
                {
                    Template = file.Template,
                    Target = file.Target,
                    Replace = file.Replace,
                };

                localFiles.Add(localFile);
            }

            return localFiles;
        }

        public ValueTask GenerateCodeAsync(LocalTemplateGenerationInfo templateGenerationInfo) =>
            TryCatch(async () =>
            {
                ValidateTemplateGenerationInfo(templateGenerationInfo);

                await this.codeGenerationBroker.GenerateCodeAsync(
                    MapToExternalTemplateGenerationInfo(templateGenerationInfo));
            });

        public void SubscribeToProcessedEvent(Func<LocalTemplateGenerationInfo, ValueTask>
            processedEventClientHandler) =>
            TryCatch(() =>
            {
                ValidateProcessedEventHandler(processedEventClientHandler);

                this.codeGenerationBroker.SubscribeToProcessedEvent(async (processed) =>
                {
                    LocalTemplateGenerationInfo templateGenerationInfo = MapToTemplateGenerationInfo(processed);
                    await processedEventClientHandler(templateGenerationInfo);
                });
            });

        private ExternalTemplateGenerationInfo MapToExternalTemplateGenerationInfo(LocalTemplateGenerationInfo templateGenerationInfo)
        {
            ExternalTemplateGenerationInfo externalTemplateGenerationInfo = new ExternalTemplateGenerationInfo
            {
                Templates = MapToExternalTemplates(templateGenerationInfo.Templates),
                EntityModelDefinition = MapToExternalEntityModelDefinition(templateGenerationInfo.EntityModelDefinition),
                Processed = null,
                ReplacementDictionary = templateGenerationInfo.ReplacementDictionary,
                ScriptExecutionIsEnabled = templateGenerationInfo.ScriptExecutionIsEnabled
            };

            return externalTemplateGenerationInfo;
        }

        private List<ExternalTemplates> MapToExternalTemplates(List<LocalTemplate> templates)
        {
            List<ExternalTemplates> externalTemplates = new List<ExternalTemplates>();

            foreach (LocalTemplate template in templates)
            {
                ExternalTemplates externalTemplate = new ExternalTemplates
                {
                    RawTemplate = template.RawTemplate,
                    ModelSingularName = template.ModelSingularName,
                    ModelPluralName = template.ModelPluralName,
                    Name = template.Name,
                    Description = template.Description,
                    Organisation = template.Organisation,
                    Stack = template.Stack,
                    Language = template.Language,
                    TemplateType = template.TemplateType,
                    SortOrder = template.SortOrder,
                    ProjectsRequired = template.ProjectsRequired,
                    Tasks = MapToExternalTasks(template.Tasks),
                    CleanupTasks = template.CleanupTasks,
                    ReplacementDictionary = template.ReplacementDictionary,
                };

                externalTemplates.Add(externalTemplate);
            }

            return externalTemplates;
        }

        private List<ExternalTask> MapToExternalTasks(List<LocalTask> tasks)
        {
            List<ExternalTask> externalTasks = new List<ExternalTask>();

            foreach (LocalTask task in tasks)
            {
                ExternalTask externalTask = new ExternalTask
                {
                    Name = task.Name,
                    BranchName = task.BranchName,
                    Actions = MapToExternalActions(task.Actions),
                };

                externalTasks.Add(externalTask);
            }

            return externalTasks;
        }

        private List<ExternalAction> MapToExternalActions(List<LocalAction> actions)
        {
            List<ExternalAction> externalActions = new List<ExternalAction>();

            foreach (LocalAction action in actions)
            {
                ExternalAction externalAction = new ExternalAction
                {
                    Name = action.Name,
                    ExecutionFolder = action.ExecutionFolder,
                    Files = MapToExternalFiles(action.Files),
                    Appends = MapToExternalAppends(action.Appends),
                    Executions = MapToExternalExecutions(action.Executions)
                };

                externalActions.Add(externalAction);
            }

            return externalActions;
        }

        private List<ExternalExecution> MapToExternalExecutions(List<LocalExecution> executions)
        {
            List<ExternalExecution> externalExecutions = new List<ExternalExecution>();

            foreach (LocalExecution execution in executions)
            {
                ExternalExecution externalExecution = new ExternalExecution
                {
                    Name = execution.Name,
                    Instruction = execution.Instruction
                };

                externalExecutions.Add(externalExecution);
            }

            return externalExecutions;
        }

        private List<ExternalAppend> MapToExternalAppends(List<LocalAppend> appends)
        {
            List<ExternalAppend> externalAppends = new List<ExternalAppend>();

            foreach (LocalAppend append in appends)
            {
                ExternalAppend externalAppend = new ExternalAppend
                {
                    Target = append.Target,
                    DoesNotContainContent = append.DoesNotContainContent,
                    RegexToMatchForAppend = append.RegexToMatchForAppend,
                    ContentToAppend = append.ContentToAppend,
                    AppendToBeginning = append.AppendToBeginning,
                    AppendEvenIfContentAlreadyExist = append.AppendEvenIfContentAlreadyExist
                };

                externalAppends.Add(externalAppend);
            }

            return externalAppends;
        }

        private List<ExternalFile> MapToExternalFiles(List<LocalFile> files)
        {
            List<ExternalFile> externalFiles = new List<ExternalFile>();

            foreach (LocalFile file in files)
            {
                ExternalFile externalFile = new ExternalFile
                {
                    Template = file.Template,
                    Target = file.Target,
                    Replace = file.Replace,
                };

                externalFiles.Add(externalFile);
            }

            return externalFiles;
        }

        private List<ExternalEntityModel> MapToExternalEntityModelDefinition(List<InternalEntityModel> entityModelDefinition)
        {
            List<ExternalEntityModel> externalEntityModelDefinition = new List<ExternalEntityModel>();

            foreach (InternalEntityModel entityModel in entityModelDefinition)
            {
                ExternalEntityModel externalEntityModel = new ExternalEntityModel
                {
                    PropertyType = entityModel.PropertyType,
                    PropertyName = entityModel.PropertyName,
                    Required = entityModel.Required,
                    KeyProperty = entityModel.KeyProperty,
                    AuditProperty = entityModel.AuditProperty
                };

                externalEntityModelDefinition.Add(externalEntityModel);
            }

            return externalEntityModelDefinition;
        }

        private LocalTemplateGenerationInfo MapToTemplateGenerationInfo(ExternalTemplateGenerationInfo
            externalTemplateGenerationInfo)
        {
            LocalTemplateGenerationInfo localTemplateGenerationInfo = new LocalTemplateGenerationInfo
            {
                Processed = new Processed
                {
                    Message = externalTemplateGenerationInfo.Processed.Message,
                    ProcessedItems = externalTemplateGenerationInfo.Processed.ProcessedItems,
                    Status = externalTemplateGenerationInfo.Processed.Status,
                    TimeStamp = externalTemplateGenerationInfo.Processed.TimeStamp,
                    TotalItems = externalTemplateGenerationInfo.Processed.TotalItems,
                }
            };

            return localTemplateGenerationInfo;
        }
    }
}
