// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Standardly.Core.Models.Templates;
using Standardly.Core.Services.Foundations.TemplateServices;
using Standardly.Core.Services.Orchestrations.TemplateOrchestrations;

namespace Standardly.SPA.Pages
{
    public partial class TemplatePage
    {
        [Inject]
        private  ITemplateOrchestrationService templateOrchestrationService { get; set; }
        [Inject]
        private ITemplateService templateService { get; set; }

        protected List<Template> templates { get; set; } = new();
        protected override void  OnInitialized()
        {
            this.templates = this.templateOrchestrationService.FindAllTemplates();
            this.StateHasChanged();

        }
    }
}
