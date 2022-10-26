// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using Moq;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Processings.Templates.Exceptions;
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Templates
{
    public partial class TemplateProcessingServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationOnTransformTemplateIfDependencyValidationErrorOccursAndLogItAsync(
            Xeption dependencyValidationException)
        {
            // given
            Template randomInputTemplate = CreateRandomTemplate();
            Template inputTemplate = randomInputTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Dictionary<string, string> inputReplacementDictionary = randomReplacementDictionary;

            var expectedTemplateProcessingDependencyValidationException =
                new TemplateProcessingDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.templateServiceMock.Setup(service =>
                service.TransformString(inputTemplate.RawTemplate, inputReplacementDictionary))
                    .Throws(dependencyValidationException);

            // when
            System.Action TransformTemplateAction = () =>
                this.templateProcessingService.TransformTemplate(inputTemplate, inputReplacementDictionary);

            // then
            TemplateProcessingDependencyValidationException actualException =
                Assert.Throws<TemplateProcessingDependencyValidationException>(TransformTemplateAction);

            this.templateServiceMock.Verify(service =>
                service.TransformString(inputTemplate.RawTemplate, inputReplacementDictionary),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTemplateProcessingDependencyValidationException))),
                        Times.Once);

            this.templateServiceMock.Verify(service =>
                service.ValidateTransformation(It.IsAny<string>()),
                    Times.Never());

            this.templateServiceMock.Verify(service =>
                service.ConvertStringToTemplate(It.IsAny<string>()),
                    Times.Never());

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyOnTransformTemplateIfDependencyErrorOccursAndLogItAsync(
            Xeption dependencyException)
        {
            // given
            Template randomInputTemplate = CreateRandomTemplate();
            Template inputTemplate = randomInputTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Dictionary<string, string> inputReplacementDictionary = randomReplacementDictionary;

            var expectedTemplateProcessingDependencyException =
                new TemplateProcessingDependencyException(
                    dependencyException.InnerException as Xeption);

            this.templateServiceMock.Setup(service =>
                service.TransformString(inputTemplate.RawTemplate, inputReplacementDictionary))
                    .Throws(dependencyException);

            // when
            System.Action TransformTemplateAction = () =>
                this.templateProcessingService.TransformTemplate(inputTemplate, inputReplacementDictionary);

            // then
            TemplateProcessingDependencyException actualException =
                Assert.Throws<TemplateProcessingDependencyException>(TransformTemplateAction);

            this.templateServiceMock.Verify(service =>
                service.TransformString(inputTemplate.RawTemplate, inputReplacementDictionary),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTemplateProcessingDependencyException))),
                        Times.Once);

            this.templateServiceMock.Verify(service =>
                service.ValidateTransformation(It.IsAny<string>()),
                    Times.Never());

            this.templateServiceMock.Verify(service =>
                service.ConvertStringToTemplate(It.IsAny<string>()),
                    Times.Never());

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnTransformTemplateIfServiceErrorOccursAndLogItAsync()
        {
            // given
            Template randomInputTemplate = CreateRandomTemplate();
            Template inputTemplate = randomInputTemplate;
            Dictionary<string, string> randomReplacementDictionary = CreateReplacementDictionary();
            Dictionary<string, string> inputReplacementDictionary = randomReplacementDictionary;

            var serviceException = new Exception();

            var failedTemplateProcessingServiceException =
                new FailedTemplateProcessingServiceException(serviceException);

            var expectedTemplateProcessingServiveException =
                new TemplateProcessingServiceException(
                    failedTemplateProcessingServiceException);

            this.templateServiceMock.Setup(service =>
                service.TransformString(inputTemplate.RawTemplate, inputReplacementDictionary))
                    .Throws(serviceException);

            // when
            System.Action TransformTemplateAction = () =>
                this.templateProcessingService.TransformTemplate(inputTemplate, inputReplacementDictionary);

            // then
            TemplateProcessingServiceException actualException =
                Assert.Throws<TemplateProcessingServiceException>(TransformTemplateAction);

            this.templateServiceMock.Verify(service =>
                service.TransformString(inputTemplate.RawTemplate, inputReplacementDictionary),
                    Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTemplateProcessingServiveException))),
                        Times.Once);

            this.templateServiceMock.Verify(service =>
                service.ValidateTransformation(It.IsAny<string>()),
                    Times.Never());

            this.templateServiceMock.Verify(service =>
                service.ConvertStringToTemplate(It.IsAny<string>()),
                    Times.Never());

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
