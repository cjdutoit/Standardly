// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Standardly
{
    [Command(PackageIds.StandardlyLicenseCommand)]
    internal sealed class StandardlyLicenseCommand : BaseCommand<StandardlyLicenseCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await Task.Run(() =>
            {
                string assembly = Assembly.GetExecutingAssembly().Location;
                string licensePath = Path.Combine(Path.GetDirectoryName(assembly), "LICENSE.txt");

                Process.Start("notepad.exe", licensePath);
            });
        }
    }
}
