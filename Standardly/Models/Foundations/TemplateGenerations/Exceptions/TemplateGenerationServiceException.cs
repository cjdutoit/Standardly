// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.TemplateGenerations.Exceptions
{
    public class TemplateGenerationServiceException : Xeption
    {
        public TemplateGenerationServiceException(Exception innerException)
            : base(message: "Template orchestration service error occurred, contact support.", innerException)
        { }
    }
}
