// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Standardly.Core.Models.PowerShellScripts.Exceptions
{
    public class FailedPowerShellServiceException : Xeption
    {
        public FailedPowerShellServiceException(Exception innerException)
            : base(message: "Failed powershell service error occurred, contact support.",
                  innerException)
        { }
    }
}
