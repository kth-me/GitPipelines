


namespace GitPipelines.Interface
{
    using GitPipelines.Job;
    using System.Collections.Generic;

    /// <summary>
    /// Interface of pipelines defining how data is stored
    /// </summary>
    public interface IPipeline
    {
        Dictionary<string, IJob> Jobs { get; set; }

    }
}
