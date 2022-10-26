// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace Standardly.Core.Models.Foundations.Templates.Exceptions
{
    public class NullTemplateException : Xeption
    {
        public NullTemplateException()
            : base(message: "Template is null.")
        { }
    }
}
