// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Standardly.Core.Clients;
using Standardly.Core.Models.Foundations.Templates;

namespace Standardly.Brokers
{
    public class StandardlyTemplateBroker : IStandardlyTemplateBroker
    {
        private readonly IStandardlyTemplateClient standardlyTemplateClient;

        public StandardlyTemplateBroker()
        {
            this.standardlyTemplateClient = new StandardlyTemplateClient();
        }

        public List<Template> FindAllTemplates()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string templateFolderPath = Path.Combine(Path.GetDirectoryName(assembly), @"Templates");
            string templateDefinitionFileName = "Template.json";

            return this.standardlyTemplateClient.FindAllTemplates(templateFolderPath, templateDefinitionFileName);
        }
    }
}
