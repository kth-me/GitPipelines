
namespace GitPipelines.Constructors
{
    using System.Collections.Generic;
    using GitPipelines.Interfaces;
    using GitPipelines.Jobs;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Class that is used to define how GitHub handles their pipelines.
    /// </summary>
    public class GitHubPipeline : IPipeline
    {
        /// <summary>
        /// Name appended to the pipeline
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name;

        /// <summary>
        /// Gets and sets Pipeline Triggers
        /// </summary>
        [YamlMember(Alias = "on")]
        public List<ITrigger> On { get; set; }

        /// <summary>
        /// Collection of jobs in the pipelines and description
        /// </summary>
        [YamlMember(Alias = "jobs")]
        public Dictionary<string, GitHubJob> Jobs { get; set; }

        /// <summary>
        /// Gets and Sets Global Environment variables.
        /// </summary>
        [YamlMember(Alias = "env")]
        public Dictionary<string, string> EnvironmentVariables { get; set; }

        /// <summary>
        /// Constructor for Github Specific Pipeline
        /// </summary>
        /// <param name="pipeline">Core Constructor class.</param>
        public GitHubPipeline(Pipeline pipeline)
        {
            Name = pipeline.Name;
            Jobs = new Dictionary<string, GitHubJob>();
            EnvironmentVariables = pipeline.EnvironmentVariables;

            foreach (KeyValuePair<string, Job> job in pipeline.Jobs)
            {
                Jobs.Add(job.Key,new GitHubJob(job.Value));
            }
        }

        public void Clear()
        {
            foreach (KeyValuePair<string, GitHubJob> job in Jobs)
            {
                job.Value.clear();
            }
        }
    }
}
