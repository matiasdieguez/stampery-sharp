using Newtonsoft.Json;

namespace StamperySharp
{
    public partial class ReceiptResult
    {
        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("result")]
        public ReceiptResultData[] Result { get; set; }
    }
}
