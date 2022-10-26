// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Standardly.Core.Models.Foundations.Templates.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnTransformStringIfNotAllVariablesReplaced()
        {

            // given
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Dictionary<string, string> inputReplacementDictionary = randomReplacementDictionary;
            string randomStringTemplate = CreateStringTemplate(randomReplacementDictionary);
            string inputStringTemplate = randomStringTemplate;

            var invalidReplacementException = new InvalidReplacementException();

            foreach (KeyValuePair<string, string> replacement in inputReplacementDictionary)
            {
                invalidReplacementException.AddData(
                    key: replacement.Key,
                    values: $"Found '{replacement.Key}' that was not in the replacement dictionary, " +
                        $"fix the errors and try again.");
            }

            var expectedTemplateValidationException =
                new TemplateValidationException(invalidReplacementException);

            // when
            Action transformRawTemplateItemAction = () =>
                this.templateService.ValidateTransformation(inputStringTemplate);

            TemplateValidationException actualException = Assert.Throws<TemplateValidationException>(
                transformRawTemplateItemAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateValidationException);
        }
    }
}
