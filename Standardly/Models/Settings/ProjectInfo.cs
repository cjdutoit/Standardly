// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Settings
{
    public class ProjectInfo
    {
        public string SolutionFolder { get; set; }
        public string RootNameSpace { get; set; }
        public string ProjectName { get; set; }
        public string ProjectFullPath { get; set; }
        public string ProjectFolder { get; set; }
        public string UnitTestProjectName { get; set; }
        public string UnitTestProjectFullPath { get; set; }
        public string UnitTestProjectFolder { get; set; }
        public string AcceptanceTestProjectName { get; set; }
        public string AcceptanceTestProjectFullPath { get; set; }
        public string AcceptanceTestProjectFolder { get; set; }
        public string InfrastructureBuildProjectName { get; set; }
        public string InfrastructureBuildProjectFullPath { get; set; }
        public string InfrastructureBuildProjectFolder { get; set; }
        public string InfrastructureProvisionProjectName { get; set; }
        public string InfrastructureProvisionProjectFullPath { get; set; }
        public string InfrastructureProvisionProjectFolder { get; set; }

    }
}
