// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.Foundations.Executions;

namespace Standardly.Core.Services.Processings.Executions
{
    public interface IExecutionProcessingService
    {
        string Run(List<Execution> executions, string executionFolder);
    }
}
