// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using Standardly.Core.Models.Executions.Exceptions;
using Standardly.Core.Models.FileServices.Exceptions;
using Standardly.Core.Models.TemplateOrchestrations.Exceptions;
using Standardly.Core.Models.Templates;
using Standardly.Core.Models.Templates.Exceptions;
using Xeptions;

namespace Standardly.Core.Services.Orchestrations.TemplateOrchestrations
{
    public partial class TemplateOrchestrationService
    {
        private delegate string ReturningStringFunction();
        private delegate List<Template> ReturningTemplateListFunction();

        private List<Template> TryCatch(ReturningTemplateListFunction returningTemplateListFunction)
        {
            try
            {
                return returningTemplateListFunction();
            }
            catch (FileValidationException fileValidationException)
            {
                throw CreateAndLogDependencyValidationException(fileValidationException);
            }
            catch (FileDependencyValidationException fileDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(fileDependencyValidationException);
            }
            catch (FileServiceDependencyException fileDependencyException)
            {
                throw CreateAndLogDependencyException(fileDependencyException);
            }
            catch (FileServiceException fileServiceException)
            {
                throw CreateAndLogDependencyException(fileServiceException);
            }
            catch (Exception exception)
            {
                var failedTemplateOrchestrationServiceException =
                    new FailedTemplateOrchestrationServiceException(exception.InnerException as Xeption);

                throw CreateAndLogServiceException(failedTemplateOrchestrationServiceException);
            }
        }

        private string TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return returningStringFunction();
            }
            catch (NullTemplateOrchestrationException nullTemplateOrchestrationException)
            {
                throw CreateAndLogValidationException(nullTemplateOrchestrationException);
            }
            catch (FileValidationException fileServiceValidationException)
            {
                throw CreateAndLogDependencyValidationException(fileServiceValidationException);
            }
            catch (FileDependencyValidationException fileServiceDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(fileServiceDependencyValidationException);
            }
            catch (ExecutionValidationException executionValidationException)
            {
                throw CreateAndLogDependencyValidationException(executionValidationException);
            }
            catch (ExecutionDependencyValidationException executionDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(executionDependencyValidationException);
            }
            catch (TemplateValidationException templateValidationException)
            {
                throw CreateAndLogDependencyValidationException(templateValidationException);
            }
            catch (TemplateDependencyValidationException templateDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(templateDependencyValidationException);
            }
            catch (FileServiceException fileServiceException)
            {
                throw CreateAndLogDependencyException(fileServiceException);
            }
            catch (FileServiceDependencyException fileServiceDependencyException)
            {
                throw CreateAndLogDependencyException(fileServiceDependencyException);
            }
            catch (TemplateServiceException templateServiceException)
            {
                throw CreateAndLogDependencyException(templateServiceException);
            }
            catch (TemplateDependencyException templateDependencyException)
            {
                throw CreateAndLogDependencyException(templateDependencyException);
            }
            catch (ExecutionServiceException executionServiceException)
            {
                throw CreateAndLogDependencyException(executionServiceException);
            }
            catch (ExecutionDependencyException executionDependencyException)
            {
                throw CreateAndLogDependencyException(executionDependencyException);
            }
            catch (Exception exception)
            {
                var failedTemplateOrchestrationServiceException =
                    new FailedTemplateOrchestrationServiceException(exception.InnerException as Xeption);

                throw CreateAndLogServiceException(failedTemplateOrchestrationServiceException);
            }
        }

        private TemplateOrchestrationValidationException CreateAndLogValidationException(Xeption exception)
        {
            var templateOrchestrationValidationException =
                new TemplateOrchestrationValidationException(exception);

            return templateOrchestrationValidationException;
        }

        private TemplateOrchestrationDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var templateOrchestrationDependencyException =
                new TemplateOrchestrationDependencyException(exception.InnerException as Xeption);

            throw templateOrchestrationDependencyException;
        }

        private TemplateOrchestrationDependencyValidationException CreateAndLogDependencyValidationException(
        Xeption exception)
        {
            var templateOrchestrationDependencyValidationException =
                new TemplateOrchestrationDependencyValidationException(exception.InnerException as Xeption);

            throw templateOrchestrationDependencyValidationException;
        }

        private TemplateOrchestrationServiceException CreateAndLogServiceException(Exception exception)
        {
            var templateOrchestrationServiceException = new TemplateOrchestrationServiceException(exception);

            return templateOrchestrationServiceException;
        }
    }
}