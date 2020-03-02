
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
         
        public Dictionary<string, GitHubJob> jobs { get; set; }
        public Dictionary<string, string> env;


        public GitHubPipeline(Pipeline pipeline)
        {
            name = pipeline.name;
            jobs = new Dictionary<string, GitHubJob>();
            env = pipeline.environmentVariables;

            foreach (var job in pipeline.Jobs)
            {
                jobs.Add(job.Key,new GitHubJob(job.Value));
            }
        }        
    }
}
