using Xeptions;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public class FileServiceValidationException : Xeption
    {
        public FileServiceValidationException(Xeption innerException)
            : base(message: "File validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
