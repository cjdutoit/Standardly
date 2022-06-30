using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class InvalidFileSearchPatternException : Xeption
    {
        public InvalidFileSearchPatternException()
            : base(message: "Invalid file search pattern, fix errors and try again.")
        { }
    }
}
