using System;
using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class ReceiptResultData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("receipts")]
        public ReceiptsData Receipts { get; set; }
    }
}
