// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using Moq;
using Standardly.Core.Models.Foundations.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Templates
{
    public partial class TemplateProcessingServiceTests
    {
        [Fact]
        public void ShouldConvertStringToTemplateExecution()
        {
            // given
            string randomString = GetRandomString();
            string inputString = randomString;
            Template randomTemplate = CreateRandomTemplate();
            Template expectedTemplate = randomTemplate;

            this.templateServiceMock.Setup(service =>
                service.ConvertStringToTemplate(inputString))
                    .Returns(expectedTemplate);

            // when
            Template actualTemplate = this.templateProcessingService
                .ConvertStringToTemplate(inputString);

            // then
            actualTemplate.Should().BeEquivalentTo(expectedTemplate);

            this.templateServiceMock.Verify(service =>
                service.ConvertStringToTemplate(inputString),
                    Times.Once());

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
