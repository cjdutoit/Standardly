using System;
using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class FailedFileServiceException : Xeption
    {
        public FailedFileServiceException(Exception innerException)
            : base(message: "Failed file service error occurred, contact support.",
                  innerException)
        { }
    }
}