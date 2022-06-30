using Xeptions;

namespace Standardly.Core.Models.PowerShellScripts.Exceptions
{
    public class PowerShellServiceException : Xeption
    {
        public PowerShellServiceException(Xeption innerException)
            : base(message: "PowerShell service error occurred, contact support.",
                  innerException)
        { }
    }
}
