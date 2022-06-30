using FluentAssertions;
using Force.DeepCloner;
using Standardly.Core.Models.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldConvertStringToTemplate()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template expectedTemplate = randomTemplate.DeepClone();
            string randomString = randomTemplate.RawTemplate;
            string inputString = randomString;

            // when
            var actualTemplate = this.templateService.ConvertStringToTemplate(inputString);

            // then
            actualTemplate.Should().BeEquivalentTo(expectedTemplate);
        }
    }
}
