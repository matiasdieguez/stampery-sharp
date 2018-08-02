using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class StampResult
    {
        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("result")]
        public StampResultData Result { get; set; }
    }
}