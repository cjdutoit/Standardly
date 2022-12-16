// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Moq;
using Newtonsoft.Json;
using Standardly.Brokers;
using Standardly.Services.Foundations;
using Tynamix.ObjectFiller;

namespace Standardly.Tests.Unit.Services.Foundations
{
    public partial class TemplateServiceTests
    {
        private readonly Mock<IStandardlyClientBroker> standardlyClientBrokerMock;
        private readonly ITemplateService templateService;

        public TemplateServiceTests()
        {
            this.standardlyClientBrokerMock = new Mock<IStandardlyClientBroker>();

            this.templateService = new TemplateService(
                standardlyClientBroker: this.standardlyClientBrokerMock.Object);
        }

        private static string SerializeTemplate(Core.Models.Foundations.Templates.Template template) =>
            JsonConvert.SerializeObject(template);

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 5).GetValue();

        private static string GetRandomString(int wordCount) =>
            new MnemonicString(wordCount: wordCount).GetValue();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static List<Standardly.Core.Models.Foundations.Templates.Tasks.Task> CreateListOfTasks()
        {
            List<Core.Models.Foundations.Templates.Tasks.Task> list =
                new List<Core.Models.Foundations.Templates.Tasks.Task>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Core.Models.Foundations.Templates.Tasks.Task()
                {
                    Name = GetRandomString(1),
                    BranchName = GetRandomString(1),
                    Actions = CreateListOfActions()
                });
            }

            return list;
        }

        private static List<Core.Models.Foundations.Executions.Execution> CreateListOfExecutions()
        {
            List<Core.Models.Foundations.Executions.Execution> list =
                new List<Core.Models.Foundations.Executions.Execution>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Core.Models.Foundations.Executions.Execution()
                {
                    Name = GetRandomString(1),
                    Instruction = GetRandomString(1)
                });
            }

            return list;
        }

        private static List<Core.Models.Foundations.Templates.Tasks.Actions.Appends.Append> CreateListOfAppends()
        {
            List<Core.Models.Foundations.Templates.Tasks.Actions.Appends.Append> list =
                new List<Core.Models.Foundations.Templates.Tasks.Actions.Appends.Append>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Core.Models.Foundations.Templates.Tasks.Actions.Appends.Append()
                {
                    Target = GetRandomString(1),
                    DoesNotContainContent = GetRandomString(1),
                    RegexToMatchForAppend = GetRandomString(1),
                    ContentToAppend = GetRandomString(1),
                    AppendToBeginning = false,
                    AppendEvenIfContentAlreadyExist = false,
                }); ;
            }

            return list;
        }

        private static List<Core.Models.Foundations.Templates.Tasks.Actions.Files.File> CreateListOfFiles()
        {
            List<Core.Models.Foundations.Templates.Tasks.Actions.Files.File> list =
                new List<Core.Models.Foundations.Templates.Tasks.Actions.Files.File>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Core.Models.Foundations.Templates.Tasks.Actions.Files.File()
                {
                    Template = GetRandomString(1),
                    Target = GetRandomString(1),
                    Replace = true
                });
            }

            return list;
        }

        private static List<Standardly.Core.Models.Foundations.Templates.Tasks.Actions.Action> CreateListOfActions()
        {
            List<Core.Models.Foundations.Templates.Tasks.Actions.Action> list =
                new List<Core.Models.Foundations.Templates.Tasks.Actions.Action>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Core.Models.Foundations.Templates.Tasks.Actions.Action()
                {
                    Name = GetRandomString(1),
                    ExecutionFolder = GetRandomString(1),
                    Files = CreateListOfFiles(),
                    Appends = CreateListOfAppends(),
                    Executions = CreateListOfExecutions()
                });
            }

            return list;
        }

        private static List<string> CreateListOfStrings()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(GetRandomString(1));
            }

            return list;
        }

        private static dynamic CreateRandomTemplateProperties()
        {
            Core.Models.Foundations.Templates.Template template = CreateTemplateFiller().Create();
            template.RawTemplate = SerializeTemplate(template);

            return new
            {
                template.RawTemplate,
                template.ModelSingularName,
                template.ModelPluralName,
                template.Name,
                template.Description,
                template.TemplateType,
                template.SortOrder,
                template.ProjectsRequired,
                Tasks = template.Tasks.ToList<dynamic>(),
                CleanupTasks = template.CleanupTasks.ToList<dynamic>(),
            };
        }

        private static List<dynamic> CreateRandomTemplateCollections()
        {
            int randomCount = GetRandomNumber();

            return Enumerable.Range(0, randomCount)
                .Select(item => CreateRandomTemplateProperties())
                    .ToList<dynamic>();
        }

        private static Filler<Core.Models.Foundations.Templates.Template> CreateTemplateFiller()
        {
            var filler = new Filler<Core.Models.Foundations.Templates.Template>();
            filler.Setup()
                .OnType<List<string>>().Use(CreateListOfStrings)
                .OnType<List<Core.Models.Foundations.Templates.Tasks.Task>>().Use(CreateListOfTasks);

            return filler;
        }
    }
}
