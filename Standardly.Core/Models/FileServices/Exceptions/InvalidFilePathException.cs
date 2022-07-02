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
        public InvalidFilePathException(string path)
            : base(message: $"Invalid file path: '{path}', fix the errors and try again.")
        { }
    }
}
