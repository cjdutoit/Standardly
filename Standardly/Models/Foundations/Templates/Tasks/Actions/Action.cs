// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Append = Standardly.Models.Foundations.Templates.Tasks.Actions.Appends.Append;
using Execution = Standardly.Models.Foundations.Templates.Tasks.Actions.Executions.Execution;
using File = Standardly.Models.Foundations.Templates.Tasks.Actions.Files.File;

namespace Standardly.Models.Foundations.Templates.Tasks.Actions
{
    public class Action
    {
        public string Name { get; set; }
        public string ExecutionFolder { get; set; }
        public List<File> Files { get; set; } = new List<File>();
        public List<Append> Appends { get; set; } = new List<Append>();
        public List<Execution> Executions { get; set; } = new List<Execution>();
    }
}
