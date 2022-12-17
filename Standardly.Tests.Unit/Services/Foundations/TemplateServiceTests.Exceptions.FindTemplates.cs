// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Orchestrations.TemplateRetrievals.Exceptions;
using Xeptions;
using Xunit;


namespace Standardly.Tests.Unit.Services.Foundations
{
    public partial class TemplateServiceTests
    {
        [Theory]
        [MemberData(nameof(TemplateGenerationDependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionIfDependencyValidationErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            string templateFolderPath = GetRandomString();
            string templateDefinitionFile = GetRandomString();
            string somePath = GetRandomString();
            string someContent = GetRandomString();

            var expectedDependencyValidationException =
                new TemplateRetrievalOrchestrationDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.standardlyClientBrokerMock.Setup(broker =>
                broker.FindAllTemplates())
                    .Throws(dependencyValidationException);

            // when
            Action findAllTemplatesAction = () =>
                templateGenerationService.FindAllTemplates();

            TemplateRetrievalOrchestrationDependencyValidationException actualException =
                Assert.Throws<TemplateRetrievalOrchestrationDependencyValidationException>(findAllTemplatesAction);

            // then
            actualException.Should().BeEquivalentTo(expectedDependencyValidationException);

            this.standardlyClientBrokerMock.Verify(broker =>
                broker.FindAllTemplates(),
                    Times.Once);
        }
    }
}
