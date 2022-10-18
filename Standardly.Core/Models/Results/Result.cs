// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace Standardly.Core.Models.Results
{
    public class Result
    {
        public DateTimeOffset Timestamp { get; set; }
        public string Message { get; set; }
    }
}
