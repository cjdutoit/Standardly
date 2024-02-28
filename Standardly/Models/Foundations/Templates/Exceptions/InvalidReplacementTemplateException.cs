// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.Templates.Exceptions
{
    public class InvalidReplacementTemplateException : Xeption
    {
        public InvalidReplacementTemplateException()
            : base(message: "Invalid replacement criteria, fix the errors and try again.")
        { }
    }
}
