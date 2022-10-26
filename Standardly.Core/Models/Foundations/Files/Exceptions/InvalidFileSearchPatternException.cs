// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Foundations.Files.Exceptions
{
    public class InvalidFileSearchPatternException : Xeption
    {
        public InvalidFileSearchPatternException()
            : base(message: "Invalid file search pattern, fix errors and try again.")
        { }
    }
}
