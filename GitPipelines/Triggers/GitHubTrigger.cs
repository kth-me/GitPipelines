
using System;
using System.Collections.Generic;
using System.Text;
  
namespace GitPipelines.Triggers
{using GitPipelines.Interface;
    public class GitHubTrigger : ITrigger
    {
        public List<string> Branches { get; set; }
    }
}
