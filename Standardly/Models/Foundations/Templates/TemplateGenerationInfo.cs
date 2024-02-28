// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Models.Foundations.Templates.EntityModels;
using Standardly.Models.Foundations.Templates.ProcessedEvents;

namespace Standardly.Models.Foundations.Templates
{
    internal class TemplateGenerationInfo
    {
        public Processed Processed { get; set; }
        public List<Template> Templates { get; set; } = new List<Template>();
        public Dictionary<string, string> ReplacementDictionary { get; set; } = new Dictionary<string, string>();
        public List<EntityModel> EntityModelDefinition { get; set; } = new List<EntityModel>();
        public bool ScriptExecutionIsEnabled { get; set; } = true;
    }
}
