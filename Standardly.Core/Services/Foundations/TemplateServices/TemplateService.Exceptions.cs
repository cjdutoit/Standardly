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
