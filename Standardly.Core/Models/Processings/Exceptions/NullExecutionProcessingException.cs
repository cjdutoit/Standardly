// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Processings.Exceptions
{
    public class NullExecutionProcessingException : Xeption
    {
        public NullExecutionProcessingException()
            : base(message: "Execution is null.") { }
    }
}
