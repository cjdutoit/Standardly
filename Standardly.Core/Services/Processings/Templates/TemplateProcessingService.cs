// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Brokers.Loggings;
using Standardly.Core.Models.Foundations.Templates;
using Standardly.Core.Services.Processings.Templates;

namespace Standardly.Core.Services.Foundations.Templates
{
    public partial class TemplateProcessingService : ITemplateProcessingService
    {
        private readonly ITemplateService templateService;
        private readonly ILoggingBroker loggingBroker;

        public TemplateProcessingService(ITemplateService templateService, ILoggingBroker loggingBroker)
        {
            this.templateService = templateService;
            this.loggingBroker = loggingBroker;
        }

        public Template ConvertStringToTemplate(string content) =>
            TryCatch(() =>
            {
                ValidateConvertStringToTemplate(content);

                return this.templateService.ConvertStringToTemplate(content);
            });

        public Template TransformTemplate(Template template, Dictionary<string, string> replacementDictionary) =>
            throw new System.NotImplementedException();

        public void ValidateTemplateSourceFiles(Template template) =>
            throw new System.NotImplementedException();
    }
}
