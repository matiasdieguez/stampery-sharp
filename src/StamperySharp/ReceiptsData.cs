using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class ReceiptsData
    {
        [JsonProperty("btc")]
        public Btc Btc { get; set; }

        [JsonProperty("eth")]
        public Eth Eth { get; set; }
    }
}
