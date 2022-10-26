// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Processings.Templates.Exceptions
{
    public class TemplateProcessingDependencyValidationException : Xeption
    {
        public TemplateProcessingDependencyValidationException(Xeption innerException)
            : base(message: "Template processing dependency validation error occurred, please try again.",
                  innerException)
        { }
    }
}
