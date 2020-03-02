
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
        public void Test1()
        {
            var pipeline = new Pipeline();
            pipeline.environmentVariables.Add("GITHUB_PACKAGES_TOKEN", "${ { secrets.GITHUB_PACKAGES_TOKEN } }");
            pipeline.environmentVariables.Add("GITHUB_PACKAGES_USER", "${ { secrets.GITHUB_PACKAGES_USER } }");
            var job = new Job
            {
                Image = "${{ matrix.os }}"
            };
            job.environmentVariables.Add("GITHUB_PACKAGES_TOKEN", "${ { secrets.GITHUB_PACKAGES_TOKEN } }");
            job.environmentVariables.Add("GITHUB_PACKAGES_USER", "${ { secrets.GITHUB_PACKAGES_USER } }");
            pipeline.Jobs.Add("Build", job);
            var github = pipeline.GitHubPipeline();
            var f = github.jobs.First();
            var os = new List<string>();
            os.Add("ubuntu-latest");
            os.Add("windows-latest");
            os.Add("macos-latest");
            f.Value.strategy.matrix.Add("os",os);

            Console.WriteLine(github.ToYaml());
            Console.WriteLine(github.ToJson());
        }
    }
}