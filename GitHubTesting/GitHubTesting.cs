
using System.Collections.Generic;
using System.Linq;

namespace PipelinesTesting
{
    using System;
    using NUnit.Framework;
    using GitPipelines;
    using GitPipelines.Interfaces;

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
            pipeline.environmentVariables.Add("GITHUB_PACKAGES_TOKEN", "${{ secrets.GITHUB_PACKAGES_TOKEN }}");
            pipeline.environmentVariables.Add("GITHUB_PACKAGES_USER", "${{ secrets.GITHUB_PACKAGES_USER }}");
            
            var restore = new Job
            {
                Image = "Ubuntu-latest"
            };
            
            var build = new Job
            {
                Image = "${{ matrix.os }}"
            };
            build.environmentVariables.Add("GITHUB_PACKAGES_TOKEN", "${{ secrets.GITHUB_PACKAGES_TOKEN }}");
            build.environmentVariables.Add("GITHUB_PACKAGES_USER", "${{ secrets.GITHUB_PACKAGES_USER }}");
            
            pipeline.Jobs.Add("Restore",restore);
            pipeline.Jobs.Add("Build", build);
            
            var github = pipeline.GitHubPipeline();
            github.name = "dotnetcore";
            var f = github.jobs["Build"];
            f.Needs.Add("Restore");
            var os = new List<string>();
            os.Add("ubuntu-latest");
            os.Add("windows-latest");
            os.Add("macos-latest");
            f.strategy.matrix.Add("os",os);
            github.clear();
            Console.WriteLine(github.ToYaml());
            Console.WriteLine(github.ToJson());
        }
    }
}