// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Standardly.Core.Brokers.ExecutionBroker;
using Standardly.Core.Services.Foundations.Executions;
using Tynamix.ObjectFiller;

namespace Standardly.Core.Tests.Unit.Services.Foundations.Executions
{
    public partial class ExecutionServiceTests
    {
        private readonly Mock<IExecutionBroker> executionBrokerMock;
        private readonly IExecutionService executionService;

        public ExecutionServiceTests()
        {
            executionBrokerMock = new Mock<IExecutionBroker>();

            this.executionService = new ExecutionService(
                executionBroker: this.executionBrokerMock.Object);
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
