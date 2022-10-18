using System;
using System.Threading.Tasks;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Brokers.Events
{
    public partial interface IEventBroker
    {
        void SubscribeToTemplateAddEvent(
            Func<Template, ValueTask<Template>> 
                templateAddEventHandler);
    }
}
