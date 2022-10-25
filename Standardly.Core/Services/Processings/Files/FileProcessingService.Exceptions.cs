// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Models.FileServices.Exceptions;
using Standardly.Core.Models.Processings.Files.Exceptions;
using Standardly.Core.Services.Processings.Files;
using Xeptions;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public partial class FileProcessingService : IFileProcessingService
    {
        private delegate bool ReturningBooleanFunction();

        private bool TryCatch(ReturningBooleanFunction returningBooleanFunction)
        {
            try
            {
                return returningBooleanFunction();
            }
            catch (InvalidFileProcessingException invalidPathFileProcessingException)
            {
                throw CreateAndLogValidationException(invalidPathFileProcessingException);
            }
            catch (FileValidationException fileValidationException)
            {
                throw CreateAndLogDependencyValidationException(fileValidationException);
            }
            catch (FileDependencyValidationException fileDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(fileDependencyValidationException);
            }
            catch (FileDependencyException fileDependencyException)
            {
                throw CreateAndLogDependencyException(fileDependencyException);
            }
            catch (FileServiceException fileServiceException)
            {
                throw CreateAndLogDependencyException(fileServiceException);
            }
        }

        private FileProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var fileProcessingValidationException =
                new FileProcessingValidationException(exception);

            this.loggingBroker.LogError(fileProcessingValidationException);

            return fileProcessingValidationException;
        }

        private FileProcessingDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var fileProcessingDependencyValidationException =
                new FileProcessingDependencyValidationException(
                    exception.InnerException as Xeption);

            this.loggingBroker.LogError(fileProcessingDependencyValidationException);

            return fileProcessingDependencyValidationException;
        }

        private FileProcessingDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var fileProcessingDependencyException =
                new FileProcessingDependencyException(
                    exception.InnerException as Xeption);

            this.loggingBroker.LogError(fileProcessingDependencyException);

            return fileProcessingDependencyException;
        }
    }
}
