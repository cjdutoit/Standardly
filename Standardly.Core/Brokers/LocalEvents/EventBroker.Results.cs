using System;
using System.Threading.Tasks;
using Standardly.Core.Models.Results;

namespace Standardly.Core.Brokers.Events
{
    public partial class EventBroker
    {
        private static Func<Result, ValueTask<Result>> 
            ResultAddEventHandler;
        
        private static Func<Result, ValueTask<Result>> 
            ResultModifyEventHandler;

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

    }
}
