// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV3s;

namespace Standardly.Infrastructure.Build.Services
{
    public class ScriptGenerationService
    {
        private readonly ADotNetClient adotNetClient;

        public ScriptGenerationService() =>
            this.adotNetClient = new ADotNetClient();

        public void GenerateBuildScript()
        {
            var branchName = "main";
            var projectRelativePath = "Standardly/Standardly.csproj";
            var pipelineName = "Standardly Build";

            var githubPipeline = new GithubPipeline
            {
                Name = pipelineName,

                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { branchName }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Types = new string[] { "opened", "synchronize", "reopened", "closed" },
                        Branches = new string[] { branchName }
                    }
                },

                EnvironmentVariables = new Dictionary<string, string>
                {
                    { "IS_RELEASE_CANDIDATE", EnvironmentVariables.IsGitHubReleaseCandidate() }
                },

                Jobs = new Dictionary<string, Job>
                {
                    {
                        "build",
                        new Job
                        {
                            RunsOn = BuildMachines.WindowsLatest,

                            Steps = new List<GithubTask>
                            {
                                new CheckoutTaskV3
                                {
                                    Name = "Check out"
                                },

                                new SetupDotNetTaskV3
                                {
                                    Name = "Setup .Net",

                                    With = new TargetDotNetVersionV3
                                    {
                                        DotNetVersion = "7.0.201"
                                    }
                                },

                                new RestoreTask
                                {
                                    Name = "Restore"
                                },

                                new DotNetBuildTask
                                {
                                    Name = "Build"
                                },

                                new TestTask
                                {
                                    Name = "Test"
                                }
                            }
                        }
                    }
                }
            };

            string yamlRelativeFilePath = "../../../../.github/workflows/build.yml";
            string yamlFullPath = System.IO.Path.GetFullPath(yamlRelativeFilePath);
            FileInfo yamlDefinition = new FileInfo(yamlFullPath);

            if (!yamlDefinition.Directory.Exists)
            {
                yamlDefinition.Directory.Create();
            }

            adotNetClient.SerializeAndWriteToFile(
                adoPipeline: githubPipeline,
                path: yamlRelativeFilePath);
        }
    }
}
