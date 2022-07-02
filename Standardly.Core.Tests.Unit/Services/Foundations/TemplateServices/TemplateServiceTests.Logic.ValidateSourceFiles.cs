// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Standardly.Core.Models.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldValidateSourceFiles()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(It.IsAny<string>()))
                    .Returns(true);

            // when
            this.templateService.ValidateSourceFiles(inputTemplate);

            //then
            this.fileSystemBrokerMock.Verify(broker =>
                broker.ReadFile(It.IsAny<string>()),
                    Times.AtLeastOnce);

            this.fileSystemBrokerMock.VerifyNoOtherCalls();
        }
    }
}
