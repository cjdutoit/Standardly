// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Moq;
using Standardly.Core.Brokers.Loggings;
using Standardly.Core.Models.FileServices.Exceptions;
using Standardly.Core.Services.Foundations.FileServices;
using Standardly.Core.Services.Processings.Files;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Standardly.Core.Tests.Unit.Services.Processings.Files
{
    public partial class FileProcessingServiceTests
    {
        private readonly Mock<IFileService> fileServiceMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IFileProcessingService fileProcessingService;

        public FileProcessingServiceTests()
        {
            this.fileServiceMock = new Mock<IFileService>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.fileProcessingService = new FileProcessingService(
                fileService: this.fileServiceMock.Object,
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
                new FileValidationException(innerException),
                new FileDependencyValidationException(innerException)
            };
        }

        public static TheoryData DependencyExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Xeption>
            {
                new FileDependencyException(innerException),
                new FileServiceException(innerException)
            };
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
