// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class InvalidFilePathException : Xeption
    {
        public InvalidFilePathException()
            : base(message: "Invalid file path, fix the errors and try again.")
        { }
    }
}
