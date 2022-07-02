using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldNotThrowExceptionOnTransformStringIfInputIsNullOrEmpty(string invalidString)
        {
            // given
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Dictionary<string, string> inputReplacementDictionary = randomReplacementDictionary;

            // when
            var transformedTemplate = this.templateService.TransformString(invalidString, inputReplacementDictionary);

            // then
            foreach (KeyValuePair<string, string> item in inputReplacementDictionary)
            {
                transformedTemplate.Should().NotContain(item.Key);

                if (!string.IsNullOrEmpty(invalidString) && invalidString.Contains("item.Key"))
                {
                    transformedTemplate.Should().Contain(item.Value);
                }
            }
        }
        [Theory]
        [MemberData(nameof(DictionaryTheoryData))]
        public void ShouldNotThrowExceptionOnTransformStringIfDictionaryIsNullOrEmpty(Dictionary<string, string> invalidDictionary)
        {
            // given
            string randomStringTemplate = GetRandomString();
            string inputStringTemplate = randomStringTemplate;

            // when
            var transformedTemplate = this.templateService.TransformString(inputStringTemplate, invalidDictionary);

            // then
            if (invalidDictionary != null && invalidDictionary.Any())
            {
                foreach (KeyValuePair<string, string> item in invalidDictionary)
                {
                    transformedTemplate.Should().NotContain(item.Key);

                    if (!string.IsNullOrEmpty(inputStringTemplate) && inputStringTemplate.Contains("item.Key"))
                    {
                        transformedTemplate.Should().Contain(item.Value);
                    }
                }
            }
        }
    }
}
