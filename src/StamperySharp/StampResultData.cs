using Newtonsoft.Json;
using System;

namespace StamperySharp
{
    public partial class StampResultData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("receipts")]
        public Receipts Receipts { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}