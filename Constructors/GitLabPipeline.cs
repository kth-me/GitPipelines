using System;
using System.Collections.Generic;
using System.Text;

namespace GitPipelines
{
    using GitPipelines.Interface;

    /// <summary>
    /// Class that is used to define how GitLab handles their pipelines.
    /// </summary>
    public class GitLabPipeline : IPipeline
    {
        public GitLabPipeline(Pipeline pipeline)
        {
        }
    }
}
