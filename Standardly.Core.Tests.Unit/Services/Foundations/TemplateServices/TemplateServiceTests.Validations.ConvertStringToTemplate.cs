using System;
using FluentAssertions;
using Standardly.Core.Models.Templates;
using Standardly.Core.Models.Templates.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
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
    }
}
