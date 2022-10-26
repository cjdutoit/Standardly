// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.Templates
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldTransformString()
        {
            // given
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Dictionary<string, string> inputReplacementDictionary = randomReplacementDictionary;
            string randomStringTemplate = CreateStringTemplate(randomReplacementDictionary);
            string inputStringTemplate = randomStringTemplate;

            // when
            var actualTemplate = this.templateService.TransformString(inputStringTemplate, inputReplacementDictionary);

            // then
            foreach (KeyValuePair<string, string> item in inputReplacementDictionary)
            {
                actualTemplate.Should().NotContain(item.Key);

                if (inputStringTemplate.Contains("item.Key"))
                {
                    actualTemplate.Should().Contain(item.Value);
                }
            }
        }
    }
}
