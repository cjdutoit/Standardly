using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class FileServiceException : Xeption
    {
        public FileServiceException(Xeption innerException)
            : base(message: "File service error occurred, contact support.",
                  innerException)
        { }
    }
}
