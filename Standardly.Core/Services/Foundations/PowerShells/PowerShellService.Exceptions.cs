using Standardly.Core.Models.PowerShellScripts.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Foundations.PowerShells
{
    public partial class PowerShellService
    {
        public delegate string ReturningStringFunction();

        public string TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return returningStringFunction();
            }
            catch (InvalidPowerShellException invalidPowerShellException)
            {
                throw CreateAndLogValidationException(invalidPowerShellException);
            }
        }

        private PowerShellValidationException CreateAndLogValidationException(Xeption exception)
        {
            var powerShellValidationException =
                new PowerShellValidationException(exception);

            return powerShellValidationException;
        }
    }
}
