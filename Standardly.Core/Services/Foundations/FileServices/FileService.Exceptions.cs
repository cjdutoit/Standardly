using Standardly.Core.Models.FileServices.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public partial class FileService
    {
        public delegate bool ReturningBooleanFunction();

        public bool TryCatch(ReturningBooleanFunction returningBooleanFunction)
        {
            try
            {
                return returningBooleanFunction();
            }
            catch (InvalidFilePathException invalidFilePathException)
            {
                throw CreateAndLogValidationException(invalidFilePathException);
            }
        }

        private FileServiceValidationException CreateAndLogValidationException(Xeption exception)
        {
            var fileValidationException =
                new FileServiceValidationException(exception);

            return fileValidationException;
        }
    }
}
