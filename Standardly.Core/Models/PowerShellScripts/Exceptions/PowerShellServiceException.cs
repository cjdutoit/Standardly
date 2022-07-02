// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.PowerShellScripts.Exceptions
{
    public class PowerShellServiceException : Xeption
    {
        public PowerShellServiceException(Xeption innerException)
            : base(message: "PowerShell service error occurred, contact support.",
                  innerException)
        { }
    }
}
