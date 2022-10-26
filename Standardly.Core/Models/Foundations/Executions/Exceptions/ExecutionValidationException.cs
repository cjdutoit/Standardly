// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Foundations.Executions.Exceptions
{
    public class ExecutionValidationException : Xeption
    {
        public ExecutionValidationException(Xeption innerException)
            : base(message: "Execution validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
