
using System.Collections.Generic;
using GitPipelines.Interfaces;
using YamlDotNet.Serialization;

namespace GitPipelines.Jobs
{
    public class GitHubJob : IJob
    {
        [YamlMember(Alias = "strategy")]
        public Strategy Strategy { get; set; }
        
        // needs to be runs-on
        [YamlMember(Alias ="runs-on")]
        public string RunsOn { get; set; }

        /// <summary>
        /// List of other job's by key that has to be completed before this job runs.
        /// </summary>
        [YamlMember(Alias ="needs")]
        public List<string> Needs { get; set; }

        /// <summary>
        /// Gets or sets local environment variable for the running job.
        /// </summary>
        [YamlMember(Alias = "env")]
        public Dictionary<string, string> EnvironmentVariables;

        /// <summary>
        /// List of steps that the github job runs in the pipeline
        /// </summary>
        [YamlMember(Alias = "steps")]
        public List<GitHubStep> Steps;

        public GitHubJob(Job value)
        {
            RunsOn = value.Image;
            Strategy = new Strategy();
            EnvironmentVariables = value.environmentVariables;
            Needs = new List<string>();
        }

        public void clear()
        {
            if (Strategy.matrix.Count == 0)
            {
                Strategy = null;
            }

            if (Needs.Count == 0)
            {
                Needs = null;
            }

            if (EnvironmentVariables.Count == 0)
            {
                EnvironmentVariables = null;
            }
        }
    }
}
