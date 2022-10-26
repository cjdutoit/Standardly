// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Orchestrations.TemplateOrchestrations.Exceptions
{
    public class TemplateOrchestrationDependencyValidationException : Xeption
    {
        public TemplateOrchestrationDependencyValidationException(Xeption innerException)
            : base(message: "Template orchestration dependency validation occurred, please try again.", innerException)
        { }
    }
}
