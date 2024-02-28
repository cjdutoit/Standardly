// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Action = Standardly.Models.Foundations.Templates.Tasks.Actions.Action;

namespace Standardly.Models.Foundations.Templates.Tasks
{
    public class Task
    {
        public string Name { get; set; }
        public string BranchName { get; set; }
        public List<Action> Actions { get; set; } = new List<Action>();
    }
}
