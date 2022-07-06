// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Standardly.Core.Models.Executions;
using Standardly.Core.Models.FileItems;
using Standardly.Core.Models.Templates;
using Standardly.Core.Models.Templates.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionWhenIfTemplateIsNullAndLogItAsync()
        {
            // given
            string emptyStringTemplate = String.Empty;

            var nullTemplateException =
                new NullTemplateException();

            var expectedTemplateNotificationValidationException =
                new TemplateValidationException(nullTemplateException);

            // when
            Action convertStringToTemplateAction = () =>
                this.templateService.ConvertStringToTemplate(emptyStringTemplate);

            TemplateValidationException actualTemplateValidationException =
                Assert.Throws<TemplateValidationException>(convertStringToTemplateAction);

            // then
            actualTemplateValidationException.Should().BeEquivalentTo(expectedTemplateNotificationValidationException);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnConvertIfTemplateIsInvalid(string invalidString)
        {
            // given
            Template someTemplate = new Template()
            {
                Name = invalidString,
                Description = invalidString,
                TemplateType = invalidString,
                ProjectsRequired = invalidString,
            };

            string someRawFile = SerializeTemplate(someTemplate);
            string inputRawFile = someRawFile;

            var invalidTemplateException =
                new InvalidTemplateException();

            invalidTemplateException.AddData(
                key: "Template Name",
                values: "Text is required");

            invalidTemplateException.AddData(
                key: "Template Description",
                values: "Text is required");

            invalidTemplateException.AddData(
                key: "Template Type",
                values: "Text is required");

            invalidTemplateException.AddData(
                key: "Template Projects Required",
                values: "Text is required");

            invalidTemplateException.AddData(
                key: "Template Tasks",
                values: "Tasks is required");

            var expectedTemplateValidationException =
                new TemplateValidationException(invalidTemplateException);

            // when
            Action runConvertRawFileToTemplateAction = () =>
                this.templateService.ConvertStringToTemplate(inputRawFile);

            var actualException = Assert.Throws<TemplateValidationException>(
                runConvertRawFileToTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateValidationException);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnConvertIfTemplateTasksIsInvalid(string invalidString)
        {
            // given
            Template someTemplate = new Template()
            {
                Name = GetRandomString(),
                Description = GetRandomString(),
                TemplateType = GetRandomString(),
                ProjectsRequired = GetRandomString()
            };

            Models.Tasks.Task someTask = new Models.Tasks.Task()
            {
                Name = invalidString,
            };

            someTemplate.Tasks.Add(someTask);
            string someRawFile = SerializeTemplate(someTemplate);
            string inputRawFile = someRawFile;

            var invalidTemplateException =
                new InvalidTemplateException();

            invalidTemplateException.AddData(
                key: "Tasks[0].Name",
                values: "Text is required");

            invalidTemplateException.AddData(
                key: "Tasks[0].Actions",
                values: "Actions is required");

            var expectedTemplateValidationException =
                new TemplateValidationException(invalidTemplateException);

            // when
            Action runConvertRawFileToTemplateAction = () =>
                this.templateService.ConvertStringToTemplate(inputRawFile);

            TemplateValidationException actualException = Assert.Throws<TemplateValidationException>(
                runConvertRawFileToTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateValidationException);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnConvertIfTemplateTaskActionsIsInvalid(string invalidString)
        {
            // given
            Template someTemplate = new Template()
            {
                Name = GetRandomString(),
                Description = GetRandomString(),
                TemplateType = GetRandomString(),
                ProjectsRequired = GetRandomString()
            };

            Models.Tasks.Task someTask = new Models.Tasks.Task()
            {
                Name = GetRandomString(),
                Actions = new List<Models.Actions.Action>()
                {
                    new Models.Actions.Action()
                    {
                        Name = invalidString,
                        FileItems = new List<FileItem>(),
                        Executions = new List<Execution>(),
                    }
                }
            };

            someTemplate.Tasks.Add(someTask);
            string someRawFile = SerializeTemplate(someTemplate);
            string inputRawFile = someRawFile;

            var invalidTemplateException =
                new InvalidTemplateException();

            invalidTemplateException.AddData(
                key: "Actions[0].Name",
                values: "Text is required");

            invalidTemplateException.AddData(
                key: "Actions[0].Executions",
                values: "Executions is required");

            var expectedTemplateValidationException =
                new TemplateValidationException(invalidTemplateException);

            // when
            Action runConvertRawFileToTemplateAction = () =>
                this.templateService.ConvertStringToTemplate(inputRawFile);

            TemplateValidationException actualException = Assert.Throws<TemplateValidationException>(
                runConvertRawFileToTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateValidationException);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionWhenTemplateTaskActionFileItemIsInvalid(string invalidString)
        {
            // given
            Template someTemplate = new Template()
            {
                Name = GetRandomString(),
                Description = GetRandomString(),
                TemplateType = GetRandomString(),
                ProjectsRequired = GetRandomString()
            };

            Models.Tasks.Task someTask = new Models.Tasks.Task()
            {
                Name = GetRandomString(),
                Actions = new List<Models.Actions.Action>()
                {
                    new Models.Actions.Action()
                    {
                        Name = GetRandomString(),
                        FileItems = new List<FileItem>()
                        {
                            new FileItem()
                            {
                                Template = invalidString,
                                Target = invalidString
                            },
                        },
                        Executions = new List<Execution>()
                        {
                            new Execution()
                            {
                               Name = GetRandomString(),
                               Instruction = GetRandomString(),
                            },
                        },
                    }
                }
            };

            someTemplate.Tasks.Add(someTask);
            string someRawFile = SerializeTemplate(someTemplate);
            string inputRawFile = someRawFile;

            var invalidTemplateException =
                new InvalidTemplateException();

            invalidTemplateException.AddData(
                key: "Actions[0].FileItems[0].Template",
                values: "Text is required");

            invalidTemplateException.AddData(
                key: "Actions[0].FileItems[0].Target",
                values: "Text is required");

            var expectedTemplateValidationException =
                new TemplateValidationException(invalidTemplateException);

            // when
            Action runConvertRawFileToTemplateAction = () =>
                this.templateService.ConvertStringToTemplate(inputRawFile);

            TemplateValidationException actualException = Assert.Throws<TemplateValidationException>(
                runConvertRawFileToTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateValidationException);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnConvertIfTemplateTaskActionExecutionsIsInvalid(string invalidString)
        {
            // given
            Template someTemplate = new Template()
            {
                Name = GetRandomString(),
                Description = GetRandomString(),
                TemplateType = GetRandomString(),
                ProjectsRequired = GetRandomString()
            };

            Models.Tasks.Task someTask = new Models.Tasks.Task()
            {
                Name = GetRandomString(),
                Actions = new List<Models.Actions.Action>()
                {
                    new Models.Actions.Action()
                    {
                        Name = GetRandomString(),
                        FileItems = new List<FileItem>()
                        {
                            new FileItem()
                            {
                                Template = GetRandomString(),
                                Target = GetRandomString()
                            },
                        },
                        Executions = new List<Execution>()
                        {
                            new Execution()
                            {
                               Name = invalidString,
                               Instruction = invalidString,
                            },
                        },
                    }
                }
            };

            someTemplate.Tasks.Add(someTask);
            string someRawFile = SerializeTemplate(someTemplate);
            string inputRawFile = someRawFile;

            var invalidTemplateException =
                new InvalidTemplateException();

            invalidTemplateException.AddData(
                key: "Actions[0].Executions[0].Name",
                values: "Text is required");

            invalidTemplateException.AddData(
                key: "Actions[0].Executions[0].Instruction",
                values: "Text is required");

            var expectedTemplateValidationException =
                new TemplateValidationException(invalidTemplateException);

            // when
            Action runConvertRawFileToTemplateAction = () =>
                this.templateService.ConvertStringToTemplate(inputRawFile);

            TemplateValidationException actualException = Assert.Throws<TemplateValidationException>(
                runConvertRawFileToTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateValidationException);
        }
    }
}
