// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Models.Foundations.TemplateGenerations.EntityModels;
using Standardly.Models.Foundations.TemplateGenerations.Templates;

namespace Standardly.Models.Foundations
{
    public class TemplateGeneration
    {
        public List<Template> Templates { get; set; }
        public Dictionary<string, string> ReplacementDictionary { get; set; }
        public List<EntityModel> EntityModelDefinition { get; set; }
        public bool ScriptExecutionIsEnabled { get; set; } = true;
    }
}
