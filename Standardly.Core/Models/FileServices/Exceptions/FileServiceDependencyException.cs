// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class FileServiceDependencyException : Xeption
    {
        public FileServiceDependencyException(Xeption innerException)
            : base(message: "File dependency error occurred, contact support.",
                  innerException)
        { }

        public FileServiceDependencyException(string message, Xeption innerException)
            : base(message: $"File dependency error occurred, contact support. {message}",
                  innerException)
        { }
    }
}
