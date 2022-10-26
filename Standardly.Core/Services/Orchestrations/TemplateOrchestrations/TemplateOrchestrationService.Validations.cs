// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Orchestrations.TemplateOrchestrations.Exceptions;

namespace Standardly.Core.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationService
    {
        private static void ValidateTemplateIsNotNull(Template template)
        {
            if (template is null)
            {
                throw new NullTemplateOrchestrationException();
            }
        }
    }
}
