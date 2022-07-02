// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.TemplateOrchestrations.Exceptions
{
    public class TemplateOrchestrationValidationException : Xeption
    {
        public TemplateOrchestrationValidationException(Xeption innerException)
            : base(message: "Template orcgestration validation errors occurred, please try again.",
                  innerException)
        { }
    }
}
