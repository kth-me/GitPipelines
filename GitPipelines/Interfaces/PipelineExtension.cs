
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace GitPipelines.Interfaces
{
    public static class PipelineExtension
    {
        /// <summary>
        /// We want this to be static so numerous instances references the 1 serializer.
        /// This will reduce the over head of spinning one up each time it's called.
        /// </summary>
        private static readonly ISerializer YamlSerializer = new SerializerBuilder()
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
            .Build();

        /// <summary>
        /// Converts Pipeline interface/object into executable YAML.
        /// </summary>
        /// <param name="pipeline">The pipeline that will run the yaml.</param>
        /// <returns>Yaml instructions that the piplines use to execute</returns>
        public static string ToYaml(this IPipeline pipeline)
        {
            return YamlSerializer.Serialize(pipeline);
        }

        /// <summary>
        /// Converts Pipeline interface/object into Template Json
        /// </summary>
        /// <param name="pipeline">The pipeline that would run the template.</param>
        /// <returns>JSON template of the pipeline.</returns>
        public static string ToJson(this IPipeline pipeline)
        {
            return JsonConvert.SerializeObject(pipeline);
        }
    }
}
