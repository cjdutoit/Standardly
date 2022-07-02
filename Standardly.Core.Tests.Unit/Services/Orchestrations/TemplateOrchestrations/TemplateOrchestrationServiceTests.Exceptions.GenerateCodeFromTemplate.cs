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
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationServiceTests
    {
        [Theory]
        [MemberData(nameof(TemplateOrchestrationDependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionIfDependencyValidationErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();

            TemplateOrchestrationDependencyValidationException expectedException =
               new TemplateOrchestrationDependencyValidationException(
                   dependencyValidationException.InnerException as Xeption);

            this.templateServiceMock.Setup(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary))
                    .Throws(dependencyValidationException);

            Action generateCodeFromTemplateAction = () =>
               this.templateOrchestrationService.GenerateCodeFromTemplate(inputTemplate, randomReplacementDictionary);

            TemplateOrchestrationValidationException actualException =
                Assert.Throws<TemplateOrchestrationValidationException>(generateCodeFromTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedException);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.powerShellServiceMock.VerifyNoOtherCalls();
        }
    }
}
