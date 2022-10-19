// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Moq;
using Standardly.Core.Models.Results;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Foundations.ResultEventServices
{
    public partial class ResultEventServiceTests
    {
        [Fact]
        public void ShouldListenToResultEvent()
        {
            // given
            var resultEventHandlerMock =
                new Mock<Func<Result, ValueTask<Result>>>();

            // when
            this.resultEventService.ListenToResultEvent(
                resultEventHandlerMock.Object);

            // then
            this.eventBrokerMock.Verify(broker =>
                broker.ListenToResultEvent(
                    resultEventHandlerMock.Object),
                        Times.Once);

            this.eventBrokerMock.VerifyNoOtherCalls();
        }
    }
}
