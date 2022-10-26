// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Foundations.Templates.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Foundations.Templates
{
    public partial class TemplateService
    {
        private delegate string ReturningStringFunction();
        private delegate void ReturningNothingFunction();
        private delegate Template ReturningTemplateFunction();

        private string TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return returningStringFunction();
            }
            catch (Exception exception)
            {
                var failedTemplateServiceException =
                    new FailedTemplateServiceException(exception.InnerException as Xeption);

                throw CreateAndLogServiceException(failedTemplateServiceException);
            }
        }

        private Template TryCatch(ReturningTemplateFunction returningTemplateFunction)
        {
            try
            {
                return returningTemplateFunction();
            }
            catch (NullTemplateException nullTemplateException)
            {
                throw CreateAndLogValidationException(nullTemplateException);
            }
            catch (InvalidTemplateException invalidCommentException)
            {
                throw CreateAndLogValidationException(invalidCommentException);
            }
            catch (Exception exception)
            {
                var failedTemplateServiceException =
                    new FailedTemplateServiceException(exception.InnerException as Xeption);

                throw CreateAndLogServiceException(failedTemplateServiceException);
            }
        }

        private void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
            }
            catch (InvalidReplacementException invalidCommentException)
            {
                throw CreateAndLogValidationException(invalidCommentException);
            }
            catch (InvalidTemplateSourceException invalidTemplateSourceException)
            {
                throw CreateAndLogValidationException(invalidTemplateSourceException);
            }
            catch (Exception exception)
            {
                var failedTemplateServiceException =
                    new FailedTemplateServiceException(exception.InnerException as Xeption);

                throw CreateAndLogServiceException(failedTemplateServiceException);
            }
        }

        private TemplateValidationException CreateAndLogValidationException(Xeption exception)
        {
            var templateValidationException = new TemplateValidationException(exception);

            return templateValidationException;
        }

        private TemplateServiceException CreateAndLogServiceException(Exception exception)
        {
            var templateOrchestrationServiceException = new TemplateServiceException(exception);

            return templateOrchestrationServiceException;
        }
    }
}
