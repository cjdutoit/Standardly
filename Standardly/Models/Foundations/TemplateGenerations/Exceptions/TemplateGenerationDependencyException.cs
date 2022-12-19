// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.TemplateGenerations.Exceptions
{
    public class TemplateGenerationDependencyException : Xeption
    {
        public TemplateGenerationDependencyException(Xeption innerException)
            : base(
                  message: "Template generation dependency error occurred, please try again.",
                  innerException)
        { }
    }
}
