using Xeptions;

namespace Standardly.Core.Models.Templates.Exceptions
{
    public class NullTemplateException : Xeption
    {
        public NullTemplateException()
            : base(message: "Template is null.")
        { }
    }
}
