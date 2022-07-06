// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Executions;
using Standardly.Core.Models.Executions.Exceptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.Executions
{
    public partial class ExecutionServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnRunIfPathIsInvalid(string invalidPath)
        {
            // given
            string someKey = GetRandomString();
            string someValue = GetRandomString();

            List<Execution> someExecutions = new List<Execution>();
            someExecutions.Add(new Execution() { Name = someKey, Instruction = someValue });

            var invalidExecutionException =
                new InvalidExecutionException();

            invalidExecutionException.AddData(
                key: "executionFolder",
                values: "Text is required");

            var expectedExecutionValidationException =
                new ExecutionValidationException(invalidExecutionException);

            // when
            Action runAction = () =>
                this.executionService.Run(someExecutions, invalidPath);

            ExecutionValidationException actualException = Assert.Throws<ExecutionValidationException>(
                runAction);

            // then
            actualException.Should().BeEquivalentTo(expectedExecutionValidationException);

            this.executionBrokerMock.Verify(broker =>
                broker.Run(someExecutions, invalidPath),
                    Times.Never);

            this.executionBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowValidationExceptionOnRunIfExecutionsIsEmpty()
        {
            // given
            string somePath = GetRandomString();

            List<Execution> someexecutions = new List<Execution>();

            var invalidExecutionException =
                new InvalidExecutionException();

            invalidExecutionException.AddData(
                key: $"executions",
                values: "Executions is required");

            var expectedExecutionValidationException =
                new ExecutionValidationException(invalidExecutionException);

            // when
            Action runAction = () =>
                this.executionService.Run(someexecutions, somePath);

            ExecutionValidationException actualException = Assert.Throws<ExecutionValidationException>(
                runAction);

            // then
            actualException.Should().BeEquivalentTo(expectedExecutionValidationException);

            this.executionBrokerMock.Verify(broker =>
                broker.Run(someexecutions, somePath),
                    Times.Never);

            this.executionBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ShouldThrowValidationExceptionOnRunIfExecutionsIsInvalid(string invalidItem)
        {
            // given
            string somePath = GetRandomString();
            string someKey1 = GetRandomString();
            string someKey2 = GetRandomString();

            List<Execution> someExecutions = new List<Execution>();
            someExecutions.Add(new Execution() { Name = someKey1, Instruction = invalidItem });
            someExecutions.Add(new Execution() { Name = someKey2, Instruction = invalidItem });

            var invalidExecutionException =
                new InvalidExecutionException();

            invalidExecutionException.AddData(
                key: $"Execution[{someKey1}]",
                values: "Execution required");

            invalidExecutionException.AddData(
                key: $"Execution[{someKey2}]",
                values: "Execution required");

            var expectedExecutionValidationException =
                new ExecutionValidationException(invalidExecutionException);

            // when
            Action runAction = () =>
                this.executionService.Run(someExecutions, somePath);

            ExecutionValidationException actualException = Assert.Throws<ExecutionValidationException>(
                runAction);

            // then
            actualException.Should().BeEquivalentTo(expectedExecutionValidationException);

            this.executionBrokerMock.Verify(broker =>
                broker.Run(someExecutions, somePath),
                    Times.Never);

            this.executionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
