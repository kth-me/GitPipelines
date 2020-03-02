
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
        public string RunsOn { get; set; }
        
        /// <summary>
        /// List of other job's by key that has to be completed before this job runs.
        /// </summary>
        public List<string> needs { get; set; }

        public Dictionary<string, string> env;

        public GitHubJob(Job value)
        {
            RunsOn = value.Image;
            strategy = new Strategy();
            env = value.environmentVariables;
            needs = new List<string>();
        }

        public void clear()
        {
            if (strategy.matrix.Count == 0)
            {
                strategy = null;
            }

            if (needs.Count == 0)
            {
                needs = null;
            }

            if (env.Count == 0)
            {
                env = null;
            }
        }
    }
}
