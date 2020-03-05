
using System.Collections.Generic;
using GitPipelines.Interfaces;

namespace GitPipelines.Constructors
{
    /// <summary>
    /// Class that is used to define how Azure handles their pipelines.
    /// </summary>
    public class AWSCodeCommit : IPipeline
    {
        public AWSCodeCommit(Pipeline pipeline)
        {
        }

        public Dictionary<string, IJob> Jobs { get; set; }
    }
}
