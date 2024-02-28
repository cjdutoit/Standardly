// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Foundations.Templates.Tasks.Actions.Files
{
    public class File
    {
        public string Template { get; set; }
        public string Target { get; set; }
        public bool? Replace { get; set; } = false;
    }
}
