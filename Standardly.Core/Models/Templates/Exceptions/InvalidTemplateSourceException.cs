// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Templates.Exceptions
{
    public class InvalidTemplateSourceException : Xeption
    {
        public InvalidTemplateSourceException()
            : base(message: "Invalid template source path, fix the errors and try again.")
        { }
    }
}
