// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standardly.Core.Models.Foundations.Results;

namespace Standardly.Core.Brokers.Events
{
    public partial class EventBroker
    {
        private static Func<Result, ValueTask<Result>>
            ResultAddEventHandler;

        private static Func<Result, ValueTask<Result>>
            ResultModifyEventHandler;

        private static Func<Result, ValueTask<Result>>
            ResultRemoveEventHandler;

        public void SubscribeToResultAddEvent(
            Func<Result, ValueTask<Result>>
                resultAddEventHandler) =>
            ResultAddEventHandler = resultAddEventHandler;

        public async ValueTask PublishResultAddEventAsync(
            Result result) =>
        await ResultAddEventHandler(result);

        public void SubscribeToResultModifyEvent(
            Func<Result, ValueTask<Result>>
                resultModifyEventHandler) =>
            ResultModifyEventHandler = resultModifyEventHandler;

        public async ValueTask PublishResultModifyEventAsync(
            Result result) =>
        await ResultModifyEventHandler(result);

        public void SubscribeToResultRemoveEvent(
            Func<Result, ValueTask<Result>>
                resultRemoveEventHandler) =>
            ResultRemoveEventHandler = resultRemoveEventHandler;

        public async ValueTask PublishResultRemoveEventAsync(
            Result result) =>
        await ResultRemoveEventHandler(result);
    }
}
