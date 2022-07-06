// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Executions.Exceptions
{
    public class InvalidExecutionException : Xeption
    {
        public InvalidExecutionException()
            : base(message: "Invalid execution criteria, fix the errors and try again.")
        { }
    }
}
