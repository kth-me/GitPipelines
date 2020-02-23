using System;

namespace GitPipelines
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPipeline
    {

        /// <summary>
        /// Converts the pipeline object to yaml that is used by piplines.
        /// </summary>
        /// <returns></returns>
        string ToYaml();
    }
}
