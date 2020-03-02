
using System.Collections.Generic;
using GitPipelines.Interfaces;

namespace GitPipelines.Constructors
{
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
