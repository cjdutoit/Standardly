using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class InvalidFileContentException : Xeption
    {
        public InvalidFileContentException()
            : base(message: "Invalid file content, fix errors and try again.")
        { }
    }
}
