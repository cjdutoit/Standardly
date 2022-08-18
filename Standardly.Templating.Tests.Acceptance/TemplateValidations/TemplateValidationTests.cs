// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using Standardly.Core.Brokers.ExecutionBroker;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Models.RetryConfig;
using Standardly.Core.Models.Templates.Exceptions;
using Standardly.Core.Services.Foundations.Executions;
using Standardly.Core.Services.Foundations.FileServices;
using Standardly.Core.Services.Foundations.TemplateServices;
using Standardly.Core.Services.Orchestrations.TemplateOrchestrations;
using Tynamix.ObjectFiller;

namespace Standardly.Templating.Tests.Acceptance.TemplateValidations
{
    public partial class TemplateValidationTests
    {
        private readonly IRetryConfig retryConfig;
        private readonly IFileService fileService;
        private readonly IExecutionService executionService;
        private readonly ITemplateService templateService;
        private readonly ITemplateOrchestrationService templateOrchestrationService;
        private readonly IFileSystemBroker fileSystemBroker;


        public TemplateValidationTests()
        {
            this.fileSystemBroker = new FileSystemBroker();
            this.retryConfig = new RetryConfig(3, TimeSpan.FromMilliseconds(200));
            fileService = new FileService(this.fileSystemBroker, retryConfig);
            executionService = new ExecutionService(new CliExecutionBroker());
            templateService = new TemplateService(this.fileSystemBroker);

            templateOrchestrationService = new TemplateOrchestrationService(
                fileService: fileService,
                executionService: executionService,
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
            replacementsDictionary.Add("$parameterSafeItemNameSingularLower$", GetRandomString());
            replacementsDictionary.Add("$parameterSafeItemNamePluralLower$", GetRandomString());
            replacementsDictionary.Add("$lowerDescriptionName$", GetRandomString());
            replacementsDictionary.Add("$upperDescriptionName$", GetRandomString());
            replacementsDictionary.Add("$lowerPluralDescriptionName$", GetRandomString());
            replacementsDictionary.Add("$upperPluralDescriptionName$", GetRandomString());
            replacementsDictionary.Add("$solutionFolder$", GetRandomString());
            replacementsDictionary.Add("$templateFolder$", GetRandomString());
            replacementsDictionary.Add("$projectName$", GetRandomString());
            replacementsDictionary.Add("$projectFolder$", GetRandomString());
            replacementsDictionary.Add("$projectFile$", GetRandomString());
            replacementsDictionary.Add("$unitTestProjectName$", GetRandomString());
            replacementsDictionary.Add("$unitTestProjectFolder$", GetRandomString());
            replacementsDictionary.Add("$unitTestProjectFile$", GetRandomString());
            replacementsDictionary.Add("$acceptanceTestProjectName$", GetRandomString());
            replacementsDictionary.Add("$acceptanceTestProjectFolder$", GetRandomString());
            replacementsDictionary.Add("$acceptanceTestProjectFile$", GetRandomString());
            replacementsDictionary.Add("$infrastructureBuildProjectName$", GetRandomString());
            replacementsDictionary.Add("$infrastructureBuildProjectFolder$", GetRandomString());
            replacementsDictionary.Add("$infrastructureBuildProjectFile$", GetRandomString());
            replacementsDictionary.Add("$infrastructureProvisionProjectName$", GetRandomString());
            replacementsDictionary.Add("$infrastructureProvisionProjectFolder$", GetRandomString());
            replacementsDictionary.Add("$infrastructureProvisionProjectFile$", GetRandomString());
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
            replacementsDictionary.Add("$draftPullRequest$", GetRandomString());


            return replacementsDictionary;
        }
    }
}
