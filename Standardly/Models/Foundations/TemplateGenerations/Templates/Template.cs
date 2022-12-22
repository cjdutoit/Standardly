// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;

namespace Standardly.Models.Foundations.TemplateGenerations.Templates
{
    public class Template
    {
        public string RawTemplate { get; set; }
        public string ModelSingularName { get; set; }
        public string ModelPluralName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateType { get; set; }
        public int SortOrder { get; set; }
        public string ProjectsRequired { get; set; }
        public List<Tasks.Task> Tasks { get; set; } = new List<Tasks.Task>();
        public List<string> CleanupTasks { get; set; } = new List<string>();
    }
}
