using System;
using System.Threading.Tasks;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Brokers.Events
{
    public partial class EventBroker
    {
        private static Func<Template, ValueTask<Template>> 
            TemplateAddEventHandler;
        
        private static Func<Template, ValueTask<Template>> 
            TemplateModifyEventHandler;

        private static Func<Template, ValueTask<Template>> 
            TemplateRemoveEventHandler;

        public void SubscribeToTemplateAddEvent(
            Func<Template, ValueTask<Template>> 
                templateAddEventHandler) =>
            TemplateAddEventHandler = templateAddEventHandler;

        public async ValueTask PublishTemplateAddEventAsync(
            Template template) =>
        await TemplateAddEventHandler(template);

        public void SubscribeToTemplateModifyEvent(
            Func<Template, ValueTask<Template>> 
                templateModifyEventHandler) =>
            TemplateModifyEventHandler = templateModifyEventHandler;

        public async ValueTask PublishTemplateModifyEventAsync(
            Template template) =>
        await TemplateModifyEventHandler(template);

        public void SubscribeToTemplateRemoveEvent(
            Func<Template, ValueTask<Template>> 
                templateRemoveEventHandler) =>
            TemplateRemoveEventHandler = templateRemoveEventHandler;
    }
}
