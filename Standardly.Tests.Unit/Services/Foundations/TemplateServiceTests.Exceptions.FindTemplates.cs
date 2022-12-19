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
        public void ShouldThrowDependencyValidationExceptionIfDependencyValidationErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            string templateFolderPath = GetRandomString();
            string templateDefinitionFile = GetRandomString();
            string somePath = GetRandomString();
            string someContent = GetRandomString();

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
    }
}
