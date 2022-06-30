using Xeptions;

namespace Standardly.Core.Models.Templates.Exceptions
{
    public class InvalidTemplateException : Xeption
    {
        public InvalidTemplateException()
            : base(message: "Invalid template criteria, fix the errors and try again.")
        { }
    }
}
