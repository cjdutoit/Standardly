// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Standardly.Core.Models.FileServices.Exceptions;
using Standardly.Core.Models.Templates;
using Standardly.Core.Services.Foundations.FileServices;
using Standardly.Core.Services.Foundations.PowerShells;
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
        private readonly Mock<IPowerShellService> powerShellServiceMock;
        private readonly Mock<ITemplateService> templateServiceMock;
        private readonly ITemplateOrchestrationService templateOrchestrationService;

        public TemplateOrchestrationServiceTests()
        {
            fileServiceMock = new Mock<IFileService>();
            powerShellServiceMock = new Mock<IPowerShellService>();
            templateServiceMock = new Mock<ITemplateService>();

            templateOrchestrationService = new TemplateOrchestrationService(
                fileService: fileServiceMock.Object,
                powerShellService: powerShellServiceMock.Object,
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

        private static List<Models.PowerShellScripts.PowerShellScript> CreatePowerShellScripts(int numberOfPowerShellScripts)
        {
            var scripts = new List<Models.PowerShellScripts.PowerShellScript>();

            for (int i = 0; i < numberOfPowerShellScripts; i++)
            {
                scripts.Add(new Models.PowerShellScripts.PowerShellScript()
                {
                    Name = GetRandomString(),
                    Script = GetRandomString()
                });
            }

            return scripts;
        }

        private static List<Models.Actions.Action> CreateActions(int numberOfActions)
        {
            var actions = new List<Models.Actions.Action>();

            for (int i = 0; i < numberOfActions; i++)
            {
                var task = new Models.Actions.Action()
                {
                    Name = GetRandomString(),
                    ExecutionFolder = GetRandomString(),
                    FileItems = CreateFileItems(2),
                    Scripts = CreatePowerShellScripts(2)
                };
            }

            return actions;
        }

        private static List<Models.Tasks.Task> CreateTasks(int numberOfTasks)
        {
            var tasks = new List<Models.Tasks.Task>();

            for (int i = 0; i < numberOfTasks; i++)
            {
                var task = new Models.Tasks.Task()
                {
                    Name = GetRandomString(),
                    Actions = CreateActions(2)
                };
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
