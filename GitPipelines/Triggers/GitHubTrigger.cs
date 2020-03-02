
using System;
using System.Collections.Generic;
using System.Text;
using GitPipelines.Interfaces;

namespace GitPipelines.Triggers
{
    public class GitHubTrigger : ITrigger
    {
        public List<string> Branches { get; set; }
    }
}
