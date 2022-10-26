// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
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
        public void ShouldThrowDependencyValidationOnValidateTemplateSourceFilesIfDependencyValidationErrorOccursAndLogItAsync(
            Xeption dependencyValidationException)
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;

            var expectedTemplateProcessingDependencyValidationException =
                new TemplateProcessingDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.templateServiceMock.Setup(service =>
                service.ValidateTemplateSourceFiles(inputTemplate))
                    .Throws(dependencyValidationException);

            // when
            System.Action ValidateTemplateSourceFilesAction = () =>
                this.templateProcessingService.ValidateTemplateSourceFiles(inputTemplate);

            // then
            TemplateProcessingDependencyValidationException actualException =
                Assert.Throws<TemplateProcessingDependencyValidationException>(ValidateTemplateSourceFilesAction);

            this.templateServiceMock.Verify(service =>
                service.ValidateTemplateSourceFiles(inputTemplate),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTemplateProcessingDependencyValidationException))),
                        Times.Once);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyOnValidateTemplateSourceFilesIfDependencyErrorOccursAndLogItAsync(
            Xeption dependencyException)
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;

            var expectedTemplateProcessingDependencyException =
                new TemplateProcessingDependencyException(
                    dependencyException.InnerException as Xeption);

            this.templateServiceMock.Setup(service =>
                service.ValidateTemplateSourceFiles(inputTemplate))
                    .Throws(dependencyException);

            // when
            System.Action ValidateTemplateSourceFilesAction = () =>
                this.templateProcessingService.ValidateTemplateSourceFiles(inputTemplate);

            // then
            TemplateProcessingDependencyException actualException =
                Assert.Throws<TemplateProcessingDependencyException>(ValidateTemplateSourceFilesAction);

            this.templateServiceMock.Verify(service =>
                service.ValidateTemplateSourceFiles(inputTemplate),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTemplateProcessingDependencyException))),
                        Times.Once);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnValidateTemplateSourceFilesIfServiceErrorOccursAndLogItAsync()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;

            var serviceException = new Exception();

            var failedTemplateProcessingServiceException =
                new FailedTemplateProcessingServiceException(serviceException);

            var expectedTemplateProcessingServiveException =
                new TemplateProcessingServiceException(
                    failedTemplateProcessingServiceException);

            this.templateServiceMock.Setup(service =>
                service.ValidateTemplateSourceFiles(inputTemplate))
                    .Throws(serviceException);

            // when
            System.Action ValidateTemplateSourceFilesAction = () =>
                this.templateProcessingService.ValidateTemplateSourceFiles(inputTemplate);

            // then
            TemplateProcessingServiceException actualException =
                Assert.Throws<TemplateProcessingServiceException>(ValidateTemplateSourceFilesAction);

            this.templateServiceMock.Verify(service =>
                service.ValidateTemplateSourceFiles(inputTemplate),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTemplateProcessingServiveException))),
                        Times.Once);

            this.templateServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
