// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Standardly.Core.Clients;
using Standardly.Core.Models.Events;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Orchestrations;
using Standardly.Models.Events;

namespace Standardly.Brokers
{
    public class StandardlyClientBroker : IStandardlyClientBroker
    {
        private readonly IStandardlyTemplateClient standardlyTemplateClient;
        private readonly IStandardlyGenerationClient standardlyGenerationClient;

        public StandardlyClientBroker()
        {
            this.standardlyTemplateClient = new StandardlyTemplateClient();
            this.standardlyGenerationClient = new StandardlyGenerationClient();
            this.standardlyGenerationClient.Processed += ItemProcessed;
        }

        public event EventHandler<ItemProcessedEventArgs> Processed;

        public List<Template> FindAllTemplates()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string templateFolderPath = Path.Combine(Path.GetDirectoryName(assembly), @"Templates");
            string templateDefinitionFileName = "Template.json";

            return this.standardlyTemplateClient.FindAllTemplates(templateFolderPath, templateDefinitionFileName);
        }

        public void GenerateCode(TemplateGenerationInfo templateGenerationInfo)
        {
            this.standardlyGenerationClient.GenerateCode(templateGenerationInfo);
        }

        private void ItemProcessed(object sender, ProcessedEventArgs e)
        {
            OnProcessed(e);
        }

        protected virtual void OnProcessed(ProcessedEventArgs e)
        {
            EventHandler<ItemProcessedEventArgs> handler = Processed;
            if (handler != null)
            {
                handler(
                    this,
                    new ItemProcessedEventArgs
                    {
                        TimeStamp = e.TimeStamp,
                        Message = e.Message,
                        Status = e.Status,
                        ProcessedItems = e.ProcessedItems,
                        TotalItems = e.TotalItems,
                    });
            }
        }
    }
}
