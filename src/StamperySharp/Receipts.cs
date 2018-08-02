using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class Receipts
    {
        [JsonProperty("eth")]
        public long Eth { get; set; }

        [JsonProperty("btc")]
        public long Btc { get; set; }
    }
}