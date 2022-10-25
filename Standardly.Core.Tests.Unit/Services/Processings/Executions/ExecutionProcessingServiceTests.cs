// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using Standardly.Core.Brokers.Loggings;
using Standardly.Core.Models.Executions;
using Standardly.Core.Models.Executions.Exceptions;
using Standardly.Core.Services.Foundations.Executions;
using Standardly.Core.Services.Processings.Executions;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Executions
{
    public partial class ExecutionProcessingServiceTests
    {
        private readonly Mock<IExecutionService> executionServiceMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IExecutionProcessingService executionProcessingService;

        public ExecutionProcessingServiceTests()
        {
            this.executionServiceMock = new Mock<IExecutionService>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.executionProcessingService = new ExecutionProcessingService(
                executionService: this.executionServiceMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        public static TheoryData DependencyValidationExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Xeption>
            {
                new ExecutionValidationException(innerException),
                new ExecutionDependencyValidationException(innerException)
            };
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static List<Execution> CreateRandomExecutions() =>
            CreateExecutionFiller().Create(count: GetRandomNumber()).ToList();

        private static Filler<Execution> CreateExecutionFiller()
        {
            var filler = new Filler<Execution>();

            return filler;
        }
    }
}
