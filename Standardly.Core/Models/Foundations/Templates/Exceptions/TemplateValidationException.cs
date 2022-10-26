// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Foundations.Templates.Exceptions
{
    public class TemplateValidationException : Xeption
    {
        public TemplateValidationException(Xeption innerException)
            : base(message: "Template validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
