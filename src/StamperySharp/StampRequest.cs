using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class StampRequest
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
