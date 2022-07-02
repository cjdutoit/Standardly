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

        private static Filler<Template> CreateTemplateFiller()
        {
            var filler = new Filler<Template>();
            filler.Setup()
                .OnType<Dictionary<string, string>>().Use(CreateDictionary); ;

            return filler;
        }
    }
}
