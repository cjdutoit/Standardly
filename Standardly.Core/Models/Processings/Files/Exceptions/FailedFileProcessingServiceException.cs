// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Standardly.Core.Models.Processings.Files.Exceptions
{
    public class FailedFileProcessingServiceException : Xeption
    {
        public FailedFileProcessingServiceException(Exception innerException)
            : base(message: "Failed file service occurred, please contact support", innerException)
        { }
    }
}
