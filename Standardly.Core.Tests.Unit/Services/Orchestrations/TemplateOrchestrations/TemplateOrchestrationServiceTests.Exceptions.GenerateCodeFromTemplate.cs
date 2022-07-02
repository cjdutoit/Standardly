// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
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

            // when
            Action generateCodeFromTemplateAction = () =>
               this.templateOrchestrationService.GenerateCodeFromTemplate(inputTemplate, randomReplacementDictionary);

            TemplateOrchestrationDependencyValidationException actualException =
                Assert.Throws<TemplateOrchestrationDependencyValidationException>(generateCodeFromTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedException);

            this.templateServiceMock.Verify(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary),
                    Times.Once);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.powerShellServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(TemplateOrchestrationDependencyExceptions))]
        public void ShouldThrowDependencyExceptionIfDependencyErrorOccursAndLogIt(
           Exception dependencyException)
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();

            TemplateOrchestrationDependencyException expectedException =
               new TemplateOrchestrationDependencyException(
                   dependencyException.InnerException as Xeption);

            this.templateServiceMock.Setup(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary))
                    .Throws(dependencyException);

            // when
            Action generateCodeFromTemplateAction = () =>
               this.templateOrchestrationService.GenerateCodeFromTemplate(inputTemplate, randomReplacementDictionary);

            TemplateOrchestrationDependencyException actualException =
                Assert.Throws<TemplateOrchestrationDependencyException>(generateCodeFromTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedException);

            this.templateServiceMock.Verify(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary),
                    Times.Once);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.powerShellServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShoudThrowServiceExceptionIfServiceErrorOccurs()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();

            var serviceException = new Exception();

            var failedTemplateOrchestrationServiceException =
                new FailedTemplateOrchestrationServiceException(serviceException);

            var expectedTemplateOrchestrationServiceException =
                new TemplateOrchestrationServiceException(failedTemplateOrchestrationServiceException);

            this.templateServiceMock.Setup(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary))
                    .Throws(serviceException);

            // when
            Action generateCodeFromTemplateAction = () =>
               this.templateOrchestrationService.GenerateCodeFromTemplate(inputTemplate, randomReplacementDictionary);

            TemplateOrchestrationServiceException actualException =
                Assert.Throws<TemplateOrchestrationServiceException>(generateCodeFromTemplateAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateOrchestrationServiceException);

            this.templateServiceMock.Verify(templateService =>
                templateService.TransformString(inputTemplate.RawTemplate, randomReplacementDictionary),
                    Times.Once);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.fileServiceMock.VerifyNoOtherCalls();
            this.powerShellServiceMock.VerifyNoOtherCalls();
        }
    }
}
