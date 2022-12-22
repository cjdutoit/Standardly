// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;

namespace Standardly.Models.Foundations.TemplateGenerations.Templates.Tasks
{
    public class Task
    {
        public string Name { get; set; }
        public string BranchName { get; set; }
        public List<Actions.Action> Actions { get; set; } = new List<Actions.Action>();
    }
}
