using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class Anchor
    {
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; set; }
    }
}
