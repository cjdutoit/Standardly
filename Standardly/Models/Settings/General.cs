// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Settings
{
    public class General
    {
        public string DefaultBranchName { get; set; }
        public string GitHubUsername { get; set; }
        public string DisplayName { get; set; }
        public string Copyright { get; set; }
        public string License { get; set; }
        public bool AddEditorConfigFileIfNotPresent { get; set; }
        public bool AddGitIgnoreFileIfNotPresent { get; set; }
        public bool AddLicenseFileIfNotPresent { get; set; }
    }
}
