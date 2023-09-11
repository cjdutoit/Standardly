// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standardly.Core.Models.Services.Foundations.Templates;

namespace Standardly.Brokers
{
    internal partial interface ICodeGenerationBroker
    {
        ValueTask<List<Template>> FindAllTemplatesAsync();
    }
}
