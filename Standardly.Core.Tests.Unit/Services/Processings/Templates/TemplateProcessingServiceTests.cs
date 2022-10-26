// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Moq;
using Newtonsoft.Json;
using Standardly.Core.Brokers.Loggings;
using Standardly.Core.Models.Foundations.Executions;
using Standardly.Core.Models.Foundations.FileItems;
using Standardly.Core.Models.Foundations.Tasks;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Foundations.Templates.Exceptions;
using Standardly.Core.Services.Foundations.Templates;
using Standardly.Core.Services.Processings.Templates;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Templates
{
    public partial class TemplateProcessingServiceTests
    {
        private readonly Mock<ITemplateService> templateServiceMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ITemplateProcessingService templateProcessingService;

        public TemplateProcessingServiceTests()
        {
            this.templateServiceMock = new Mock<ITemplateService>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.templateProcessingService = new TemplateProcessingService(
                templateService: this.templateServiceMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        public static TheoryData DependencyValidationExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Xeption>
            {
                new TemplateValidationException(innerException),
                new TemplateDependencyValidationException(innerException)
            };
        }

        public static TheoryData DependencyExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Xeption>
            {
                new TemplateDependencyException(innerException),
                new TemplateServiceException(innerException)
            };
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static string GetRandomString(int wordCount) =>
            new MnemonicString(wordCount: wordCount).GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static Dictionary<string, string> CreateReplacementDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                dictionary.Add($"${GetRandomString(1)}$", GetRandomString(1));
            }

            return dictionary;
        }

        private static string CreateStringTemplate(Dictionary<string, string> dictionary)
        {
            var stringBuilder = new StringBuilder();

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                stringBuilder.Append($"{item.Key} {GetRandomString()} ");
            }

            return stringBuilder.ToString();
        }

        private static List<Execution> CreateListOfExecutions()
        {
            List<Execution> list = new List<Execution>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Execution()
                {
                    Name = GetRandomString(1),
                    Instruction = GetRandomString(1)
                });
            }

            return list;
        }

        private static List<FileItem> CreateListOfFileItems()
        {
            List<FileItem> list = new List<FileItem>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new FileItem()
                {
                    Template = GetRandomString(1),
                    Target = GetRandomString(1),
                    Replace = true
                });
            }

            return list;
        }

        private static List<Models.Foundations.Actions.Action> CreateListOfActions()
        {
            List<Models.Foundations.Actions.Action> list = new List<Models.Foundations.Actions.Action>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Models.Foundations.Actions.Action()
                {
                    Name = GetRandomString(1),
                    ExecutionFolder = GetRandomString(1),
                    FileItems = CreateListOfFileItems(),
                    Executions = CreateListOfExecutions()
                });
            }

            return list;
        }

        private static List<Task> CreateListOfTasks()
        {
            List<Task> list = new List<Task>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                list.Add(new Models.Foundations.Tasks.Task()
                {
                    Name = GetRandomString(1),
                    Actions = CreateListOfActions()
                });
            }

            return list;
        }

        private static string SerializeTemplate(Template template)
        {
            return JsonConvert.SerializeObject(template);
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

        private static Template CreateRandomTemplate()
        {
            Template template = CreateTemplateFiller().Create();
            template.RawTemplate = SerializeTemplate(template);

            return template;
        }

        private static Filler<Template> CreateTemplateFiller()
        {
            var filler = new Filler<Template>();
            filler.Setup()
                .OnType<List<string>>().Use(CreateListOfStrings)
                .OnType<List<Task>>().Use(CreateListOfTasks);

            return filler;
        }
    }
}
