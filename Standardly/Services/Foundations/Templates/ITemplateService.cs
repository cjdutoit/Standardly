// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Models.Events;
using Standardly.Models.Foundations;

namespace Standardly.Services.Foundations
{
    public interface ITemplateService
    {
        event EventHandler<ItemProcessedEventArgs> Processed;
        TemplateGeneration FindAllTemplates();
        void GenerateCode(TemplateGeneration templateGenerationInfo);
    }
}
