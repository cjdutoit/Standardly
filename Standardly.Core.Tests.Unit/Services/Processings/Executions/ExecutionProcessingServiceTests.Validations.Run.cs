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

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExecutionProcessingValidationException))),
                        Times.Once);

            this.executionServiceMock.Verify(broker =>
                broker.Run(nullExecutions, executionFolder),
                    Times.Never);

            this.executionServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnIfExecutionFolderIsInvalidAndLogItAsync(
            string invalidExecutionFolder)
        {
            // given
            List<Execution> randomExecutions = CreateRandomExecutions();
            string inputExecutionFolder = invalidExecutionFolder;

            var invalidPathExecutionProcessingException =
                new InvalidPathExecutionProcessingException();

            var expectedExecutionProcessingValidationException =
                new ExecutionProcessingValidationException(invalidPathExecutionProcessingException);

            // when
            System.Action runAction = () =>
                this.executionProcessingService.Run(randomExecutions, inputExecutionFolder);

            ExecutionProcessingValidationException actualException =
                Assert.Throws<ExecutionProcessingValidationException>(runAction);

            // then
            actualException.Should().BeEquivalentTo(expectedExecutionProcessingValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExecutionProcessingValidationException))),
                        Times.Once);

            this.executionServiceMock.Verify(broker =>
                broker.Run(randomExecutions, inputExecutionFolder),
                    Times.Never);

            this.executionServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
