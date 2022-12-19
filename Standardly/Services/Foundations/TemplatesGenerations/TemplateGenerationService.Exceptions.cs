// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Models.Clients.Exceptions;
using Standardly.Models.Foundations;
using Standardly.Models.Foundations.TemplateGenerations.Exceptions;
using Xeptions;

namespace Standardly.Services.Foundations
{
    public partial class TemplateGenerationService : ITemplateGenerationService
    {
        private delegate TemplateGeneration ReturningTemplateGenerationFunction();

        private TemplateGeneration TryCatch(ReturningTemplateGenerationFunction returningTemplateGenerationFunction)
        {
            try
            {
                return returningTemplateGenerationFunction();
            }
            catch (StandardlyClientValidationException standardlyClientValidationException)
            {
                var invalidTemplateGenerationException =
                    new InvalidClientValidationException(
                        standardlyClientValidationException,
                        standardlyClientValidationException.Data);

                throw CreateAndLogDependencyValidationException(invalidTemplateGenerationException);
            }
        }

        private TemplateGenerationDependencyValidationException CreateAndLogDependencyValidationException(
            Xeption exception)
        {
            var templateGenerationDependencyValidationException =
                new TemplateGenerationDependencyValidationException(exception);

            return templateGenerationDependencyValidationException;
        }
    }
}
