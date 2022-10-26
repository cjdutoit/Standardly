// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Standardly.Core.Models.Foundations.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Templates
{
    public partial class TemplateProcessingServiceTests
    {
        [Fact]
        public void ShouldValidateTemplateSourceFiles()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;

            // when
            this.templateProcessingService
                .ValidateTemplateSourceFiles(inputTemplate);

            // then
            this.templateServiceMock.Verify(service =>
                service.ValidateTemplateSourceFiles(inputTemplate),
                    Times.Once());

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
