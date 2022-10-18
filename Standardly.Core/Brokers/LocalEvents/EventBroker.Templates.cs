using System;
using System.Threading.Tasks;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Brokers.Events
{
    public partial class EventBroker
    {
        private static Func<Template, ValueTask<Template>> 
            TemplateAddEventHandler;

        public void SubscribeToTemplateAddEvent(
            Func<Template, ValueTask<Template>> 
                templateAddEventHandler) =>
            TemplateAddEventHandler = templateAddEventHandler;

        public async ValueTask PublishTemplateAddEventAsync(
            Template template) =>
        await TemplateAddEventHandler(template);
    }
}
