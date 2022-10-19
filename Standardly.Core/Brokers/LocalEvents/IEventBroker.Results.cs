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
    public partial interface IEventBroker
    {
        void ListenToResultEvent(
            Func<Result, ValueTask<Result>>
                resultEventHandler);

        ValueTask PublishResultEventAsync(Result result);
    }
}
