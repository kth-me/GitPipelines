
namespace GitPipelines
{
    using GitPipelines.Interface;
    using GitPipelines.Job;
    using System.Collections.Generic;

    public class Pipeline : IPipeline
    {
        public enum Triggers
        {
            Commit,
            Fork,
            Pull,
            Push            
        }

        public List<Triggers> triggers { get; set; }
        public Dictionary<string, IJob> Jobs { get; set; }
        public Pipeline() { }

        public AzurePipeline AzurePipeline() { return new AzurePipeline(this); }
        public BitBucketPipeline BitBucketPipeline() { return new BitBucketPipeline(this); }
        public GitHubPipeline GitHubPipeline() { return new GitHubPipeline(this); }
        public GitLabPipeline GitLabPipeline() { return new GitLabPipeline(this); }
    }
}
