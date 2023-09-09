// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;

namespace Standardly.ToolWindows
{
    /// <summary>
    /// A command for showing a tool window.
    /// </summary>
    [VisualStudioContribution]
    public class GenerateCodeToolWindowCommand : Command
    {
        /// <summary>GenerateCodeToolWindowCommand" /> class.
        /// </summary>
        /// <param name="extensibility">Extensibility object instance.</param>
        public GenerateCodeToolWindowCommand(VisualStudioExtensibility extensibility)
            : base(extensibility)
        {
        }

        /// <inheritdoc />
        public override CommandConfiguration CommandConfiguration => new(displayName: "%Standardly.ToolWindows.GenerateCodeToolWindowCommand.DisplayName%")
        {
            // Use this object initializer to set optional parameters for the command. The required parameter,
            // displayName, is set above. To localize the displayName, add an entry in .vsextension\string-resources.json
            // and reference it here by passing "%Standardly.ToolWindows.GenerateCodeToolWindowCommand.DisplayName%" as a constructor parameter.
            Placements = new[] { CommandPlacement.KnownPlacements.ExtensionsMenu },
            Icon = new(ImageMoniker.KnownValues.Extension, IconSettings.IconAndText),
        };

        /// <inheritdoc />
        public override async Task ExecuteCommandAsync(IClientContext context, CancellationToken cancellationToken)
        {
            await this.Extensibility.Shell().ShowToolWindowAsync<GenerateCodeToolWindow>(activate: true, cancellationToken);
        }
    }
}
