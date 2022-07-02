// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Moq;
using Standardly.Core.Models.TemplateOrchestrations.Exceptions;
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationServiceTests
    {
        [Theory]
        [MemberData(nameof(TemplateOrchestrationFindAllTemplatesDependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionIfDependencyValidationErrorOccursAndLogIt(
            Exception dependencyValidationException)
        {
            // given
            string somePath = GetRandomString();
            string someContent = GetRandomString();

            var expectedDependencyValidationException =
                new TemplateOrchestrationDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.fileServiceMock.Setup(broker =>
                broker.RetrieveListOfFiles(It.IsAny<string>(), It.IsAny<string>()))
                    .Throws(dependencyValidationException);

            // when
            Action findAllTemplatesAction = () =>
                this.templateOrchestrationService.FindAllTemplates();

            // then
            Assert.Throws<TemplateOrchestrationDependencyValidationException>(findAllTemplatesAction);

            this.fileServiceMock.Verify(broker =>
                broker.RetrieveListOfFiles(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.fileServiceMock.VerifyNoOtherCalls();
            this.powerShellServiceMock.VerifyNoOtherCalls();
            this.templateServiceMock.VerifyNoOtherCalls();
        }
    }
}
