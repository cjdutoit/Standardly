// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standardly.Core.Models.Results;

namespace Standardly.Core.Services.Foundations.ResultEventServices
{
    public interface IResultEventService
    {
        void ListenToResultEvent(Func<Result, ValueTask<Result>> resultEventHandler);
        ValueTask PublishResultAsync(Result result);
    }
}
