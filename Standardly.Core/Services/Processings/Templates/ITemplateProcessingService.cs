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
        Template ConvertToTemplate(Template template, Dictionary<string, string> replacementDictionary);
        void ValidateSourceFiles(Template template);
    }
}
