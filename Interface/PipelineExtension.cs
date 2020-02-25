
namespace GitPipelines.Interface
{
    using YamlDotNet.Serialization;

    public static class PipelineExtension
    {
        
        static readonly ISerializer YamlSerializer = new Serializer();

        /// <summary>
        /// Converts Pipeline interface/object into executable YAML.
        /// </summary>
        /// <param name="pipeline">The pipeline that will run the yaml.</param>
        /// <returns>Yaml instructions that the piplines use to execute</returns>
        public static string ToYaml(this IPipeline pipeline)
        {
            return YamlSerializer.Serialize(pipeline);
        }
    }
}
