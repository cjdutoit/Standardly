// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using Standardly.Core.Models.Foundations.Executions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.Executions
{
    public partial class ExecutionServiceTests
    {
        [Fact]
        public void ShouldRunExecutions()
        {
            // given
            string randomFilePath = GetRandomString();
            string inputFilePath = randomFilePath;
            string randomContent = GetRandomString();
            string inputName = randomContent;
            string inputValue = randomContent;

            List<Execution> inputDictionary = new List<Execution>();
            inputDictionary.Add(new Execution() { Name = inputName, Instruction = inputValue });

            // when
            this.executionService.Run(inputDictionary, inputFilePath);

            // then
            this.executionBrokerMock.Verify(broker =>
                broker.Run(inputDictionary, inputFilePath),
                    Times.Once);

            this.executionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
