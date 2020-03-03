using System;
using System.Collections.Generic;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace GitPipelines.Jobs
{
    public class GitHubStep
    {
        /// <summary>
        /// Action to use.
        /// Run has to be null if this isn't.
        /// </summary>
        [YamlMember(Alias = "uses")]
        public string Uses { get; set; }

        /// <summary>
        /// Name of the step being run.
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Special multi-line formatting.
        /// Uses has to be null if this isn't.
        /// Scalar Style allows the correct formatting for github.
        /// </summary>
        [YamlMember(Alias = "run", ScalarStyle = ScalarStyle.Literal)]
        public String Run { get; set; }

        /// <summary>
        /// Gets and Sets Step Environment variables.
        /// key's "entrypoint" and "args" are reserved keys.
        /// https://help.github.com/en/actions/reference/workflow-syntax-for-github-actions#jobsjob_idsteps
        /// </summary>
        [YamlMember(Alias = "with")]
        public Dictionary<string, string> EnvironmentVariables { get; set; }

        /// <summary>
        /// declares step to run CLI based on Job's Image
        /// </summary>
        /// <param name="script">CLI script to be used.</param>
        public void SetRun(string script)
        {
            Uses = null;
            Run = script;
        }

        /// <summary>
        /// declares step to run uses case.
        /// </summary>
        /// <param name="uses">Action reference.</param>
        public void SetUses(string uses)
        {
            Run = null;
            Uses = uses;
        }
    }
}