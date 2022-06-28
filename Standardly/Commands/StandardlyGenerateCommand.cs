// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly
{
    [Command(PackageIds.StandardlyGenerateCommand)]
    internal sealed class StandardlyGenerateCommand : BaseCommand<StandardlyGenerateCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("Standardly - Generate", "Button clicked");
        }
    }
}
