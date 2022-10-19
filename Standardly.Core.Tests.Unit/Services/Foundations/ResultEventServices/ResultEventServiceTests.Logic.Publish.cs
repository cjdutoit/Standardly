// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using Moq;
using Standardly.Core.Models.Results;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.ResultEventServices
{
    public partial class ResultEventServiceTests
    {
        [Fact]
        public async Task ShouldPublishResultAsync()
        {
            // given
            Result randomResult = CreateRandomResult();
            Result inputResult = randomResult;

            // when
            await this.resultEventService
                .PublishResultAsync(inputResult);

            // then
            this.eventBrokerMock.Verify(broker =>
                broker.PublishResultEventAsync(inputResult),
                    Times.Once);

            this.eventBrokerMock.VerifyNoOtherCalls();
        }
    }
}
