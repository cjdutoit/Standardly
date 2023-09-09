// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.ToolWindows;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;

namespace Standardly.ToolWindows
{
    /// <summary>
    /// A sample tool window.
    /// </summary>
    [VisualStudioContribution]
    public class GenerateCodeToolWindow : ToolWindow
    {
        private readonly GenerateCodeToolWindowContent content = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateCodeToolWindow" /> class.
        /// </summary>
        /// <param name="extensibility">
        /// Extensibility object instance.
        /// </param>
        public GenerateCodeToolWindow(VisualStudioExtensibility extensibility)
            : base(extensibility)
        {
            this.Title = "My Tool Window";
        }

        /// <inheritdoc />
        public override ToolWindowConfiguration ToolWindowConfiguration => new()
        {
            // Use this object initializer to set optional parameters for the tool window.
            Placement = ToolWindowPlacement.Floating,
        };

        /// <inheritdoc />
        public override Task InitializeAsync(CancellationToken cancellationToken)
        {
            // Use InitializeAsync for any one-time setup or initialization.
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override Task<IRemoteUserControl> GetContentAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<IRemoteUserControl>(content);
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                content.Dispose();

            base.Dispose(disposing);
        }
    }
}
