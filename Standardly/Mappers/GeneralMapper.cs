// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Mappers
{
    public static class GeneralMapper
    {
        public static Models.Settings.General Map(Standardly.General data)
        {
            var model = new Models.Settings.General()
            {
                DefaultBranchName = data.DefaultBranchName,
                GitHubUsername = data.GitHubUsername,
                DisplayName = data.DisplayName,
                Copyright = data.Copyright,
                License = data.License,
                AddEditorConfigFileIfNotPresent = data.AddEditorConfigFileIfNotPresent,
                AddGitIgnoreFileIfNotPresent = data.AddGitIgnoreFileIfNotPresent,
                AddLicenseFileIfNotPresent = data.AddLicenseFileIfNotPresent
            };

            return model;
        }
    }
}
