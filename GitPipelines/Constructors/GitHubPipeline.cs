
using System.Collections.Generic;
using GitPipelines.Interfaces;
using GitPipelines.Jobs;

namespace GitPipelines.Constructors
{
    /// <summary>
    /// Class that is used to define how GitHub handles their pipelines.
    /// </summary>
    public class GitHubPipeline : IPipeline
    {
        string name;
        List<ITrigger> on { get; set; }
         
        public Dictionary<string, IJob> Jobs { get; set; }


        public GitHubPipeline(Pipeline pipeline)
        {
            Jobs = new Dictionary<string, IJob>();

            foreach (var job in pipeline.Jobs)
            {
                Jobs.Add(job.Key,new GitHubJob(job.Value));
            }
        }        
    }
}
