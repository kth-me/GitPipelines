using System.Collections.Generic;

namespace GitPipelines
{
    using GitPipelines.Interfaces;
    /// <summary>
    /// Not an interface as it's used 
    /// </summary>
    public class Job : IJob
    {
        public string Image { get; set; }
        public Dictionary<string, string> environmentVariables;

        public Job()
        {
            environmentVariables = new Dictionary<string, string>();
        }
    }
}
