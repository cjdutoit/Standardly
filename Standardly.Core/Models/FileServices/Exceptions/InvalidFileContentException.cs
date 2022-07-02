// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class InvalidFileContentException : Xeption
    {
        public InvalidFileContentException()
            : base(message: "Invalid file content, fix errors and try again.")
        { }
    }
}
