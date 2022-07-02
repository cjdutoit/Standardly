// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.TemplateOrchestrations.Exceptions
{
    public class NullTemplateOrchestrationException : Xeption
    {
        public NullTemplateOrchestrationException()
            : base(message: "Template is null.")
        { }
    }
}
