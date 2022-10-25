// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Processings.Files.Exceptions
{
    public class FileProcessingDependencyException : Xeption
    {
        public FileProcessingDependencyException(Xeption innerException)
            : base(message: "File dependency error occurred, please contact support.", innerException)
        { }
    }
}
