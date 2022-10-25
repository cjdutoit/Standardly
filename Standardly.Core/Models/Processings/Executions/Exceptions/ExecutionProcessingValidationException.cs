// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Processings.Executions.Exceptions
{
    public class ExecutionProcessingValidationException : Xeption
    {
        public ExecutionProcessingValidationException(Xeption innerException)
            : base(message: "Execution validation error occurred, please try again.",
                  innerException)
        { }
    }
}
