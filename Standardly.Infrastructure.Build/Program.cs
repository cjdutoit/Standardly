// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var adotNetClient = new ADotNetClient();

var githubPipeline = new GithubPipeline
{
    Name = ".Net",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "main" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "main" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.WindowsLatest,

            Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Check Out"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Setup Dot Net Version",

                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "7.0.100-preview.1.22110.4",
                        IncludePrerelease = true
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
};

string dotNetYamlRelativeFilePath = "../../../../.github/workflows/dotnet.yml";
string dotNetYamlFullPath = System.IO.Path.GetFullPath(dotNetYamlRelativeFilePath);
FileInfo dotNetYamlDefinition = new FileInfo(dotNetYamlFullPath);

if (!dotNetYamlDefinition.Directory.Exists)
{
    dotNetYamlDefinition.Directory.Create();
}

adotNetClient.SerializeAndWriteToFile(githubPipeline, dotNetYamlRelativeFilePath);