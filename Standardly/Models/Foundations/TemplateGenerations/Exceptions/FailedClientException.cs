// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.TemplateGenerations.Exceptions
{
    public class FailedClientException : Xeption
    {
        public FailedClientException(Exception innerException)
            : base(
                  message: "Failed client error occurred, please contact support",
                  innerException)
        { }
    }
}
