// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Settings
{
    public class Setting
    {
        public General General { get; set; }
        public Location Location { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
    }
}
