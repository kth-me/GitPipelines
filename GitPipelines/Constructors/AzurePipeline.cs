
using System.Collections.Generic;
using GitPipelines.Interfaces;

namespace GitPipelines.Constructors
{
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
