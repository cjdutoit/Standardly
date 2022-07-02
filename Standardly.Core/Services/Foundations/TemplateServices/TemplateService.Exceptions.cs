// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Models.Templates.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService
    {
        private delegate Models.Templates.Template ReturningTemplateFunction();

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
        }

        private TemplateValidationException CreateAndLogValidationException(Xeption exception)
        {
            var templateValidationException = new TemplateValidationException(exception);

            return templateValidationException;
        }
    }
}
