// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Models.Configurations
{
    internal class StructureInfo
    {
        public string? SolutionFolder { get; set; }
        public string? RootNameSpace { get; set; }
        public ProjectInfo? Project { get; set; }
        public ProjectInfo? UnitTestProject { get; set; }
        public ProjectInfo? AcceptanceTestProject { get; set; }
        public ProjectInfo? IntegrationTestProject { get; set; }
        public ProjectInfo? InfrastructureProject { get; set; }
    }
}
