// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Standardly.Core.Models.Templates.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService
    {
        private delegate string ReturningStringFunction();
        private delegate void ReturningNothingFunction();
        private delegate Models.Templates.Template ReturningTemplateFunction();

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

        private Models.Templates.Template TryCatch(ReturningTemplateFunction returningTemplateFunction)
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
