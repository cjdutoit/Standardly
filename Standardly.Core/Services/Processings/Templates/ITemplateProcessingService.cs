// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.Foundations.Templates;

namespace Standardly.Core.Services.Processings.Templates
{
    public interface ITemplateProcessingService
    {
        Template ConvertStringToTemplate(string @string);
        Template TransformTemplate(Template template, Dictionary<string, string> replacementDictionary);
        void ValidateTemplateSourceFiles(Template template);
    }
}
