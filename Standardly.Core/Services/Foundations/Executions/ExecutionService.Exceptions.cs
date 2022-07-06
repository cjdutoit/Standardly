// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Standardly.Core.Models.Executions.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Foundations.Executions
{
    public partial class ExecutionService
    {
        public delegate string ReturningStringFunction();

        public string TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return returningStringFunction();
            }
            catch (InvalidExecutionException invalidExecutionException)
            {
                throw CreateAndLogValidationException(invalidExecutionException);
            }
            catch (Exception exception)
            {
                var failedExecutionServiceException =
                    new FailedExecutionServiceException(exception);

                throw CreateAndLogServiceException(failedExecutionServiceException);
            }
        }

        private ExecutionValidationException CreateAndLogValidationException(Xeption exception)
        {
            var executionValidationException =
                new ExecutionValidationException(exception);

            return executionValidationException;
        }

        private ExecutionServiceException CreateAndLogServiceException(Xeption exception)
        {
            var executionServiceException = new ExecutionServiceException(exception);

            return executionServiceException;
        }
    }
}
