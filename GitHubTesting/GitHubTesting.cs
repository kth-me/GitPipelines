
using System.Collections.Generic;

namespace PipelinesTesting
{
    using NUnit.Framework;
    using GitPipelines;
    using GitPipelines.Interfaces;
    using System;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GitHubBuildable()
        {
            var pipeline = new Pipeline();
            pipeline.EnvironmentVariables.Add("GITHUB_PACKAGES_TOKEN", "${{ secrets.GITHUB_PACKAGES_TOKEN }}");
            pipeline.EnvironmentVariables.Add("GITHUB_PACKAGES_USER", "${{ secrets.GITHUB_PACKAGES_USER }}");
            
            var restore = new Job
            {
                Image = "${{ matrix.os }}"
            };
            
            var build = new Job
            {
                Image = "${{ matrix.os }}"
            };
            build.environmentVariables.Add("GITHUB_PACKAGES_TOKEN", "${{ secrets.GITHUB_PACKAGES_TOKEN }}");
            build.environmentVariables.Add("GITHUB_PACKAGES_USER", "${{ secrets.GITHUB_PACKAGES_USER }}");
            
            pipeline.Jobs.Add("Restore",restore);
            //pipeline.Jobs.Add("Build", build);
            
            var github = pipeline.GitHubPipeline();
            github.Name = "dotnetcore";
            var f = github.Jobs["Restore"];
            //f.Needs.Add("Restore");
            var os = new List<string>
            {
                "ubuntu-latest",
                "windows-latest",
                "macos-latest"
            };
            f.Strategy.matrix.Add("os",os);
            f.Steps = new List<GitPipelines.Jobs.GitHubStep>();

            f.Steps.AddRange(
                new List<GitPipelines.Jobs.GitHubStep>{
                    new GitPipelines.Jobs.GitHubStep
                    {
                        Uses = "actions/checkout@v2"
                    },
                    new GitPipelines.Jobs.GitHubStep
                    {
                        Name = "Setup .NET Core",
                        Uses = "actions/setup-dotnet@v1",
                        EnvironmentVariables =
                        new Dictionary<string, string>(
                             new List<KeyValuePair<string,string>>{
                             new KeyValuePair<string, string>( "dotnet-version", "3.1.100")}
                        )
                    }
                }
             );
            
            f.Steps.Add(
                new GitPipelines.Jobs.GitHubStep
                {
                    Name = "restore",
                    Run = "dotnet restore\ndotnet build",
                });
            github.Clear();
            Console.WriteLine(github.ToYaml());
            Console.WriteLine(github.ToJson());
            
        }
    }
}