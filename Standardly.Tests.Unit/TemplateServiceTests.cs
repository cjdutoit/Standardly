// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Standardly.Brokers;
using Standardly.Services.Foundations.Templates;

namespace Standardly.Tests.Unit
{
    public partial class TemplateServiceTests
    {
        private readonly Mock<ICodeGenerationBroker> codeGenerationBroker;
        private readonly ITemplateService templateService;

        public TemplateServiceTests()
        {
            codeGenerationBroker = new Mock<ICodeGenerationBroker>();
            templateService = new TemplateService(codeGenerationBroker.Object);
        }
    }
}
