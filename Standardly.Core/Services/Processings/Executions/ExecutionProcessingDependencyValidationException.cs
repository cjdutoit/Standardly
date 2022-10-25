// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Services.Processings.Executions
{
    public class ExecutionProcessingDependencyValidationException : Xeption
    {
        public ExecutionProcessingDependencyValidationException(Xeption innerException)
            : base(message: "Execution dependency validation error occurred, please try again.",
                  innerException)
        { }
    }
}
