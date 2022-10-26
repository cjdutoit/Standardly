// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Foundations.Executions;
using Standardly.Core.Models.Foundations.Executions.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.Executions
{
    public partial class ExecutionServiceTests
    {
        [Fact]
        public void ShoudThrowServiceExceptionOnRunIfServiceErrorOccurs()
        {
            // given
            string somePath = GetRandomString();
            string someKey = GetRandomString();
            string someValue = GetRandomString();

            List<Execution> someExecutions =
                new List<Execution>();

            someExecutions.Add(new Execution() { Name = someKey, Instruction = someValue });
            var serviceException = new Exception();

            var failedExecutionServiceException =
                new FailedExecutionServiceException(serviceException);

            var expectedExecutionServiceException =
                new ExecutionServiceException(failedExecutionServiceException);

            this.executionBrokerMock.Setup(broker =>
                broker.Run(someExecutions, somePath))
                    .Throws(serviceException);

            // when
            Action writeToFileAction = () =>
                this.executionService.Run(someExecutions, somePath);

            ExecutionServiceException actualException = Assert
                .Throws<ExecutionServiceException>(writeToFileAction);

            // then
            actualException.Should().BeEquivalentTo(expectedExecutionServiceException);

            this.executionBrokerMock.Verify(broker =>
                broker.Run(someExecutions, somePath),
                    Times.Once);

            this.executionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
