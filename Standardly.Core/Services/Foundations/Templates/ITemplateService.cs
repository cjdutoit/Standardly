// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.Foundations.Templates;

namespace Standardly.Core.Services.Foundations.Templates
{
    public interface ITemplateService
    {
        string TransformString(string @string, Dictionary<string, string> replacementDictionary);
        void ValidateTransformation(string @string);
        Template ConvertStringToTemplate(string @string);
        void ValidateSourceFiles(Template template);
    }
}
