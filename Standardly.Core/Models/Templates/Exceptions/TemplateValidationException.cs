using Xeptions;

namespace Standardly.Core.Models.Templates.Exceptions
{
    public class TemplateValidationException : Xeption
    {
        public TemplateValidationException(Xeption innerException)
            : base(message: "Template validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
