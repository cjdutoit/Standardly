// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using Standardly.Brokers;
using Standardly.Models.Foundations.Templates.ProcessedEvents;

using ExternalTemplateGenerationInfo = Standardly.Core.Models.Services.Orchestrations
    .TemplateGenerations.TemplateGenerationInfo;

using LocalTemplateGenerationInfo = Standardly.Models.Foundations.Templates.TemplateGenerationInfo;

namespace Standardly.Services.Foundations.Templates
{
    internal partial class TemplateService : ITemplateService
    {
        private readonly ICodeGenerationBroker codeGenerationBroker;

        public TemplateService(ICodeGenerationBroker codeGenerationBroker)
        {
            this.codeGenerationBroker = codeGenerationBroker;
        }

        public ValueTask<LocalTemplateGenerationInfo> FindAllTemplatesAsync() =>
            throw new NotImplementedException();

        public ValueTask GenerateCodeAsync(LocalTemplateGenerationInfo templateGenerationInfo) =>
            TryCatch(async () =>
            {
                ValidateTemplateGenerationInfo(templateGenerationInfo);

                await this.codeGenerationBroker.GenerateCodeAsync(
                    MapToExternalTemplateGenerationInfo(templateGenerationInfo));
            });



        public void SubscribeToProcessedEvent(Func<LocalTemplateGenerationInfo, ValueTask>
            processedEventClientHandler) =>
            TryCatch(() =>
            {
                ValidateProcessedEventHandler(processedEventClientHandler);

                this.codeGenerationBroker.SubscribeToProcessedEvent(async (processed) =>
                {
                    LocalTemplateGenerationInfo templateGenerationInfo = MapToTemplateGenerationInfo(processed);
                    await processedEventClientHandler(templateGenerationInfo);
                });
            });

        private ExternalTemplateGenerationInfo MapToExternalTemplateGenerationInfo(LocalTemplateGenerationInfo templateGenerationInfo)
        {
            throw new NotImplementedException();
        }

        private LocalTemplateGenerationInfo MapToTemplateGenerationInfo(ExternalTemplateGenerationInfo
            externalTemplateGenerationInfo)
        {
            LocalTemplateGenerationInfo localTemplateGenerationInfo = new LocalTemplateGenerationInfo
            {
                Processed = new Processed
                {
                    Message = externalTemplateGenerationInfo.Processed.Message,
                    ProcessedItems = externalTemplateGenerationInfo.Processed.ProcessedItems,
                    Status = externalTemplateGenerationInfo.Processed.Status,
                    TimeStamp = externalTemplateGenerationInfo.Processed.TimeStamp,
                    TotalItems = externalTemplateGenerationInfo.Processed.TotalItems,
                }
            };

            return localTemplateGenerationInfo;
        }
    }
}
