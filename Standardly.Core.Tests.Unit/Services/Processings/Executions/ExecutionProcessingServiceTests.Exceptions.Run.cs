// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Standardly.Core.Models.Executions;
using Standardly.Core.Services.Processings.Executions;
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Executions
{
    public partial class ExecutionProcessingServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public async Task ShouldThrowDependencyValidationOnUpsertIfDependencyValidationErrorOccursAndLogItAsync(
            Xeption dependencyValidationException)
        {
            // given
            string randomExecutionFolder = GetRandomString();
            string inputExecutionFolder = randomExecutionFolder;
            List<Execution> randomExecutions = CreateRandomExecutions();
            List<Execution> inputExecutions = randomExecutions;

            var expectedExecutionProcessingDependencyValidationException =
                new ExecutionProcessingDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.executionServiceMock.Setup(service =>
                service.Run(inputExecutions, inputExecutionFolder))
                    .Throws(dependencyValidationException);

            // when
            System.Action runAction = () =>
                this.executionProcessingService.Run(randomExecutions, inputExecutionFolder);

            // then
            ExecutionProcessingDependencyValidationException actualException =
                Assert.Throws<ExecutionProcessingDependencyValidationException>(runAction);

            this.executionServiceMock.Verify(service =>
                service.Run(inputExecutions, inputExecutionFolder),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExecutionProcessingDependencyValidationException))),
                        Times.Once);

            this.executionServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
