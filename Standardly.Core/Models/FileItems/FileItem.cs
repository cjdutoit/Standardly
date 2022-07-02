// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Core.Models.FileItems
{
    public class FileItem
    {
        public string Template { get; set; }
        public string Target { get; set; }
        public bool? Replace { get; set; } = false;
    }
}
