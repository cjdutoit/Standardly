// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Standardly.Brokers;
using Standardly.Models.Events;
using Standardly.Models.Foundations;
using ExternalAction = Standardly.Core.Models.Foundations.Templates.Tasks.Actions.Action;
using ExternalAppend = Standardly.Core.Models.Foundations.Templates.Tasks.Actions.Appends.Append;
using ExternalExecution = Standardly.Core.Models.Foundations.Executions.Execution;
using ExternalFile = Standardly.Core.Models.Foundations.Templates.Tasks.Actions.Files.File;
using ExternalTask = Standardly.Core.Models.Foundations.Templates.Tasks.Task;
using ExternalTemplate = Standardly.Core.Models.Foundations.Templates.Template;
using InternalAction = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Actions.Action;
using InternalAppend = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Actions.Appends.Append;
using InternalExecution = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Actions.Executions.Execution;
using InternalFile = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Actions.Files.File;
using InternalTask = Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks.Task;
using InternalTemplate = Standardly.Models.Foundations.TemplateGenerations.Templates.Template;

namespace Standardly.Services.Foundations
{
    public partial class TemplateService : ITemplateService
    {
        private readonly IStandardlyClientBroker standardlyClientBroker;

        public TemplateService(IStandardlyClientBroker standardlyClientBroker)
        {
            this.standardlyClientBroker = standardlyClientBroker;
            this.standardlyClientBroker.Processed += ItemProcessed;
        }

        public event EventHandler<ItemProcessedEventArgs> Processed;

        public TemplateGeneration FindAllTemplates()
        {
            List<ExternalTemplate> templates =
                this.standardlyClientBroker.FindAllTemplates();

            List<InternalTemplate> localTemplates =
                templates.Select(AsTemplate).ToList();

            return new TemplateGeneration { Templates = localTemplates };
        }

        public void GenerateCode(TemplateGeneration templateGenerationInfo) =>
            throw new NotImplementedException();

        private static Func<ExternalTemplate, InternalTemplate> AsTemplate => MapToInternalTemplate;
        private static Func<ExternalTask, InternalTask> AsTask => MapToInternalTask;
        private static Func<ExternalAction, InternalAction> AsAction => MapToInternalAction;
        private static Func<ExternalFile, InternalFile> AsFile => MapToInternalFile;
        private static Func<ExternalAppend, InternalAppend> AsAppend => MapToInternalAppend;
        private static Func<ExternalExecution, InternalExecution> AsExecution => MapToInternalExecution;

        private static InternalTemplate MapToInternalTemplate(ExternalTemplate templates)
        {
            return new InternalTemplate
            {
                RawTemplate = templates.RawTemplate,
                ModelSingularName = templates.ModelSingularName,
                ModelPluralName = templates.ModelPluralName,
                Name = templates.Name,
                Description = templates.Description,
                TemplateType = templates.TemplateType,
                SortOrder = templates.SortOrder,
                ProjectsRequired = templates.ProjectsRequired,
                Tasks = templates.Tasks.Select(AsTask).ToList(),
                CleanupTasks = templates.CleanupTasks
            };
        }

        private static InternalTask MapToInternalTask(ExternalTask task)
        {
            return new InternalTask
            {
                Name = task.Name,
                BranchName = task.BranchName,
                Actions = task.Actions.Select(AsAction).ToList(),
            };
        }

        private static InternalAction MapToInternalAction(ExternalAction action)
        {
            return new InternalAction
            {
                Name = action.Name,
                ExecutionFolder = action.ExecutionFolder,
                Files = action.Files.Select(AsFile).ToList(),
                Appends = action.Appends.Select(AsAppend).ToList(),
                Executions = action.Executions.Select(AsExecution).ToList(),
            };
        }

        private static InternalFile MapToInternalFile(ExternalFile file)
        {
            return new InternalFile
            {
                Template = file.Template,
                Target = file.Target,
                Replace = file.Replace,
            };
        }

        private static InternalAppend MapToInternalAppend(ExternalAppend append)
        {
            return new InternalAppend
            {
                Target = append.Target,
                DoesNotContainContent = append.DoesNotContainContent,
                RegexToMatchForAppend = append.RegexToMatchForAppend,
                ContentToAppend = append.ContentToAppend,
                AppendToBeginning = append.AppendToBeginning,
                AppendEvenIfContentAlreadyExist = append.AppendEvenIfContentAlreadyExist,
            };
        }

        private static InternalExecution MapToInternalExecution(ExternalExecution execution)
        {
            return new InternalExecution
            {
                Name = execution.Name,
                Instruction = execution.Instruction,
            };
        }

        private void ItemProcessed(object sender, ItemProcessedEventArgs @event)
        {
            OnProcessed(@event);
        }

        protected virtual void OnProcessed(ItemProcessedEventArgs @event)
        {
            EventHandler<ItemProcessedEventArgs> handler = Processed;
            if (handler != null)
            {
                handler(this, @event);
            }
        }
    }
}
