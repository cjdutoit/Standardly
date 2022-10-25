// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Processings.Files.Exceptions
{
    public class FileProcessingValidationException : Xeption
    {
        public FileProcessingValidationException(Xeption innerException)
            : base(message: "File processing validation error occurred, please try again.",
                  innerException)
        { }
    }
}
