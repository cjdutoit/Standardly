// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using Standardly.Core.Models.Clients.Exceptions;
using Standardly.Models.Foundations.Templates.Exceptions;

namespace Standardly.Services.Foundations.Templates
{
    internal partial class TemplateService : ITemplateService
    {
        private delegate void ReturningNothingFunction();
        private delegate ValueTask ReturningValueTaskFunction();

        private void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
            }
            catch (StandardlyClientValidationException standardlyClientValidationException)
            {
                throw new TemplateValidationException(
                    message: "Template validation error occurred, fix the errors and try again.",
                    innerException: standardlyClientValidationException);
            }
            catch (StandardlyClientDependencyException standardlyClientDependencyException)
            {
                throw new TemplateDependencyException(
                    message: "Template dependency error occurred, contact support.",
                    innerException: standardlyClientDependencyException);
            }
            catch (StandardlyClientServiceException standardlyClientServiceException)
            {
                throw new TemplateDependencyException(
                    message: "Template dependency error occurred, contact support.",
                    innerException: standardlyClientServiceException);
            }
            catch (Exception exception)
            {
                throw new TemplateServiceException(
                    message: "Template service error occurred, contact support.",
                    innerException: exception);
            }
        }

        private async ValueTask TryCatch(ReturningValueTaskFunction returningValueTaskFunction)
        {
            try
            {
                await returningValueTaskFunction();
            }
            catch (StandardlyClientValidationException standardlyClientValidationException)
            {
                throw new TemplateValidationException(
                    message: "Template validation error occurred, fix the errors and try again.",
                    innerException: standardlyClientValidationException);
            }
            catch (StandardlyClientDependencyException standardlyClientDependencyException)
            {
                throw new TemplateDependencyException(
                    message: "Template dependency error occurred, contact support.",
                    innerException: standardlyClientDependencyException);
            }
            catch (StandardlyClientServiceException standardlyClientServiceException)
            {
                throw new TemplateDependencyException(
                    message: "Template dependency error occurred, contact support.",
                    innerException: standardlyClientServiceException);
            }
            catch (Exception exception)
            {
                throw new TemplateServiceException(
                    message: "Template service error occurred, contact support.",
                    innerException: exception);
            }
        }
    }
}
