// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.IO;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.FileItems;
using Standardly.Core.Models.Templates;
using Standardly.Core.Models.Templates.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldThrowValidateExceptionIfSourceFilesnotFound()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;

            var invalidTemplateSourceException = new InvalidTemplateSourceException();

            for (int taskCounter = 0; taskCounter <= inputTemplate.Tasks.Count - 1; taskCounter++)
            {
                Models.Tasks.Task task = inputTemplate.Tasks[taskCounter];

                for (int actionCounter = 0; actionCounter <= task.Actions.Count - 1; actionCounter++)
                {
                    Models.Actions.Action action = task.Actions[actionCounter];

                    foreach (FileItem fileItem in action.FileItems)
                    {
                        var fileInfo = new FileInfo(fileItem.Template);

                        invalidTemplateSourceException.AddData(
                            key: fileInfo.Name,
                            values: $"File not found:  {fileItem.Template}");
                    }
                }
            }

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(It.IsAny<string>()))
                    .Returns(false);

            var expectedTemplateValidationException =
                new TemplateValidationException(invalidTemplateSourceException);

            // when
            Action transformRawTemplateItemAction = () =>
                this.templateService.ValidateSourceFiles(inputTemplate);

            TemplateValidationException actualException = Assert.Throws<TemplateValidationException>(
                transformRawTemplateItemAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateValidationException);
        }
    }
}
