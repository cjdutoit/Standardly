using Xeptions;

namespace Standardly.Core.Models.PowerShellScripts.Exceptions
{
    public class InvalidPowerShellException : Xeption
    {
        public InvalidPowerShellException()
            : base(message: "Invalid powershell criteria, fix the errors and try again.")
        { }
    }
}
