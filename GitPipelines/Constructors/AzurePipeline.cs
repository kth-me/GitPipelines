
namespace GitPipelines
{
    using GitPipelines.Interface;
    using GitPipelines.Job;
    using System.Collections.Generic;

    /// <summary>
    /// Class that is used to define how Azure handles their pipelines.
    /// </summary>
    public class AzurePipeline : IPipeline
    {
        public AzurePipeline(Pipeline pipeline)
        {
        }

        public Dictionary<string, IJob> Jobs { get; set; }
    }
}
