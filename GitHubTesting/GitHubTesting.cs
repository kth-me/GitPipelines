
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
            pipeline.Jobs.Add("Build", new Job{});
            Console.WriteLine(pipeline.GitHubPipeline().ToYaml());
            Console.WriteLine(pipeline.GitHubPipeline().ToJson());
        }
    }
}