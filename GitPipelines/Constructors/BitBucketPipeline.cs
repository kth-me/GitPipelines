
namespace GitPipelines
{
    using GitPipelines.Interface;
    using GitPipelines.Job;
    using System.Collections.Generic;

    /// <summary>
    /// Class that is used to define how bitbucket handles their pipelines.
    /// </summary>
    public class BitBucketPipeline : IPipeline
    {
        public Dictionary<string, IJob> Jobs { get; set; }

        public BitBucketPipeline(Pipeline pipeline)
        {
        }
    }
}
