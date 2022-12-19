// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using Xeptions;

namespace Standardly.Models.Foundations.TemplateGenerations.Exceptions
{
    public class InvalidClientValidationException : Xeption
    {
        public InvalidClientValidationException(Xeption innerException)
            : base(
                  message: "Invalid client validation error occurred, please try again.",
                  innerException)
        { }

        public InvalidClientValidationException(Xeption innerException, IDictionary data)
            : base(
                  message: "Invalid client validation error occurred, please try again.",
                  innerException,
                  data)
        { }
    }
}
