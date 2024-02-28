// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.Templates.Exceptions
{
    internal class TemplateServiceException : Xeption
    {
        public TemplateServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
