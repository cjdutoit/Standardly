// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using Moq;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Processings.Templates.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Templates
{
    public partial class TemplateProcessingServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnValidateTemplateSourceFilesIfTemplateIsNullAndLogItAsync()
        {
            // given
            Template nullTemplate = null;

            var nullTemplateProcessingException =
                new NullTemplateProcessingException();

            var expectedTemplateProcessingValidationException =
                new TemplateProcessingValidationException(nullTemplateProcessingException);

            // when
            System.Action validateTemplateSourceFilesAction = () =>
                this.templateProcessingService.ValidateTemplateSourceFiles(nullTemplate);

            TemplateProcessingValidationException actualException =
                Assert.Throws<TemplateProcessingValidationException>(validateTemplateSourceFilesAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateProcessingValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTemplateProcessingValidationException))),
                        Times.Once);

            this.templateServiceMock.Verify(broker =>
                broker.ValidateTemplateSourceFiles(nullTemplate),
                    Times.Never);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
