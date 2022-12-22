// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Models.Orchestrations;
using Standardly.Models.Events;

namespace Standardly.Brokers
{
    public interface IStandardlyClientBroker
    {
        event EventHandler<ItemProcessedEventArgs> Processed;
        List<Template> FindAllTemplates();
        void GenerateCode(TemplateGenerationInfo templateGenerationInfo);
    }
}
