// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Models.Foundations;
using Xunit;

namespace Standardly.Tests.Unit.Services.Foundations
{
    public partial class TemplateServiceTests
    {
        [Fact]
        public void ShouldFindTemplates()
        {
            // given
            dynamic templateProperties = CreateRandomTemplateProperties();
            Core.Models.Foundations.Templates.Template randomTemplate =
                new Core.Models.Foundations.Templates.Template()
                {
                    RawTemplate = templateProperties.RawTemplate,
                    ModelSingularName = templateProperties.ModelSingularName,
                    ModelPluralName = templateProperties.ModelPluralName,
                    Name = templateProperties.Name,
                    Description = templateProperties.Description,
                    TemplateType = templateProperties.TemplateType,
                    SortOrder = templateProperties.SortOrder,
                    ProjectsRequired = templateProperties.ProjectsRequired,
                    Tasks = templateProperties.Tasks,
                    CleanupTasks = templateProperties.CleanupTasks,
                };

            List<Core.Models.Foundations.Templates.Template> returnedTemplates =
                new List<Core.Models.Foundations.Templates.Template> { randomTemplate };

            Models.Foundations.TemplateGenerations.Templates.Template expectedTemplate =
                new Models.Foundations.TemplateGenerations.Templates.Template
                {
                    RawTemplate = templateProperties.RawTemplate,
                    ModelSingularName = templateProperties.ModelSingularName,
                    ModelPluralName = templateProperties.ModelPluralName,
                    Name = templateProperties.Name,
                    Description = templateProperties.Description,
                    TemplateType = templateProperties.TemplateType,
                    SortOrder = templateProperties.SortOrder,
                    ProjectsRequired = templateProperties.ProjectsRequired,
                    Tasks = templateProperties.Tasks,
                    CleanupTasks = templateProperties.CleanupTasks,
                };

            TemplateGeneration expectedTemplates =
                new TemplateGeneration
                {
                    Templates = new List<Standardly.Models.Foundations.TemplateGenerations.Templates.Template>
                    {
                        expectedTemplate
                    },
                    EntityModelDefinition = null,
                    ReplacementDictionary = null,
                    ScriptExecutionIsEnabled = false,
                };

            this.standardlyClientBrokerMock.Setup(broker =>
                broker.FindAllTemplates())
                    .Returns(returnedTemplates);

            // when
            TemplateGeneration actualTemplates =
                this.templateService.FindAllTemplates();

            // then
            actualTemplates.Should().BeEquivalentTo(expectedTemplates);

            this.standardlyClientBrokerMock.Verify(broker =>
                broker.FindAllTemplates(),
                    Times.Once());
        }
    }
}
