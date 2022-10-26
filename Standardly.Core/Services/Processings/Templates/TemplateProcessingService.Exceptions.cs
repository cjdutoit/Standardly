// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Foundations.Templates.Exceptions;
using Standardly.Core.Models.Processings.Templates.Exceptions;
using Standardly.Core.Services.Processings.Templates;
using Xeptions;

namespace Standardly.Core.Services.Foundations.Templates
{
    public partial class TemplateProcessingService : ITemplateProcessingService
    {
        private delegate Template ReturningTemplateFunction();
        private delegate void ReturningNothingFunction();

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
            catch (TemplateValidationException templateValidationException)
            {
                throw CreateAndLogDependencyValidationException(templateValidationException);
            }
            catch (TemplateDependencyValidationException templateDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(templateDependencyValidationException);
            }
            catch (TemplateDependencyException templateDependencyException)
            {
                throw CreateAndLogDependencyException(templateDependencyException);
            }
            catch (TemplateServiceException templateServiceException)
            {
                throw CreateAndLogDependencyException(templateServiceException);
            }
            catch (Exception exception)
            {
                var failedTemplateProcessingServiceException =
                    new FailedTemplateProcessingServiceException(exception);

                throw CreateAndLogServiceException(failedTemplateProcessingServiceException);
            }
        }

        private void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
            }
            catch (NullTemplateProcessingException nullTemplateProcessingException)
            {
                throw CreateAndLogValidationException(nullTemplateProcessingException);
            }
            catch (TemplateValidationException templateValidationException)
            {
                throw CreateAndLogDependencyValidationException(templateValidationException);
            }
            catch (TemplateDependencyValidationException templateDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(templateDependencyValidationException);
            }
            catch (TemplateDependencyException templateDependencyException)
            {
                throw CreateAndLogDependencyException(templateDependencyException);
            }
            catch (TemplateServiceException templateServiceException)
            {
                throw CreateAndLogDependencyException(templateServiceException);
            }
            catch (Exception exception)
            {
                var failedTemplateProcessingServiceException =
                    new FailedTemplateProcessingServiceException(exception);

                throw CreateAndLogServiceException(failedTemplateProcessingServiceException);
            }
        }

        private TemplateProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var templateProcessingValidationException =
                new TemplateProcessingValidationException(exception);

            this.loggingBroker.LogError(templateProcessingValidationException);

            return templateProcessingValidationException;
        }

        private TemplateProcessingDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var templateProcessingDependencyValidationException =
                new TemplateProcessingDependencyValidationException(
                    exception.InnerException as Xeption);

            this.loggingBroker.LogError(templateProcessingDependencyValidationException);

            return templateProcessingDependencyValidationException;
        }

        private TemplateProcessingDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var templateProcessingDependencyException =
                new TemplateProcessingDependencyException(
                    exception.InnerException as Xeption);

            this.loggingBroker.LogError(templateProcessingDependencyException);

            return templateProcessingDependencyException;
        }

        private TemplateProcessingServiceException CreateAndLogServiceException(Xeption exception)
        {
            var countryProcessingServiceException = new
                TemplateProcessingServiceException(exception);

            this.loggingBroker.LogError(countryProcessingServiceException);

            return countryProcessingServiceException;
        }
    }
}
