// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Executions;
using Standardly.Core.Models.Processings.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Executions
{
    public partial class ExecutionProcessingServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnIfExecutionsIsNullAndLogItAsync()
        {
            // given
            List<Execution> nullExecutions = null;
            string executionFolder = GetRandomString();

            var nullExecutionProcessingException =
                new NullExecutionProcessingException();

            var expectedExecutionProcessingValidationException =
                new ExecutionProcessingValidationException(nullExecutionProcessingException);

            // when
            System.Action runAction = () =>
                this.executionProcessingService.Run(nullExecutions, executionFolder);

            ExecutionProcessingValidationException actualException =
                Assert.Throws<ExecutionProcessingValidationException>(runAction);

            // then
            actualException.Should().BeEquivalentTo(expectedExecutionProcessingValidationException);

            this.executionServiceMock.Verify(broker =>
                broker.Run(nullExecutions, executionFolder),
                    Times.Never);

            this.executionServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
