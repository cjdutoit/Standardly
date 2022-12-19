// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Standardly.Models.Foundations.TemplateGenerations.Exceptions;
using Xeptions;
using Xunit;


namespace Standardly.Tests.Unit.Services.Foundations
{
    public partial class TemplateServiceTests
    {
        [Theory]
        [MemberData(nameof(TemplateGenerationDependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationOnFindAllTemplatesIfExceptionIfDependencyValidationErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            var invalidTemplateGenerationException =
                new InvalidClientValidationException(dependencyValidationException as Xeption);

            var expectedTemplateGenerationDependencyValidationException =
                new TemplateGenerationDependencyValidationException(
                    invalidTemplateGenerationException);

            this.standardlyClientBrokerMock.Setup(broker =>
                broker.FindAllTemplates())
                    .Throws(dependencyValidationException);

            // when
            Action findAllTemplatesAction = () =>
                templateGenerationService.FindAllTemplates();

            TemplateGenerationDependencyValidationException actualException =
                Assert.Throws<TemplateGenerationDependencyValidationException>(findAllTemplatesAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateGenerationDependencyValidationException);

            this.standardlyClientBrokerMock.Verify(broker =>
                broker.FindAllTemplates(),
                    Times.Once);
        }

        [Theory]
        [MemberData(nameof(TemplateGenerationDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnFindAllTemplatesIfDependencyErrorOccursAndLogIt(
            Exception dependencyException)
        {
            // given
            var failedClientException =
                new FailedClientException(dependencyException as Xeption);

            var expectedTemplateGenerationDependencyException =
                new TemplateGenerationDependencyException(
                    dependencyException.InnerException as Xeption);

            this.standardlyClientBrokerMock.Setup(broker =>
                broker.FindAllTemplates())
                    .Throws(dependencyException);

            // when
            Action findAllTemplatesAction = () =>
                this.templateGenerationService
                    .FindAllTemplates();

            TemplateGenerationDependencyException actualException =
                Assert.Throws<TemplateGenerationDependencyException>(findAllTemplatesAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateGenerationDependencyException);

            this.standardlyClientBrokerMock.Verify(broker =>
                broker.FindAllTemplates(),
                    Times.Once);
        }
    }
}
