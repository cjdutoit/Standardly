using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Standardly
{
    [Command(PackageIds.StandardlyTemplateFolderCommand)]
    internal sealed class StandardlyTemplateFolderCommand : BaseCommand<StandardlyTemplateFolderCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
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
