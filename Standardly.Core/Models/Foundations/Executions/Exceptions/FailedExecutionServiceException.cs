// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Standardly.Core.Models.Foundations.Executions.Exceptions
{
    public class FailedExecutionServiceException : Xeption
    {
        public FailedExecutionServiceException(Exception innerException)
            : base(message: "Failed execution service error occurred, contact support.",
                  innerException)
        { }
    }
}
