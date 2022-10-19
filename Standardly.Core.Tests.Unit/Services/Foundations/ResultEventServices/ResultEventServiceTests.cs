// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Moq;
using Standardly.Core.Brokers.Events;
using Standardly.Core.Models.Results;
using Standardly.Core.Services.Foundations.ResultEventServices;
using Tynamix.ObjectFiller;

namespace Standardly.Core.Tests.Unit.Services.Foundations.ResultEventServices
{
    public partial class ResultEventServiceTests
    {
        private readonly Mock<IEventBroker> eventBrokerMock;
        private readonly IResultEventService resultEventService;

        public ResultEventServiceTests()
        {
            this.eventBrokerMock = new Mock<IEventBroker>();

            this.resultEventService = new ResultEventService(
                eventBroker: this.eventBrokerMock.Object);
        }

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Result CreateRandomResult() =>
            CreateResultFiller(dateTimeOffset: GetRandomDateTimeOffset()).Create();

        private static Filler<Result> CreateResultFiller(DateTimeOffset dateTimeOffset)
        {
            var filler = new Filler<Result>();
            filler.Setup().OnType<DateTimeOffset>().Use(dateTimeOffset);

            return filler;
        }
    }
}
