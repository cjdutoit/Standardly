﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.Templates.Exceptions
{
    public class FailedTemplateServiceException : Xeption
    {
        public FailedTemplateServiceException(Exception innerException)
            : base(message: "Failed template service error occurred, contact support.",
                  innerException)
        { }
    }
}
