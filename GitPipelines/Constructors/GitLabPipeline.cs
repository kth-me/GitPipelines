

namespace GitPipelines
{
    using System.Collections.Generic;
    using GitPipelines.Interface;
    using GitPipelines.Job;

    /// <summary>
    /// Class that is used to define how GitLab handles their pipelines.
    /// </summary>
    public class GitLabPipeline : IPipeline
    {
        public Dictionary<string, IJob> Jobs { get; set; }

        public GitLabPipeline(Pipeline pipeline)
        {
        }
    }
}
