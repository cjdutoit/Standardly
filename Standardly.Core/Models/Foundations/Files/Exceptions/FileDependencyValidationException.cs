// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Foundations.Files.Exceptions
{
    public class FileDependencyValidationException : Xeption
    {
        public FileDependencyValidationException(Xeption innerException)
            : base(message: "File service dependency validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
