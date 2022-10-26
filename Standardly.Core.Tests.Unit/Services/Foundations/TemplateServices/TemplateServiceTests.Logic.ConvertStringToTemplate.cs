// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Standardly.Core.Models.Foundations.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.Templates
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
            actualTemplate.RawTemplate.Should().BeEquivalentTo(inputString);
        }
    }
}
