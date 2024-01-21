// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using Microsoft.VisualStudio.ProjectSystem.Query;
using Standardly.Models.Configurations;
using Standardly.ToolWindows;

namespace Standardly.Commands
{
    /// <summary>
    /// GenerateCodeCommand handler.
    /// </summary>
    [VisualStudioContribution]
    internal class GenerateCodeCommand : Command
    {
        private readonly TraceSource logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateCodeCommand"/> class.
        /// </summary>
        /// <param name="extensibility">Extensibility object.</param>
        /// <param name="traceSource">Trace source instance to utilize.</param>
        public GenerateCodeCommand(VisualStudioExtensibility extensibility, TraceSource traceSource)
            : base(extensibility)
        {
            // This optional TraceSource can be used for logging in the command. You can use dependency injection
            // to access other services here as well.
            this.logger = Requires.NotNull(traceSource, nameof(traceSource));
        }

        /// <inheritdoc />
        public override CommandConfiguration CommandConfiguration =>
            new(displayName: "%Standardly.GenerateCodeCommand.DisplayName%")
            {
                Icon = new(ImageMoniker.KnownValues.Extension, IconSettings.IconAndText),
                Shortcuts = new CommandShortcutConfiguration[]
                {
                    new(ModifierKey.ControlShift, Key.F4),
                },
            };

        /// <inheritdoc />
        public override Task InitializeAsync(CancellationToken cancellationToken)
        {
            // Use InitializeAsync for any one-time setup or initialization.
            return base.InitializeAsync(cancellationToken);
        }

        /// <inheritdoc />
        public override async Task ExecuteCommandAsync(IClientContext context, CancellationToken cancellationToken)
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string extensionFolder = Path.GetDirectoryName(assemblyLocation);
            string appSettingsRelativePath = "appsettings.json";
            string appSettingsPath = Path.Combine(extensionFolder, appSettingsRelativePath);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(extensionFolder)
                .AddJsonFile(appSettingsPath, optional: true, reloadOnChange: true);

            var configuration = configurationBuilder.Build();

            var standardlyConfiguration = configuration
                .GetSection("standardlyConfiguration")
                .Get<StandardlyConfiguration>();

            var structureInfo = await GetSettings(context, cancellationToken);
            try
            {
                var standardlyClient = new Core.Clients.StandardlyClient();
            }
            catch (Exception ex)
            {
                throw;
            }

            //var frmGenerate = new frmGenerate(structureInfo, standardlyClient);
            //frmGenerate.ShowDialog();

            await this.Extensibility.Shell()
                .ShowToolWindowAsync<GenerateCodeToolWindow>(activate: true, cancellationToken);
        }

        private async ValueTask<StructureInfo> GetSettings(
            IClientContext context,
            CancellationToken cancellationToken)
        {
            ISolutionSnapshot? solution = (await context.Extensibility.Workspaces().QuerySolutionAsync(solution =>
            {
                return solution
                    .With(x => x.Path)
                    .With(x => x.BaseName)
                    .With(x => x.Directory)
                    .With(x => x.FileName);
            },
            cancellationToken)).FirstOrDefault();

            List<IProjectSnapshot> projects = (await context.Extensibility.Workspaces().QueryProjectsAsync(projects =>
            {
                return projects
                    .With(x => x.Path)
                    .With(x => x.Name)
                    .With(x => x.Type)
                    .With(x => x.ProjectReferences)
                    .With(x => x.DefaultNamespace)
                    .With(x => x.Properties)
                    .With(x => x.Folders)
                    .With(x => x.Capabilities)
                    .With(x => x.Kind);
            },
            cancellationToken)).ToList();

            IProjectSnapshot? activeProject = await context.GetActiveProjectAsync(project =>
            {
                return project
                    .With(x => x.Path)
                    .With(x => x.Name)
                    .With(x => x.Type)
                    .With(x => x.ProjectReferences)
                    .With(x => x.DefaultNamespace)
                    .With(x => x.Properties)
                    .With(x => x.Folders)
                    .With(x => x.Capabilities)
                    .With(x => x.Kind);
            },
            new CancellationToken());

            IProjectSnapshot? project = activeProject ?? projects.FirstOrDefault();

            if (project == null)
            {
                throw new Exception("No project found.");
            }

            var structureInfo = new StructureInfo();
            string assumeProjectName = project.Name;

            switch (project.Name)
            {
                case string s when s.Contains(".Tests"):
                    {
                        assumeProjectName = project.Name
                            .Substring(0, Math.Max(project.Name.IndexOf(".Tests"), 0));

                        project = projects.FirstOrDefault(project => project.Name == assumeProjectName);
                        break;
                    }
                case string s when s.Contains(".Infrastructure"):
                    {
                        assumeProjectName = project.Name
                            .Substring(0, Math.Max(project.Name.IndexOf(".Infrastructure"), 0));

                        project = projects.FirstOrDefault(project => project.Name == assumeProjectName);
                        break;
                    }
            }

            IProjectSnapshot? unitTestProject = projects
                .FirstOrDefault(project => project.Name == $"{assumeProjectName}.Tests.Unit");

            IProjectSnapshot? acceptanceTestProject = projects
                .FirstOrDefault(project => project.Name == $"{assumeProjectName}.Tests.Acceptance");

            IProjectSnapshot? integrationTestProject = projects
                .FirstOrDefault(project => project.Name == $"{assumeProjectName}.Tests.Integration");

            IProjectSnapshot? infrastructureProject = projects
                .FirstOrDefault(project => project.Name == $"{assumeProjectName}.Infrastructure");


            structureInfo.SolutionFolder = solution.Directory;
            structureInfo.RootNameSpace = project.Name;

            structureInfo.Project = project != null
                ? new ProjectInfo(projectName: project.Name, projectPath: project.Path)
                : null;

            structureInfo.UnitTestProject = unitTestProject != null
                ? new ProjectInfo(projectName: unitTestProject.Name, projectPath: unitTestProject.Path)
                : null;

            structureInfo.AcceptanceTestProject = acceptanceTestProject != null
                ? new ProjectInfo(projectName: acceptanceTestProject.Name, projectPath: acceptanceTestProject.Path)
                : null;

            structureInfo.IntegrationTestProject = integrationTestProject != null
                ? new ProjectInfo(projectName: integrationTestProject.Name, projectPath: integrationTestProject.Path)
                : null;

            structureInfo.InfrastructureProject = infrastructureProject != null
                ? new ProjectInfo(projectName: infrastructureProject.Name, projectPath: infrastructureProject.Path)
                : null;

            return structureInfo;
        }
    }
}
