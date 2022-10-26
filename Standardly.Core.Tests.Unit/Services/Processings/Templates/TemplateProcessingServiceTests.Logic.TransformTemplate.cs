// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Foundations.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Templates
{
    public partial class TemplateProcessingServiceTests
    {
        [Fact]
        public void ShouldTransformTemplate()
        {
            // given
            string randomString = GetRandomString();
            string inputString = randomString;
            string randomTransformedString = GetRandomString();
            string transformedString = randomTransformedString;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Dictionary<string, string> inputReplacementDictionary = randomReplacementDictionary;
            Template randomInputTemplate = CreateRandomTemplate();
            Template inputTemplate = randomInputTemplate;
            Template randomTemplate = CreateRandomTemplate();
            Template expectedTemplate = randomTemplate;

            this.templateServiceMock.Setup(service =>
                service.TransformString(inputTemplate.RawTemplate, inputReplacementDictionary))
                    .Returns(transformedString);

            this.templateServiceMock.Setup(service =>
                service.ConvertStringToTemplate(transformedString))
                    .Returns(expectedTemplate);

            // when
            Template actualTemplate = this.templateProcessingService
                .TransformTemplate(inputTemplate, inputReplacementDictionary);

            // then
            actualTemplate.Should().BeEquivalentTo(expectedTemplate);

            this.templateServiceMock.Verify(service =>
                service.TransformString(inputTemplate.RawTemplate, inputReplacementDictionary),
                    Times.Once());

            this.templateServiceMock.Verify(service =>
                service.ValidateTransformation(transformedString),
                    Times.Once());

            this.templateServiceMock.Verify(service =>
                service.ConvertStringToTemplate(transformedString),
                    Times.Once());

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
