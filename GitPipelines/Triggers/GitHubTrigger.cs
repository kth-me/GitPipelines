using System.Collections.Generic;
using GitPipelines.Interfaces;
using YamlDotNet.Serialization;

namespace GitPipelines.Triggers
{
    public class GitHubTrigger : ITrigger
    {
        [YamlMember(Alias = "push")]
        public PushPull Push { get; set; }

        [YamlMember(Alias = "pull_request")]
        public PushPull Pull { get; set; }

        [YamlMember(Alias = "schedule")]
        public object Schedule { get; set; }

        public class PushPull
        {

            [YamlMember(Alias = "branches")]
            public List<string> Branches { get; set; }

            [YamlMember(Alias = "branches-ignore")]
            public List<string> IgnoreBranches { get; set; }

            [YamlMember(Alias = "paths")]
            public List<string> Paths { get; set; }

            [YamlMember(Alias = "paths-ignore")]
            public List<string> IgnorePaths { get; set; }

            [YamlMember(Alias = "tags")]
            public List<string> Tags { get; set; }

            [YamlMember(Alias = "tags-ignore")]
            public List<string> IgnoreTags { get; set; }

            [YamlMember(Alias = "types")]
            public List<string> Types { get; set; }
        }
    }
}
