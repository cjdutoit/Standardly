using System;
using Xeptions;

namespace Standardly.Core.Models.PowerShellScripts.Exceptions
{
    public class FailedPowerShellServiceException : Xeption
    {
        public FailedPowerShellServiceException(Exception innerException)
            : base(message: "Failed powershell service error occurred, contact support.",
                  innerException)
        { }
    }
}
