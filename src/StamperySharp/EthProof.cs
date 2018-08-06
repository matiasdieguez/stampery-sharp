using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class EthProof
    {
        [JsonProperty("left")]
        public string Left { get; set; }
    }
}
