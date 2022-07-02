// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.PowerShellScripts.Exceptions
{
    public class InvalidPowerShellException : Xeption
    {
        public InvalidPowerShellException()
            : base(message: "Invalid powershell criteria, fix the errors and try again.")
        { }
    }
}
