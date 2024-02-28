// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Foundations.Templates.Tasks.Actions.Appends
{
    public class Append
    {
        public string Target { get; set; }
        public string DoesNotContainContent { get; set; }
        public string RegexToMatchForAppend { get; set; }
        public string ContentToAppend { get; set; }
        public bool AppendToBeginning { get; set; } = false;
        public bool AppendEvenIfContentAlreadyExist { get; set; } = false;
    }
}
