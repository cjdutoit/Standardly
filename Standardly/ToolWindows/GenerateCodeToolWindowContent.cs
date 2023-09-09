// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.VisualStudio.Extensibility.UI;

namespace Standardly.ToolWindows
{
    /// <summary>
    /// A remote user control to use as tool window UI content.
    /// </summary>
    internal class GenerateCodeToolWindowContent : RemoteUserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateCodeToolWindowContent" /> class.
        /// </summary>
        public GenerateCodeToolWindowContent()
            : base(dataContext: new GenerateCodeToolWindowData())
        {
        }
    }
}
