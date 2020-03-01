
namespace GitPipelines
{
    using GitPipelines.Interface;
    using GitPipelines.Job;
    using System.Collections.Generic;

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
            

            foreach (var job in pipeline.Jobs)
            {
                Jobs.Add(job.Key,new GitHubJob(job.Value));
            }
        }        
    }
}
