// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standardly.Core.Brokers.Events;
using Standardly.Core.Models.Results;

namespace Standardly.Core.Services.Foundations.ResultEventServices
{
    public class ResultEventService : IResultEventService
    {
        private readonly IEventBroker eventBroker;

        public ResultEventService(IEventBroker eventBroker) =>
            this.eventBroker = eventBroker;

        public void ListenToResultEvent(Func<Result, ValueTask<Result>> resultEventHandler) =>
            this.eventBroker.ListenToResultEvent(resultEventHandler);

        public async ValueTask PublishResultAsync(Result result) =>
            await this.eventBroker.PublishResultEventAsync(result);
    }
}
