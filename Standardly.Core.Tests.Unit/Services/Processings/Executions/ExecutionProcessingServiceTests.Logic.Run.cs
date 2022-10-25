// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Standardly.Core.Models.Executions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Executions
{
    public partial class ExecutionProcessingServiceTests
    {
        [Fact]
        public void ShouldRunExecution()
        {
            // given
            string randomExecutionFolder = GetRandomString();
            string inputExecutionFolder = randomExecutionFolder;
            List<Execution> randomExecutions = CreateRandomExecutions();
            List<Execution> inputExecutions = randomExecutions;
            string randomExecutionResult = GetRandomString();
            string expectedResult = randomExecutionResult;

            this.executionServiceMock.Setup(service =>
                service.Run(inputExecutions, inputExecutionFolder))
                    .Returns(randomExecutionResult);

            // when
            string actualResult = this.executionProcessingService.Run(inputExecutions, inputExecutionFolder);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);

            this.executionServiceMock.Verify(service =>
                service.Run(inputExecutions, inputExecutionFolder),
                    Times.Once());

            this.executionServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
