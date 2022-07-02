// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Templates.Exceptions
{
    public class TemplateDependencyValidationException : Xeption
    {
        public TemplateDependencyValidationException(Xeption innerException)
            : base(message: "Template dependency validation occurred, please try again.", innerException)
        { }
    }
}
