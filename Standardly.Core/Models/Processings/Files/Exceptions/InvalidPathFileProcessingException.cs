// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Processings.Files.Exceptions
{
    public class InvalidFileProcessingException : Xeption
    {
        public InvalidFileProcessingException()
            : base(message: "Invalid file path, Please correct the errors and try again.")
        { }
    }
}
