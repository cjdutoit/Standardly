// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Foundations.Executions.Exceptions
{
    public class ExecutionServiceException : Xeption
    {
        public ExecutionServiceException(Xeption innerException)
            : base(message: "Execution service error occurred, contact support.",
                  innerException)
        { }
    }
}
