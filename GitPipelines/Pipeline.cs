
using GitPipelines.Constructors;
using GitPipelines.Interfaces;

namespace GitPipelines
{
    using System.Collections.Generic;


    public class Pipeline : IPipeline
    {
        public List<ITrigger> Triggers { get; set; }
        public Dictionary<string, IJob> Jobs { get; set; }

        public Pipeline()
        {
            Jobs = new Dictionary<string, IJob>();
            Triggers = new List<ITrigger>();
        }

        public AzurePipeline AzurePipeline() { return new AzurePipeline(this); }
        public BitBucketPipeline BitBucketPipeline() { return new BitBucketPipeline(this); }
        public GitHubPipeline GitHubPipeline() { return new GitHubPipeline(this); }
        public GitLabPipeline GitLabPipeline() { return new GitLabPipeline(this); }
    }
}
