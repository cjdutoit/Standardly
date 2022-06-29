using System;
using System.IO;
using System.Runtime.Serialization;
using Standardly.Core.Models.FileServices.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public partial class FileService
    {
        public delegate bool ReturningBooleanFunction();
        public delegate void ReturningNothingFunction();

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
            catch (SerializationException serializationException)
            {
                var failedFileDependencyException =
                    new FailedFileServiceDependencyException(serializationException);

                throw CreateAndLogDependecyException(failedFileDependencyException);
            }
            catch (OutOfMemoryException outOfMemoryException)
            {
                var failedFileDependencyException =
                    new FailedFileServiceDependencyException(outOfMemoryException);

                throw CreateAndLogCriticalDependencyException(failedFileDependencyException);
            }
            catch (IOException ioException)
            {
                var failedFileDependencyException =
                    new FailedFileServiceDependencyException(ioException);

                throw CreateAndLogDependecyException(failedFileDependencyException);
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                var failedFileDependencyException =
                    new FailedFileServiceDependencyException(unauthorizedAccessException);

                throw CreateAndLogCriticalDependencyException(failedFileDependencyException);
            }
            catch (Exception exception)
            {
                var failedFileServiceException =
                    new FailedFileServiceException(exception);

                throw CreateAndLogServiceException(failedFileServiceException);
            }
        }

        public void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
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

        private FileServiceDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var fileServiceDependencyValidationException =
                new FileServiceDependencyValidationException(exception);

            return fileServiceDependencyValidationException;
        }

        private FileServiceDependencyException CreateAndLogDependecyException(Xeption exception)
        {
            var fileServiceDependencyException = new FileServiceDependencyException(exception);

            return fileServiceDependencyException;
        }

        private FileServiceDependencyException CreateAndLogCriticalDependencyException(
            Xeption exception)
        {
            var fileServiceDependencyException = new FileServiceDependencyException(exception);

            return fileServiceDependencyException;
        }

        private FileServiceException CreateAndLogServiceException(
            Xeption exception)
        {
            var fileServiceException = new FileServiceException(exception);

            return fileServiceException;
        }
    }
}
