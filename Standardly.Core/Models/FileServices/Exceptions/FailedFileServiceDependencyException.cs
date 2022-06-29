using System;
using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class FailedFileServiceDependencyException : Xeption
    {
        public FailedFileServiceDependencyException(Exception innerException)
            : base(message: "File service dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
