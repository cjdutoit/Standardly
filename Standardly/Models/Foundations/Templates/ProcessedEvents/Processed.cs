// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Foundations.Templates.ProcessedEvents
{
    public class Processed
    {
        public DateTimeOffset TimeStamp { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int ProcessedItems { get; set; }
        public int TotalItems { get; set; }
    }
}
