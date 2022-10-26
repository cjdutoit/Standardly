// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Standardly.Core.Models.Orchestrations.TemplateOrchestrations.Exceptions
{
    public class FailedTemplateOrchestrationServiceException : Xeption
    {
        public FailedTemplateOrchestrationServiceException(Exception innerException)
            : base(message: "Failed template orchestration service occurred, please contact support", innerException)
        { }
    }
}
