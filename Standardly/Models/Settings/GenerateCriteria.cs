// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Models.Foundations.Templates;
using Standardly.Models.Foundations.TemplateGenerations.Templates;

namespace Standardly.Models.Settings
{
    public class GenerateCriteria
    {
        public string GitHubBaseBranchName { get; set; }
        public string GitHubUsername { get; set; }
        public string DisplayName { get; set; }
        public string Copyright { get; set; }
        public string License { get; set; }
        public Template Template { get; set; }
        public Template ConfigTemplate { get; set; }
        public string NameSingular { get; set; }
        public string NamePlural { get; set; }
        public string RootNameSpace { get; set; }
        public string ProjectPath { get; set; }
        public string UnitTestProjectPath { get; set; }
        public string AcceptanceTestProjectPath { get; set; }
        public bool AddEditorConfigFile { get; set; }
        public bool AddGitIgnoreFile { get; set; }
        public bool AddLicenseFile { get; set; }
        public bool SubmitAsDraftPullRequest { get; set; }
    }
}
