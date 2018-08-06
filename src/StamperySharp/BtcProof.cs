using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class BtcProof
    {
        [JsonProperty("left", NullValueHandling = NullValueHandling.Ignore)]
        public string Left { get; set; }

        [JsonProperty("right", NullValueHandling = NullValueHandling.Ignore)]
        public string Right { get; set; }
    }
}
