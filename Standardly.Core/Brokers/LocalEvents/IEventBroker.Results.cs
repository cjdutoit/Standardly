using System;
using System.Threading.Tasks;
using Standardly.Core.Models.Results;

namespace Standardly.Core.Brokers.Events
{
    public partial interface IEventBroker
    {
        void SubscribeToResultAddEvent(
            Func<Result, ValueTask<Result>> 
                resultAddEventHandler);

        ValueTask PublishResultAddEventAsync(Result result);
    }
}
