// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Brokers.PowerShells;
using Standardly.Core.Models.Templates.Exceptions;
using Standardly.Core.Services.Foundations.FileServices;
using Standardly.Core.Services.Foundations.PowerShells;
using Standardly.Core.Services.Foundations.TemplateServices;
using Standardly.Core.Services.Orchestrations.TemplateOrchestrations;
using Tynamix.ObjectFiller;

namespace Standardly.Templating.Tests.Acceptance.TemplateValidations
{
    public partial class TemplateValidationTests
    {
        private readonly IFileService fileService;
        private readonly IPowerShellService powerShellService;
        private readonly ITemplateService templateService;
        private readonly ITemplateOrchestrationService templateOrchestrationService;
        private readonly IFileSystemBroker fileSystemBroker;


        public TemplateValidationTests()
        {
            this.fileSystemBroker = new FileSystemBroker();
            fileService = new FileService(this.fileSystemBroker);
            powerShellService = new PowerShellService(new PowerShellBroker());
            templateService = new TemplateService(this.fileSystemBroker);

            templateOrchestrationService = new TemplateOrchestrationService(
                fileService: fileService,
                powerShellService: powerShellService,
                templateService: templateService);
        }

        private dynamic IsInvalid(string path, string template, string task, string action) => new
        {
            Condition = IsInvalidFilePath(path),
            Message = $"File not found for {Environment.NewLine}" +
                $"Template: {template}{Environment.NewLine}" +
                $"Task: {task}{Environment.NewLine}" +
                $"Action: {action}{Environment.NewLine}" +
                $"Path: {path}{Environment.NewLine}{Environment.NewLine}"
        };

        private bool IsInvalidFilePath(string path) =>
            !System.IO.File.Exists(path);

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 5).GetValue();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidStudentException = new InvalidTemplateException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidStudentException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidStudentException.ThrowIfContainsErrors();
        }

        private static Dictionary<string, string> GetReplacementDictionaryWithRandomValues()
        {
            Dictionary<string, string> replacementsDictionary = new Dictionary<string, string>();

            replacementsDictionary.Add("$basebranch$", GetRandomString());
            replacementsDictionary.Add("$rootnamespace$", GetRandomString());
            replacementsDictionary.Add("$safeitemname$", GetRandomString());
            replacementsDictionary.Add("$safeItemNameSingular$", GetRandomString());
            replacementsDictionary.Add("$safeItemNamePlural$", GetRandomString());
            replacementsDictionary.Add("$parameterSafeItemNameSingular$", GetRandomString());
            replacementsDictionary.Add("$parameterSafeItemNamePlural$", GetRandomString());
            replacementsDictionary.Add("$lowerDescriptionName$", GetRandomString());
            replacementsDictionary.Add("$upperDescriptionName$", GetRandomString());
            replacementsDictionary.Add("$lowerPluralDescriptionName$", GetRandomString());
            replacementsDictionary.Add("$upperPluralDescriptionName$", GetRandomString());
            replacementsDictionary.Add("$solutionFolder$", GetRandomString());
            replacementsDictionary.Add("$templateFolder$", GetRandomString());
            replacementsDictionary.Add("$projectName$", GetRandomString());
            replacementsDictionary.Add("$projectFolder$", GetRandomString());
            replacementsDictionary.Add("$unitTestProjectName$", GetRandomString());
            replacementsDictionary.Add("$unitTestProjectFolder$", GetRandomString());
            replacementsDictionary.Add("$acceptanceTestProjectName$", GetRandomString());
            replacementsDictionary.Add("$acceptanceTestProjectFolder$", GetRandomString());
            replacementsDictionary.Add("$infrastructureBuildProjectName$", GetRandomString());
            replacementsDictionary.Add("$infrastructureBuildProjectFolder$", GetRandomString());
            replacementsDictionary.Add("$infrastructureProvisionProjectName$", GetRandomString());
            replacementsDictionary.Add("$infrastructureProvisionProjectFolder$", GetRandomString());
            replacementsDictionary.Add("$displayName$", GetRandomString());
            replacementsDictionary.Add("$username$", GetRandomString());
            replacementsDictionary.Add("$brokers$", GetRandomString());
            replacementsDictionary.Add("$models$", GetRandomString());
            replacementsDictionary.Add("$services$", GetRandomString());
            replacementsDictionary.Add("$foundations$", GetRandomString());
            replacementsDictionary.Add("$processings$", GetRandomString());
            replacementsDictionary.Add("$orchestrations$", GetRandomString());
            replacementsDictionary.Add("$coordinations$", GetRandomString());
            replacementsDictionary.Add("$controllers$", GetRandomString());
            replacementsDictionary.Add("$year$", GetRandomString());
            replacementsDictionary.Add("$copyright$", GetRandomString());
            replacementsDictionary.Add("$license$", GetRandomString());

            return replacementsDictionary;
        }
    }
}
