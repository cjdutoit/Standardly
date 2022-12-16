// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
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

        private static dynamic CreateRandomTemplateProperties()
        {
            return new
            {
                RawTemplate = GetRandomString(),
                ModelSingularName = GetRandomString(),
                ModelPluralName = GetRandomString(),
                Name = GetRandomString(),
                Description = GetRandomString(),
                TemplateType = GetRandomString(),
                SortOrder = GetRandomNumber(),
                ProjectsRequired = GetRandomString(),
                Tasks = new List<dynamic> { CreateRandomTaskProperties() },
                CleanupTasks = new List<string> { GetRandomString() }
            };
        }

        private static dynamic CreateRandomTaskProperties()
        {
            return new
            {
                Name = GetRandomString(),
                BranchName = GetRandomString(),
                Actions = new List<dynamic> { GetRandomActionProperties() }
            };
        }

        private static dynamic GetRandomActionProperties()
        {
            return new
            {
                Name = GetRandomString(),
                ExecutionFolder = GetRandomString(),
                Files = new List<dynamic> { GetRandomFileProperties() },
                Appends = new List<dynamic> { GetRandomAppendProperties() },
                Executions = new List<dynamic> { GetRandomExecutionProperties() },
            };
        }

        private static dynamic GetRandomFileProperties()
        {
            return new
            {
                Template = GetRandomString(),
                Target = GetRandomString(),
                Replace = false
            };
        }

        private static dynamic GetRandomAppendProperties()
        {
            return new
            {
                Target = GetRandomString(),
                DoesNotContainContent = GetRandomString(),
                RegexToMatchForAppend = GetRandomString(),
                ContentToAppend = GetRandomString(),
                AppendToBeginning = false,
                AppendEvenIfContentAlreadyExist = false
            };
        }

        private static dynamic GetRandomExecutionProperties()
        {
            return new
            {
                Name = GetRandomString(),
                Instruction = GetRandomString(),
            };
        }
    }
}
