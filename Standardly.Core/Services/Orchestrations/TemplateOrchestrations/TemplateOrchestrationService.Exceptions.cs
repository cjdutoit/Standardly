// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using Standardly.Core.Models.FileServices.Exceptions;
using Standardly.Core.Models.TemplateOrchestrations.Exceptions;
using Standardly.Core.Models.Templates;
using Xeptions;

namespace Standardly.Core.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationService
    {
        private delegate List<Template> ReturningTemplateListFunction();

        private List<Template> TryCatch(ReturningTemplateListFunction returningTemplateListFunction)
        {
            try
            {
                return returningTemplateListFunction();
            }
            catch (FileServiceValidationException fileValidationException)
            {
                throw CreateAndLogDependencyValidationException(fileValidationException);
            }
            catch (FileServiceDependencyValidationException fileDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(fileDependencyValidationException);
            }
        }

        private TemplateOrchestrationDependencyValidationException CreateAndLogDependencyValidationException(
            Xeption exception)
        {
            var templateOrchestrationDependencyValidationException =
                new TemplateOrchestrationDependencyValidationException(exception.InnerException as Xeption);

            throw templateOrchestrationDependencyValidationException;
        }
    }
}