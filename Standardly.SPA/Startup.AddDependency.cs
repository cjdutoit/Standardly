// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Standardly.Core.Brokers.ExecutionBroker;
using Standardly.Core.Brokers.FileSystems;
using Standardly.Core.Models.RetryConfig;
using Standardly.Core.Services.Foundations.Executions;
using Standardly.Core.Services.Foundations.FileServices;
using Standardly.Core.Services.Foundations.TemplateServices;
using Standardly.Core.Services.Orchestrations.TemplateOrchestrations;

namespace Standardly.SPA
{
    public partial class Startup
    {
        private void AddDependency(IServiceCollection services) 
        {
            services.AddSingleton<IExecutionBroker, PowerShellExecutionBroker>();
            services.AddSingleton<IExecutionService, ExecutionService>();
            services.AddSingleton<IRetryConfig, RetryConfig>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFileSystemBroker, FileSystemBroker>();
            services.AddSingleton<ITemplateService, TemplateService>();
            services.AddSingleton<ITemplateOrchestrationService, TemplateOrchestrationService>();
        }
    }
}
