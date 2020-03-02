
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

        public Dictionary<string, string> env;

        public GitHubJob(Job value)
        {
            RunsOn = value.Image;
            strategy = new Strategy();
            env = value.environmentVariables;
        }
    }
}
