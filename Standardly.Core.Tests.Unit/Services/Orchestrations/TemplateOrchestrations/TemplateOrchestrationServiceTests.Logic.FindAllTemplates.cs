// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Foundations.Templates;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationServiceTests
    {

        [Fact]
        public void ShouldFindAllTemplates()
        {
            // given
            string[] randomFileList = GetRandomStringArray();
            string[] expectedFileList = randomFileList;
            string randomTemplateString = GetRandomString();
            string inputTemplateString = randomTemplateString;
            string expectedTemplateString = inputTemplateString;
            string rawTemplateString = expectedTemplateString;
            Template randomTemplate = CreateRandomTemplate();
            Template outputTemplate = randomTemplate;


            this.fileServiceMock.Setup(fileService =>
                fileService.RetrieveListOfFiles(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(expectedFileList);

            this.fileServiceMock.Setup(fileService =>
                fileService.ReadFromFile(It.IsAny<string>()))
                    .Returns(expectedTemplateString);

            this.templateServiceMock.Setup(templateService =>
                templateService.ConvertStringToTemplate(rawTemplateString))
                .Returns(outputTemplate);

            // when
            List<Template> actualTemplates = this.templateOrchestrationService.FindAllTemplates();

            // then
            actualTemplates.Count.Should().Be(expectedFileList.Length);

            this.fileServiceMock.Verify(fileService =>
                fileService.RetrieveListOfFiles(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.fileServiceMock.Verify(fileService =>
                fileService.ReadFromFile(It.IsAny<string>()),
                    Times.Exactly(expectedFileList.Length));

            this.templateServiceMock.Verify(templateService =>
                templateService.ConvertStringToTemplate(rawTemplateString),
                    Times.Exactly(expectedFileList.Length));

            this.fileServiceMock.VerifyNoOtherCalls();
            this.executionServiceMock.VerifyNoOtherCalls();
        }
    }
}
