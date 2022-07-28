// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Standardly.Core.Models.TemplateOrchestrations.Exceptions;
using Standardly.Core.Models.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionIfTemplateIsNull()
        {
            // given
            Template nullTemplate = null;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            var nullTemplateOrchestrationException = new NullTemplateOrchestrationException();

            var expectedTemplateOrchestrationValidationException =
                new TemplateOrchestrationValidationException(nullTemplateOrchestrationException);

            // when
            Action generateCodeFromTemplateAction = () =>
               this.templateOrchestrationService.GenerateCodeFromTemplate(nullTemplate, randomReplacementDictionary);

            TemplateOrchestrationValidationException actualException =
                Assert.Throws<TemplateOrchestrationValidationException>(generateCodeFromTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateOrchestrationValidationException);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.executionServiceMock.VerifyNoOtherCalls();
        }
    }
}
