// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Processings.Templates.Exceptions;
using Standardly.Core.Services.Processings.Templates;
using Xeptions;

namespace Standardly.Core.Services.Foundations.Templates
{
    public partial class TemplateProcessingService : ITemplateProcessingService
    {
        private delegate Template ReturningTemplateFunction();

        private Template TryCatch(ReturningTemplateFunction returningTemplateFunction)
        {
            try
            {
                return returningTemplateFunction();
            }
            catch (InvalidArgumentTemplateProcessingException invalidContentTemplateProcessingException)
            {
                throw CreateAndLogValidationException(invalidContentTemplateProcessingException);
            }
        }

        private TemplateProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var templateProcessingValidationException =
                new TemplateProcessingValidationException(exception);

            this.loggingBroker.LogError(templateProcessingValidationException);

            return templateProcessingValidationException;
        }
    }
}
