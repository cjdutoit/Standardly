// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;

namespace Standardly.Core.Models.Tasks
{
    public class Task
    {
        public string Name { get; set; }
        public List<Models.Actions.Action> Actions { get; set; } = new List<Models.Actions.Action>();
    }
}
