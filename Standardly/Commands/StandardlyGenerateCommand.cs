// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Standardly.Mappers;
using Standardly.Models.Settings;

namespace Standardly
{
    [Command(PackageIds.StandardlyGenerateCommand)]
    internal sealed class StandardlyGenerateCommand : BaseCommand<StandardlyGenerateCommand>
    {
        OutputWindowPane _pane;

        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            try
            {
                //int maxRetryAttempts = 3;
                //TimeSpan pauseBetweenFailures = TimeSpan.FromSeconds(2);
                //General general = await General.GetLiveInstanceAsync();
                //Locations locations = await Locations.GetLiveInstanceAsync();
                //IEnumerable<Project> projects = await VS.Solutions.GetAllProjectsAsync();
                //Project project = await VS.Solutions.GetActiveProjectAsync() ?? projects.FirstOrDefault();
                //Setting settings = GetSettings(general, locations, project, projects);
                //IFileSystemBroker fileSystemBroker = new FileSystemBroker();
                //IExecutionBroker executionBroker = new CliExecutionBroker();
                //IRetryConfig retryConfig = new RetryConfig(maxRetryAttempts, pauseBetweenFailures);
                //IFileService fileService = new FileService(fileSystemBroker, retryConfig);
                //IExecutionService executionService = new ExecutionService(executionBroker);
                //ITemplateService templateService = new TemplateService(fileSystemBroker);

                //ITemplateOrchestrationService templateOrchestrationService =
                //    new TemplateOrchestrationService(
                //        fileService: fileService,
                //        executionService: executionService,
                //        templateService: templateService
                //    );

                //var frmGenerate = new frmGenerate(settings, templateService, templateOrchestrationService);
                //frmGenerate.ShowDialog();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task UseOutputWindowAsync(string message)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            if (_pane is null)
            {
                _pane = await VS.Windows.CreateOutputWindowPaneAsync("Standardly");
            }

            await _pane.ActivateAsync();

            await _pane.WriteLineAsync($"{message}\n\n");
        }


        private Setting GetSettings(
            General general,
            Locations locations,
            Project project,
            IEnumerable<Project> projects)
        {
            if (project is null)
            {
                project = projects.FirstOrDefault();
            }

            switch (project.Name)
            {
                case string s when s.Contains(".Tests"):
                    {
                        var assumeProjectName = project.Name
                            .Substring(0, Math.Max(project.Name.IndexOf(".Tests"), 0));

                        project = projects.FirstOrDefault(project => project.Name == assumeProjectName);
                        break;
                    }
                case string s when s.Contains(".Infrastructure"):
                    {
                        var assumeProjectName = project.Name
                            .Substring(0, Math.Max(project.Name.IndexOf(".Infrastructure"), 0));

                        project = projects.FirstOrDefault(project => project.Name == assumeProjectName);
                        break;
                    }
            }

            var solutionFolderPath = project.Parent.Type.ToString() == "SolutionFolder"
                ? project.Parent.Parent.FullPath
                : project.Parent.FullPath;

            FileInfo solutionFileInfo = new FileInfo(solutionFolderPath);
            string solutionFolder = solutionFileInfo.DirectoryName;

            SolutionItem unitTestProject = project.Parent.Children
                        .FirstOrDefault(child => child.Name == $"{project.Name}.Tests.Unit");

            SolutionItem acceptanceTestProject = project.Parent.Children
                .FirstOrDefault(child => child.Name == $"{project.Name}.Tests.Acceptance");


            SolutionItem infrastructureBuildProject = project.Parent.Children
                .FirstOrDefault(child => child.Name == $"{project.Name}.Infrastructure.Build");

            SolutionItem infrastructureProvisionProject = project.Parent.Children
                .FirstOrDefault(child => child.Name == $"{project.Name}.Infrastructure.Provision");

            var settings = new Setting
            {
                General = GeneralMapper.Map(general),
                Location = LocationMapper.Map(locations),
                ProjectInfo = new ProjectInfo()
                {
                    SolutionFolder = solutionFolder,
                    RootNameSpace = project.Name,
                    ProjectName = project.Name,
                    ProjectFullPath = project.FullPath,
                    ProjectFolder = new FileInfo(project.FullPath).Directory.FullName,
                    ProjectFile = new FileInfo(project.FullPath).Name,
                    UnitTestProjectName = unitTestProject != null ? unitTestProject.Name : "",
                    UnitTestProjectFullPath = unitTestProject != null ? unitTestProject.FullPath : "",

                    UnitTestProjectFolder = unitTestProject != null
                        ? new FileInfo(unitTestProject.FullPath).DirectoryName
                        : "",

                    UnitTestProjectFile = unitTestProject != null
                        ? new FileInfo(unitTestProject.FullPath).Name
                        : "",

                    AcceptanceTestProjectName = acceptanceTestProject != null
                        ? acceptanceTestProject.Name
                        : "",

                    AcceptanceTestProjectFullPath = acceptanceTestProject != null
                        ? acceptanceTestProject.FullPath
                        : "",

                    AcceptanceTestProjectFolder = acceptanceTestProject != null
                        ? new FileInfo(acceptanceTestProject.FullPath).DirectoryName
                        : "",

                    AcceptanceTestProjectFile = acceptanceTestProject != null
                        ? new FileInfo(acceptanceTestProject.FullPath).Name
                        : "",

                    InfrastructureBuildProjectName = infrastructureBuildProject != null
                        ? infrastructureBuildProject.Name
                        : "",

                    InfrastructureBuildProjectFullPath = infrastructureBuildProject != null
                        ? infrastructureBuildProject.FullPath
                        : "",

                    InfrastructureBuildProjectFolder = infrastructureBuildProject != null
                        ? new FileInfo(infrastructureBuildProject.FullPath).DirectoryName
                        : "",

                    InfrastructureBuildProjectFile = infrastructureBuildProject != null
                        ? new FileInfo(infrastructureBuildProject.FullPath).Name
                        : "",

                    InfrastructureProvisionProjectName = infrastructureProvisionProject != null
                        ? infrastructureProvisionProject.Name
                        : "",

                    InfrastructureProvisionProjectFullPath = infrastructureProvisionProject != null
                        ? infrastructureProvisionProject.FullPath
                        : "",

                    InfrastructureProvisionProjectFolder = infrastructureProvisionProject != null
                        ? new FileInfo(infrastructureProvisionProject.FullPath).DirectoryName
                        : "",

                    InfrastructureProvisionProjectFile = infrastructureProvisionProject != null
                        ? new FileInfo(infrastructureProvisionProject.FullPath).Name
                        : ""
                }
            };

            return settings;
        }
    }
}
