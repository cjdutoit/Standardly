// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Models.Executions.Exceptions;
using Standardly.Core.Models.Processings.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Processings.Executions
{
    public partial class ExecutionProcessingService
    {
        private delegate string ReturningStringFunction();

        private string TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return returningStringFunction();
            }
            catch (NullExecutionProcessingException nullExecutionProcessingException)
            {
                throw CreateAndLogValidationException(nullExecutionProcessingException);
            }
            catch (InvalidPathExecutionProcessingException invalidPathExecutionProcessingException)
            {
                throw CreateAndLogValidationException(invalidPathExecutionProcessingException);
            }
            catch (ExecutionValidationException executionValidationException)
            {
                throw CreateAndLogDependencyValidationException(executionValidationException);
            }
            catch (ExecutionDependencyValidationException executionDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(executionDependencyValidationException);
            }
            catch (ExecutionDependencyException executionDependencyException)
            {
                throw CreateAndLogDependencyException(executionDependencyException);
            }
            catch (ExecutionServiceException executionServiceException)
            {
                throw CreateAndLogDependencyException(executionServiceException);
            }
        }

        private ExecutionProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var executionProcessingValidationException =
                new ExecutionProcessingValidationException(exception);

            this.loggingBroker.LogError(executionProcessingValidationException);

            return executionProcessingValidationException;
        }

        private ExecutionProcessingDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var executionProcessingDependencyValidationException =
                new ExecutionProcessingDependencyValidationException(
                    exception.InnerException as Xeption);

            this.loggingBroker.LogError(executionProcessingDependencyValidationException);

            return executionProcessingDependencyValidationException;
        }

        private ExecutionProcessingDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var executionProcessingDependencyException =
                new ExecutionProcessingDependencyException(
                    exception.InnerException as Xeption);

            this.loggingBroker.LogError(executionProcessingDependencyException);

            return executionProcessingDependencyException;
        }
    }
}
