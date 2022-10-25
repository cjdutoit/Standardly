// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Standardly.Core.Services.Processings.Executions
{
    public class FailedExecutionProcessingServiceException : Xeption
    {
        public FailedExecutionProcessingServiceException(Exception innerException)
            : base(message: "Failed execution service occurred, please contact support", innerException)
        { }
    }
}
