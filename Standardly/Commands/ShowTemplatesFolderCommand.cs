// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Diagnostics;
using System.Reflection;
using Microsoft;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;

namespace Standardly.Commands
{
    /// <summary>
    /// ShowTemplatesFolderCommand handler.
    /// </summary>
    [VisualStudioContribution]
    internal class ShowTemplatesFolderCommand : Command
    {
        private readonly TraceSource logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowTemplatesFolderCommand"/> class.
        /// </summary>
        /// <param name="extensibility">Extensibility object.</param>
        /// <param name="traceSource">Trace source instance to utilize.</param>
        public ShowTemplatesFolderCommand(VisualStudioExtensibility extensibility, TraceSource traceSource)
            : base(extensibility)
        {
            // This optional TraceSource can be used for logging in the command. You can use dependency injection
            // to access other services here as well.
            this.logger = Requires.NotNull(traceSource, nameof(traceSource));
        }

        /// <inheritdoc />
        public override CommandConfiguration CommandConfiguration =>
            new(displayName: "%Standardly.ShowTemplatesFolderCommand.DisplayName%")
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
                string assembly = Assembly.GetExecutingAssembly().Location;
                string templateFolder = Path.Combine(Path.GetDirectoryName(assembly), "Templates");

                if (!Directory.Exists(templateFolder))
                {
                    Directory.CreateDirectory(templateFolder);
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = templateFolder,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            });
        }
    }
}
