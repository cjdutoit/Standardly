using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class InvalidFilePathException : Xeption
    {
        public InvalidFilePathException()
            : base(message: "Invalid file path, fix the errors and try again.")
        { }
    }
}
