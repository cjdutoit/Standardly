// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standardly.Core.Models.Results;

namespace Standardly.Core.Brokers.Events
{
    public partial class EventBroker
    {
        private static Func<Result, ValueTask<Result>>
            ResultEventHandler;

        public void ListenToResultEvent(
            Func<Result, ValueTask<Result>>
                resultEventHandler) =>
            ResultEventHandler = resultEventHandler;

        public async ValueTask PublishResultEventAsync(
            Result result) =>
        await ResultEventHandler(result);
    }
}
