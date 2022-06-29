using Xeptions;

namespace Standardly.Core.Tests.Unit.Services.Foundations.FileServices
{
    public class FileValidationException : Xeption
    {
        public FileValidationException(Xeption innerException)
            : base(message: "File validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
