// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using Standardly.Models.Foundations.Templates;

namespace Standardly.Services.Foundations.Templates
{
    internal interface ITemplateService
    {
        ValueTask<TemplateGenerationInfo> FindAllTemplatesAsync();

        ValueTask GenerateCodeAsync(TemplateGenerationInfo templateGenerationInfo);

        void SubscribeToProcessedEvent(
            Func<TemplateGenerationInfo, ValueTask> processedEventClientHandler);
    }
}
