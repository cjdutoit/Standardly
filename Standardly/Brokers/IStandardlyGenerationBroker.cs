// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Models.Orchestrations;
using Standardly.Models.Events;

namespace Standardly.Brokers
{
    public interface IStandardlyGenerationBroker
    {
        event EventHandler<ItemProcessedEventArgs> Processed;
        void GenerateCode(TemplateGenerationInfo templateGenerationInfo);
    }
}
