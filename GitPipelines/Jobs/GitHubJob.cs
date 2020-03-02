
using System.Collections.Generic;
using GitPipelines.Interfaces;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace GitPipelines.Jobs
{
    public class GitHubJob : IJob
    {
        public Strategy strategy { get; set; }
        
        // needs to be runs-on
        [YamlMember(Alias ="runs-on")]
        public string RunsOn { get; set; }

        /// <summary>
        /// List of other job's by key that has to be completed before this job runs.
        /// </summary>
        [YamlMember(Alias ="needs")]
        public List<string> Needs { get; set; }

        public Dictionary<string, string> env;

        public GitHubJob(Job value)
        {
            RunsOn = value.Image;
            strategy = new Strategy();
            env = value.environmentVariables;
            Needs = new List<string>();
        }

        public void clear()
        {
            if (strategy.matrix.Count == 0)
            {
                strategy = null;
            }

            if (Needs.Count == 0)
            {
                Needs = null;
            }

            if (env.Count == 0)
            {
                env = null;
            }
        }
    }
}
