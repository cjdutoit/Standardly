// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Standardly.Core.Models.Services.Foundations.Templates;

namespace Standardly.Brokers
{
    internal partial class CodeGenerationBroker
    {
        public async ValueTask<List<Template>> FindAllTemplatesAsync()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string templateFolderPath = Path.Combine(Path.GetDirectoryName(assembly), @"Templates");
            string templateDefinitionFileName = "Template.json";

            return await this.standardlyClient.Templates
                .FindAllTemplatesAsync(templateFolderPath, templateDefinitionFileName);
        }
    }
}
