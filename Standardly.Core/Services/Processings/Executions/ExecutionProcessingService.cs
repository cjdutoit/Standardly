// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Brokers.Loggings;
using Standardly.Core.Models.Executions;
using Standardly.Core.Services.Foundations.Executions;

namespace Standardly.Core.Services.Processings.Executions
{
    public partial class ExecutionProcessingService : IExecutionProcessingService
    {
        private readonly IExecutionService executionService;
        private readonly ILoggingBroker loggingBroker;

        public ExecutionProcessingService(
            IExecutionService executionService,
            ILoggingBroker loggingBroker)
        {
            this.executionService = executionService;
            this.loggingBroker = loggingBroker;
        }

        public string Run(List<Execution> executions, string executionFolder) =>
            TryCatch(() =>
            {
                ValidateOnRun(executions, executionFolder);

                return this.executionService.Run(executions, executionFolder);
            });
    }
}
