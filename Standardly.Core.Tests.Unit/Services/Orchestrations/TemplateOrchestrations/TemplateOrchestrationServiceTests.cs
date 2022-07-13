// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Standardly.Core.Models.Executions.Exceptions;
using Standardly.Core.Models.FileServices.Exceptions;
using Standardly.Core.Models.Templates;
using Standardly.Core.Models.Templates.Exceptions;
using Standardly.Core.Services.Foundations.Executions;
using Standardly.Core.Services.Foundations.FileServices;
using Standardly.Core.Services.Foundations.TemplateServices;
using Standardly.Core.Services.Orchestrations.TemplateOrchestrations;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationServiceTests
    {
        private readonly Mock<IFileService> fileServiceMock;
        private readonly Mock<IExecutionService> executionServiceMock;
        private readonly Mock<ITemplateService> templateServiceMock;
        private readonly ITemplateOrchestrationService templateOrchestrationService;

        public TemplateOrchestrationServiceTests()
        {
            fileServiceMock = new Mock<IFileService>();
            executionServiceMock = new Mock<IExecutionService>();
            templateServiceMock = new Mock<ITemplateService>();

            templateOrchestrationService = new TemplateOrchestrationService(
                fileService: fileServiceMock.Object,
                executionService: executionServiceMock.Object,
                templateService: templateServiceMock.Object);
        }

        private static string[] GetRandomStringArray()
        {
            return Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(item =>
                {
                    return GetRandomString();
                }).ToArray();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string GetRandomString(int wordCount) =>
            new MnemonicString(wordCount: wordCount).GetValue();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static Template CreateRandomTemplate() =>
            CreateTemplateFiller().Create();

        private static Dictionary<string, string> CreateDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                dictionary.Add(GetRandomString(1), GetRandomString());
            }

            return dictionary;
        }

        private static Dictionary<string, string> CreateReplacementDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            for (int i = 0; i < GetRandomNumber(); i++)
            {
                dictionary.Add($"${GetRandomString(1)}$", GetRandomString(1));
            }

            return dictionary;
        }

        public static TheoryData FindAllTemplateOrchestrationTemplatesDependencyValidationExceptions()
        {
            string exceptionMessage = GetRandomString();
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Exception>()
            {
                new FileServiceValidationException(innerException),
                new FileServiceDependencyValidationException(innerException),
            };
        }

        public static TheoryData FindAllTemplateOrchestrationDependencyExceptions()
        {
            string exceptionMessage = GetRandomString();
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Exception>()
            {
                new FileServiceDependencyException(innerException),
                new FileServiceException(innerException),
            };
        }

        public static TheoryData TemplateOrchestrationDependencyValidationExceptions()
        {
            string exceptionMessage = GetRandomString();
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Exception>()
            {
                new FileServiceValidationException(innerException),
                new FileServiceDependencyValidationException(innerException),
                new ExecutionValidationException(innerException),
                new ExecutionDependencyValidationException(innerException),
                new TemplateValidationException(innerException),
                new TemplateDependencyValidationException(innerException),
            };
        }

        public static TheoryData TemplateOrchestrationDependencyExceptions()
        {
            string exceptionMessage = GetRandomString();
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Exception>()
            {
                new FileServiceException(innerException),
                new FileServiceDependencyException(innerException),
                new TemplateServiceException(innerException),
                new TemplateDependencyException(innerException),
                new ExecutionServiceException(innerException),
                new ExecutionDependencyException(innerException),
            };
        }

        private static List<Models.FileItems.FileItem> CreateFileItems(int numberOfFileItems)
        {
            var fileItems = new List<Models.FileItems.FileItem>();

            for (int i = 0; i < numberOfFileItems; i++)
            {
                fileItems.Add(new Models.FileItems.FileItem()
                {
                    Replace = true,
                    Template = GetRandomString(),
                    Target = GetRandomString()
                });
            }

            return fileItems;
        }

        private static List<Models.Executions.Execution> CreateExecutions(int numberOfExecutions)
        {
            var executions = new List<Models.Executions.Execution>();

            for (int i = 0; i < numberOfExecutions; i++)
            {
                executions.Add(new Models.Executions.Execution()
                {
                    Name = GetRandomString(),
                    Instruction = GetRandomString()
                });
            }

            return executions;
        }

        private static List<Models.Actions.Action> CreateActions(int numberOfActions)
        {
            var actions = new List<Models.Actions.Action>();

            for (int i = 0; i < numberOfActions; i++)
            {
                actions.Add(new Models.Actions.Action()
                {
                    Name = GetRandomString(),
                    ExecutionFolder = GetRandomString(),
                    FileItems = CreateFileItems(2),
                    Executions = CreateExecutions(2)
                });
            }

            return actions;
        }

        private static List<Models.Tasks.Task> CreateTasks(int numberOfTasks)
        {
            var tasks = new List<Models.Tasks.Task>();

            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks.Add(new Models.Tasks.Task()
                {
                    Name = GetRandomString(),
                    Actions = CreateActions(2)
                });
            }

            return tasks;
        }

        private static Filler<Template> CreateTemplateFiller()
        {
            var filler = new Filler<Template>();
            filler.Setup()
                .OnType<List<Models.Tasks.Task>>().Use(CreateTasks(2))
                .OnType<Dictionary<string, string>>().Use(CreateDictionary);

            return filler;
        }
    }
}
