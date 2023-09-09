// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Diagnostics;
using Microsoft;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;

namespace Standardly.Commands
{
    /// <summary>
    /// ShowDocumentationCommand handler.
    /// </summary>
    [VisualStudioContribution]
    internal class ShowDocumentationCommand : Command
    {
        private readonly TraceSource logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowDocumentationCommand"/> class.
        /// </summary>
        /// <param name="extensibility">Extensibility object.</param>
        /// <param name="traceSource">Trace source instance to utilize.</param>
        public ShowDocumentationCommand(VisualStudioExtensibility extensibility, TraceSource traceSource)
            : base(extensibility)
        {
            // This optional TraceSource can be used for logging in the command. You can use dependency injection
            // to access other services here as well.
            this.logger = Requires.NotNull(traceSource, nameof(traceSource));
        }

        /// <inheritdoc />
        public override CommandConfiguration CommandConfiguration =>
            new(displayName: "%Standardly.ShowDocumentationCommand.DisplayName%")
            {
                Icon = new(ImageMoniker.KnownValues.Extension, IconSettings.IconAndText),
            };

        /// <inheritdoc />
        public override Task InitializeAsync(CancellationToken cancellationToken)
        {
            // Use InitializeAsync for any one-time setup or initialization.
            return base.InitializeAsync(cancellationToken);
        }

        /// <inheritdoc />
        public override async Task ExecuteCommandAsync(IClientContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                string url = "https://github.com/cjdutoit/standardly";

                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            });
        }
    }
}
