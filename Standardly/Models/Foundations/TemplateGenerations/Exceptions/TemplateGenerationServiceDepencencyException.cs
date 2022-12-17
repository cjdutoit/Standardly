// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.TemplateGenerations.Exceptions
{
    public class TemplateGenerationServiceDepencencyException : Xeption
    {
        public TemplateGenerationServiceDepencencyException(Xeption innerException)
            : base(message: "Template generation service dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
