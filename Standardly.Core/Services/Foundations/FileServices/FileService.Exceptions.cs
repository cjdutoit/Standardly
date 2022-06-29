using System;
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
            catch (ArgumentNullException argumentNullException)
            {
                var invalidFileDependencyException =
                    new InvalidFileServiceDependencyException(argumentNullException);

                throw CreateAndLogDependencyValidationException(invalidFileDependencyException);
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                var invalidFileDependencyException =
                    new InvalidFileServiceDependencyException(argumentOutOfRangeException);

                throw CreateAndLogDependencyValidationException(invalidFileDependencyException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidFileDependencyException =
                    new InvalidFileServiceDependencyException(argumentException);

                throw CreateAndLogDependencyValidationException(invalidFileDependencyException);
            }
        }

        private FileServiceValidationException CreateAndLogValidationException(Xeption exception)
        {
            var fileValidationException =
                new FileServiceValidationException(exception);

            return fileValidationException;
        }

        private FileServiceDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var fileServiceDependencyValidationException =
                new FileServiceDependencyValidationException(exception);

            return fileServiceDependencyValidationException;
        }
    }
}
