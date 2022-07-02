﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public partial class TemplateService : ITemplateService
    {
        private readonly IFileSystemBroker fileSystemBroker;

        public TemplateService(IFileSystemBroker fileSystemBroker)
        {
            this.fileSystemBroker = fileSystemBroker;
        }

        public string TransformString(string @string, Dictionary<string, string> replacementDictionary)
        {
            if (string.IsNullOrEmpty(@string))
            {
                return string.Empty;
            }

            string template = @string;

            if (replacementDictionary != null && replacementDictionary.Any())
            {
                foreach (var replacement in replacementDictionary)
                {
                    template = template.Replace(replacement.Key, replacement.Value);
                }
            }

            return template;
        }

        public void ValidateTransformation(string @string) =>
            TryCatch(() =>
            {
                ValidateTagReplacement(@string);
            });

        public Template ConvertStringToTemplate(string @string) =>
            TryCatch(() =>
            {
                ValidateStringTemplateIsNotNull(@string);

                Template template = JsonConvert.DeserializeObject<Template>(@string);
                template.RawTemplate = @string;
                ValidateTemplate(template);

                return template;
            });

        public void ValidateSourceFiles(Template template) =>
            throw new NotImplementedException();
    }
}
