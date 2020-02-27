
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
        List<string> on { get; set; }
        private static readonly string[] triggers = { "commit", "fork", "pull", "push"};
        
        public Dictionary<string, IJob> Jobs { get; set; }


        public GitHubPipeline(Pipeline pipeline)
        {
            foreach (var trigger in pipeline.triggers)
            {
               on.Add(triggers[(int)trigger]);
            }

            foreach (var job in pipeline.Jobs)
            {
                Jobs.Add(job.Key,new GitHubJob(job.Value));
            }
        }        
    }
}
