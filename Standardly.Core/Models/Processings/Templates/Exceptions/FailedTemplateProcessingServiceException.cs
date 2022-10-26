// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Standardly.Core.Models.Processings.Templates.Exceptions
{
    public class FailedTemplateProcessingServiceException : Xeption
    {
        public FailedTemplateProcessingServiceException(Exception innerException)
            : base(message: "Failed template procesing service occurred, please contact support", innerException)
        { }
    }
}
