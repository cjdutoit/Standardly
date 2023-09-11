// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using Standardly.Core.Models.Services.Orchestrations.TemplateGenerations;

namespace Standardly.Brokers
{
    internal partial interface ICodeGenerationBroker
    {
        ValueTask GenerateCodeAsync(TemplateGenerationInfo templateGenerationInfo);
    }
}
