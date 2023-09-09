// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using Standardly.Commands;

namespace Standardly
{
    /// <summary>
    /// Extension entrypoint for the VisualStudio.Extensibility extension.
    /// </summary>
    [VisualStudioContribution]
    internal class ExtensionEntrypoint : Extension
    {
        /// <inheritdoc/>
        public override ExtensionConfiguration ExtensionConfiguration => new()
        {
            Metadata = new(
                id: "Standardly.4f725561-953f-4998-99c2-ec58132d8d48",
                version: this.ExtensionAssemblyVersion,
                publisherName: "Christo du Toit",
                displayName: "Standardly"),
        };

        /// <inheritdoc />
        protected override void InitializeServices(IServiceCollection serviceCollection)
        {
            base.InitializeServices(serviceCollection);

            // You can configure dependency injection here by adding services to the serviceCollection.
        }

        [VisualStudioContribution]
        public static MenuConfiguration Standardly => new("%Standardly.DisplayName%")
        {
            Placements = new CommandPlacement[]
    {
                CommandPlacement.KnownPlacements.ExtensionsMenu
    },
            Children = new[]
    {
                MenuChild.Command<GenerateCodeCommand>(),
                MenuChild.Command<ShowDocumentationCommand>(),
                MenuChild.Command<ShowTemplatesFolderCommand>(),
                MenuChild.Command<ShowMyUsageStats>(),
                MenuChild.Command<ShowLicenseCommand>(),
            },
            Priority = 1000,
        };
    }
}
