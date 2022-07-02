// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.PowerShellScripts.Exceptions
{
    public class PowerShellValidationException : Xeption
    {
        public PowerShellValidationException(Xeption innerException)
            : base(message: "PowerShell validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
