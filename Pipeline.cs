
namespace GitPipelines
{
    using GitPipelines.Interface;

    public class Pipeline:IPipeline
    {

        public Pipeline() { }

        public AzurePipeline AzurePipeline() { return new AzurePipeline(this); }
        public BitBucketPipeline BitBucketPipeline() { return new BitBucketPipeline(this); }
        public GitHubPipeline GitHubPipeline() { return new GitHubPipeline(this); }
        public GitLabPipeline GitLabPipeline() { return new GitLabPipeline(this); }
    }
}
