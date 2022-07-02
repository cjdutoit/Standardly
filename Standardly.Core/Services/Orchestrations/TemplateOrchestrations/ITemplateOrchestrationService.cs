// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Services.Orchestrations.TemplateOrchestrations
{
    public interface ITemplateOrchestrationService
    {
        List<Template> FindAllTemplates();
        bool GenerateCodeFromTemplate(Template template, Dictionary<string, string> replacementDictionary);
    }
}
