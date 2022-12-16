// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Brokers;
using Standardly.Models.Events;
using Standardly.Models.Foundations;

namespace Standardly.Services.Foundations
{
    public partial class TemplateService : ITemplateService
    {
        private readonly IStandardlyClientBroker standardlyClientBroker;

        public TemplateService(IStandardlyClientBroker standardlyClientBroker)
        {
            this.standardlyClientBroker = standardlyClientBroker;
            this.standardlyClientBroker.Processed += ItemProcessed;
        }

        public event EventHandler<ItemProcessedEventArgs> Processed;

        public TemplateGeneration FindAllTemplates() =>
            throw new NotImplementedException();

        public void GenerateCode(TemplateGeneration templateGenerationInfo) =>
            throw new NotImplementedException();

        private void ItemProcessed(object sender, ItemProcessedEventArgs @event)
        {
            OnProcessed(@event);
        }

        protected virtual void OnProcessed(ItemProcessedEventArgs @event)
        {
            EventHandler<ItemProcessedEventArgs> handler = Processed;
            if (handler != null)
            {
                handler(this, @event);
            }
        }
    }
}
