using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
using System.Text;

namespace StamperySharp
{
    public class StamperySharpClient
    {
        public string ApiEndpoint { get; set; } = "https://api-prod.stampery.com";

        public string ClientId { get; set; }
        public string Secret { get; set; }

        public StamperySharpClient(string clientId, string secret)
        {
            ClientId = clientId;
            Secret = secret;
        }

        public StampResult Stamp(string hash)
        {
            var result = new StampResult();

            var restClient = new RestClient(ApiEndpoint);

            var request = new RestRequest("stamps", Method.POST);
            string jsonToSend = JsonConvert.SerializeObject(new StampRequest { Hash = hash });

            request.AddHeader("Authorization", Auth());
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", jsonToSend, ParameterType.RequestBody);

            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request);

            try
            {
                result = JsonConvert.DeserializeObject<StampResult>(response.Content);
            }
            catch (Exception ex)
            {
                return new StampResult { Error = response.StatusCode + " - " + ex.Message };
            }

            return result;
        }

        public string Auth()
        {
            return $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{Secret}"))}";
        }
    }
}
