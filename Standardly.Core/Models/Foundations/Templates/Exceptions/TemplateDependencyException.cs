// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Foundations.Templates.Exceptions
{
    public class TemplateDependencyException : Xeption
    {
        public TemplateDependencyException(Xeption innerException) :
            base(message: "Template dependency error occurred, contact support.", innerException)
        { }
    }
}
