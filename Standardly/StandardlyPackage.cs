// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

global using System;
global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using Task = System.Threading.Tasks.Task;
using System.Runtime.InteropServices;
using System.Threading;

namespace Standardly
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.StandardlyString)]
    [ProvideOptionPage(typeof(OptionsProvider.GeneralOptions), "Standardly", "General", 0, 0, true, SupportsProfiles = true)]
    [ProvideOptionPage(typeof(OptionsProvider.LocationsOptions), "Standardly", "Locations", 0, 0, true, SupportsProfiles = true)]
    public sealed class StandardlyPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.RegisterCommandsAsync();
        }
    }
}