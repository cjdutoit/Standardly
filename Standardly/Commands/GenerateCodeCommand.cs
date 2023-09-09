// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Diagnostics;
using Microsoft;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using Standardly.ToolWindows;

namespace Standardly.Commands
{
    /// <summary>
    /// GenerateCodeCommand handler.
    /// </summary>
    [VisualStudioContribution]
    internal class GenerateCodeCommand : Command
    {
        private readonly TraceSource logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateCodeCommand"/> class.
        /// </summary>
        /// <param name="extensibility">Extensibility object.</param>
        /// <param name="traceSource">Trace source instance to utilize.</param>
        public GenerateCodeCommand(VisualStudioExtensibility extensibility, TraceSource traceSource)
            : base(extensibility)
        {
            // This optional TraceSource can be used for logging in the command. You can use dependency injection
            // to access other services here as well.
            this.logger = Requires.NotNull(traceSource, nameof(traceSource));
        }

        /// <inheritdoc />
        public override CommandConfiguration CommandConfiguration =>
            new(displayName: "%Standardly.GenerateCodeCommand.DisplayName%")
            {
                Icon = new(ImageMoniker.KnownValues.Extension, IconSettings.IconAndText),
                Shortcuts = new CommandShortcutConfiguration[]
                {
                    new(ModifierKey.ControlShift, Key.F4),
                },
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
            await this.Extensibility.Shell()
                .ShowToolWindowAsync<GenerateCodeToolWindow>(activate: true, cancellationToken);
        }
    }
}
