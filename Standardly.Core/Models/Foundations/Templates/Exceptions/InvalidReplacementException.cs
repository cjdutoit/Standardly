// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Foundations.Templates.Exceptions
{
    public class InvalidReplacementException : Xeption
    {
        public InvalidReplacementException()
            : base(message: "Invalid replacement criteria, fix the errors and try again.")
        { }
    }
}
