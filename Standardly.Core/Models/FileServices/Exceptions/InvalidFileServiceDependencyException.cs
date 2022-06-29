using System;
using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class InvalidFileServiceDependencyException : Xeption
    {
        public InvalidFileServiceDependencyException(Exception innerException)
            : base(message: "Invalid file service error occurred.",
                  innerException)
        { }
    }
}
