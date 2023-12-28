// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;

namespace Standardly.Models.Configurations
{
    internal class ProjectInfo
    {
        public ProjectInfo()
        { }

        public ProjectInfo(string projectName, string projectPath)
        {
            ProjectName = projectName;
            ProjectFullPath = projectPath;
            FileInfo fileInfo = new FileInfo(projectPath);
            ProjectFolder = fileInfo?.Directory?.FullName ?? string.Empty;
            ProjectFile = fileInfo?.Name ?? string.Empty;
        }

        public string ProjectName { get; set; } = string.Empty;
        public string ProjectFullPath { get; set; } = string.Empty;
        public string ProjectFolder { get; set; } = string.Empty;
        public string ProjectFile { get; set; } = string.Empty;
    }
}
