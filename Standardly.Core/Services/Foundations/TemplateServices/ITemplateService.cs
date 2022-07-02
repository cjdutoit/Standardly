// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.Templates;

namespace Standardly.Core.Services.Foundations.TemplateServices
{
    public interface ITemplateService
    {
        string TransformString(string @string, Dictionary<string, string> replacementDictionary);
        Template ConvertStringToTemplate(string @string);
    }
}
