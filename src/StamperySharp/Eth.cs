using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class Eth
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("merkleRoot")]
        public string MerkleRoot { get; set; }

        [JsonProperty("proof")]
        public EthProof[] Proof { get; set; }

        [JsonProperty("targetHash")]
        public string TargetHash { get; set; }

        [JsonProperty("anchors")]
        public Anchor[] Anchors { get; set; }
    }
}
