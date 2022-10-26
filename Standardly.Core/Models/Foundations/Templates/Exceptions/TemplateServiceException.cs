// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Standardly.Core.Models.Foundations.Templates.Exceptions
{
    public class TemplateServiceException : Xeption
    {
        public TemplateServiceException(Exception innerException)
            : base(message: "Template service error occurred, contact support.",
                  innerException)
        { }
    }
}
