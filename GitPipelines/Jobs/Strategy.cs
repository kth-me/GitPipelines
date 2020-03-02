using System.Collections.Generic;

namespace GitPipelines.Jobs
{
    public class Strategy
    {
        public Dictionary<string, List<string>> matrix { get; set; }
        public Strategy()
        {
            matrix = new Dictionary<string, List<string>>();
        }
    }
}