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

        ValueTask PublishTemplateAddEventAsync(Template template);
        
        void SubscribeToTemplateModifyEvent(
            Func<Template, ValueTask<Template>> 
                templateModifyEventHandler);

        ValueTask PublishTemplateModifyEventAsync(Template template);

        void SubscribeToTemplateRemoveEvent(
            Func<Template, ValueTask<Template>> 
                templateRemoveEventHandler);
    }
}
