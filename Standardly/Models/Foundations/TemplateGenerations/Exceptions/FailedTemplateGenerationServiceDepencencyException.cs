// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Models.Foundations.TemplateGenerations.Exceptions
{
    public class FailedTemplateGenerationServiceDepencencyException : Xeption
    {
        public FailedTemplateGenerationServiceDepencencyException(Exception innerException)
            : base(
                  message: "Failed template generation service depencency error occurred, please contact support",
                  innerException)
        { }
    }
}
