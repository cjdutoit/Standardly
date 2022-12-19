// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.TemplateGenerations.Exceptions
{
    public class FailedTemplateGenerationServiceException : Xeption
    {
        public FailedTemplateGenerationServiceException(Exception innerException)
            : base(message: "Failed template generation service occurred, please contact support", innerException)
        { }
    }
}
