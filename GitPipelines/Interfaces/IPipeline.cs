
using System.Collections.Generic;

namespace GitPipelines.Interfaces
{
    /// <summary>
    /// Interface of pipelines defining how data is stored
    /// </summary>
    public interface IPipeline
    {
        Dictionary<string, IJob> Jobs { get; set; }

    }
}
