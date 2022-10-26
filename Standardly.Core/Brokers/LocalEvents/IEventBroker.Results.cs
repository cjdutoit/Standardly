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
    public partial interface IEventBroker
    {
        void SubscribeToResultAddEvent(
            Func<Result, ValueTask<Result>>
                resultAddEventHandler);

        ValueTask PublishResultAddEventAsync(Result result);

        void SubscribeToResultModifyEvent(
            Func<Result, ValueTask<Result>>
                resultModifyEventHandler);

        ValueTask PublishResultModifyEventAsync(Result result);

        void SubscribeToResultRemoveEvent(
            Func<Result, ValueTask<Result>>
                resultRemoveEventHandler);

        ValueTask PublishResultRemoveEventAsync(Result result);
    }
}
