// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class FileServiceDependencyValidationException : Xeption
    {
        public FileServiceDependencyValidationException(Xeption innerException)
            : base(message: "File service dependency validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
