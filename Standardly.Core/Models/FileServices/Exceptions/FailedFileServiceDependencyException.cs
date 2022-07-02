// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Standardly.Core.Models.FileServices.Exceptions
{
    public class FailedFileServiceDependencyException : Xeption
    {
        public FailedFileServiceDependencyException(Exception innerException)
            : base(message: "File service dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
