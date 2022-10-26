// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Foundations.FileItems;
using Standardly.Core.Models.Foundations.Tasks;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Foundations.Templates.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.TemplateServices
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldThrowValidateExceptionIfSourceFilesNotFound()
        {
            // given
            Template randomTemplate = CreateRandomTemplate();
            Template inputTemplate = randomTemplate;

            var invalidTemplateSourceException = new InvalidTemplateSourceException();

            for (int taskCounter = 0; taskCounter <= inputTemplate.Tasks.Count - 1; taskCounter++)
            {
                Task task = inputTemplate.Tasks[taskCounter];

                for (int actionCounter = 0; actionCounter <= task.Actions.Count - 1; actionCounter++)
                {
                    Models.Foundations.Actions.Action action = task.Actions[actionCounter];

                    foreach (FileItem fileItem in action.FileItems)
                    {
                        var fileInfo = new FileInfo(fileItem.Template);

                        invalidTemplateSourceException.AddData(
                            key: fileInfo.Name,
                            values: $"File not found for " +
                                $"Template[{inputTemplate.Name}]." +
                                $"Task[{task.Name ?? taskCounter.ToString()}]." +
                                $"Action[{action.Name ?? actionCounter.ToString()}]." +
                                $"Path: {fileItem.Template}");
                    }
                }
            }

            this.fileSystemBrokerMock.Setup(broker =>
                broker.CheckIfFileExists(It.IsAny<string>()))
                    .Returns(false);

            var expectedTemplateValidationException =
                new TemplateValidationException(invalidTemplateSourceException);

            // when
            System.Action transformRawTemplateItemAction = () =>
                this.templateService.ValidateSourceFiles(inputTemplate);

            TemplateValidationException actualException = Assert.Throws<TemplateValidationException>(
                transformRawTemplateItemAction);

            // then
            actualException.Should().BeEquivalentTo(expectedTemplateValidationException);
        }
    }
}
