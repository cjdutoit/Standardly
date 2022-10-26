// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Standardly.Core.Models.Foundations.Executions;
using Standardly.Core.Models.Foundations.Executions.Exceptions;
using Standardly.Core.Models.Foundations.FileItems;
using Standardly.Core.Models.Foundations.Files.Exceptions;
using Standardly.Core.Models.Foundations.Tasks;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Foundations.Templates.Exceptions;
using Standardly.Core.Services.Foundations.Executions;
using Standardly.Core.Services.Foundations.Files;
using Standardly.Core.Services.Foundations.Templates;
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

        private static Template CreateRandomTemplate(bool replaceFiles = true) =>
            CreateTemplateFiller(replaceFiles).Create();

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
                new FileValidationException(innerException),
                new FileDependencyValidationException(innerException),
            };
        }

        public static TheoryData FindAllTemplateOrchestrationDependencyExceptions()
        {
            string exceptionMessage = GetRandomString();
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Exception>()
            {
                new FileDependencyException(innerException),
                new FileServiceException(innerException),
            };
        }

        public static TheoryData TemplateOrchestrationDependencyValidationExceptions()
        {
            string exceptionMessage = GetRandomString();
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Exception>()
            {
                new FileValidationException(innerException),
                new FileDependencyValidationException(innerException),
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
                new FileDependencyException(innerException),
                new TemplateServiceException(innerException),
                new TemplateDependencyException(innerException),
                new ExecutionServiceException(innerException),
                new ExecutionDependencyException(innerException),
            };
        }

        private static List<FileItem> CreateFileItems(int numberOfFileItems, bool replaceFiles)
        {
            var fileItems = new List<FileItem>();

            for (int i = 0; i < numberOfFileItems; i++)
            {
                fileItems.Add(new Models.Foundations.FileItems.FileItem()
                {
                    Replace = replaceFiles,
                    Template = GetRandomString(),
                    Target = GetRandomString()
                });
            }

            return fileItems;
        }

        private static List<Execution> CreateExecutions(int numberOfExecutions)
        {
            var executions = new List<Execution>();

            for (int i = 0; i < numberOfExecutions; i++)
            {
                executions.Add(new Models.Foundations.Executions.Execution()
                {
                    Name = GetRandomString(),
                    Instruction = GetRandomString()
                });
            }

            return executions;
        }

        private static List<Models.Foundations.Actions.Action> CreateActions(int numberOfActions, bool replaceFiles)
        {
            var actions = new List<Models.Foundations.Actions.Action>();

            for (int i = 0; i < numberOfActions; i++)
            {
                actions.Add(new Models.Foundations.Actions.Action()
                {
                    Name = GetRandomString(),
                    ExecutionFolder = GetRandomString(),
                    FileItems = CreateFileItems(2, replaceFiles),
                    Executions = CreateExecutions(2)
                });
            }

            return actions;
        }

        private static List<Task> CreateTasks(int numberOfTasks, bool replaceFiles)
        {
            var tasks = new List<Task>();

            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks.Add(new Models.Foundations.Tasks.Task()
                {
                    Name = GetRandomString(),
                    Actions = CreateActions(2, replaceFiles)
                });
            }

            return tasks;
        }

        private static Filler<Template> CreateTemplateFiller(bool replaceFiles = true)
        {
            var filler = new Filler<Template>();
            filler.Setup()
                .OnType<List<Task>>().Use(CreateTasks(2, replaceFiles))
                .OnType<Dictionary<string, string>>().Use(CreateDictionary);

            return filler;
        }
    }
}
