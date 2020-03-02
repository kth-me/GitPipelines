
using GitPipelines.Constructors;
using GitPipelines.Interfaces;

namespace GitPipelines
{
    using System.Collections.Generic;


    public class Pipeline : IPipeline
    {
        public string Name { get; set; }
        public List<ITrigger> Triggers { get; set; }
        public Dictionary<string, Job> Jobs { get; set; }
        public Dictionary<string, string> EnvironmentVariables;

        public Pipeline()
        {
            Jobs = new Dictionary<string, Job>();
            Triggers = new List<ITrigger>();
            EnvironmentVariables = new Dictionary<string, string>();
        }

        public AzurePipeline AzurePipeline() { return new AzurePipeline(this); }
        public BitBucketPipeline BitBucketPipeline() { return new BitBucketPipeline(this); }
        public GitHubPipeline GitHubPipeline() { return new GitHubPipeline(this); }
        public GitLabPipeline GitLabPipeline() { return new GitLabPipeline(this); }
    }
}
