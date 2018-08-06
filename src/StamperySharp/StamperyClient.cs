using Newtonsoft.Json;
using RestSharp;
using System;
using System.Text;

namespace StamperySharp
{
    /// <summary>
    /// StamperyClient
    /// </summary>
    public class StamperyClient
    {
        /// <summary>
        /// ApiEndpoint
        /// </summary>
        public string ApiEndpoint { get; set; } = "https://api-prod.stampery.com";

        /// <summary>
        /// ClientId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Secret
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// StamperyClient
        /// </summary>
        /// <param name="clientId">ClientId</param>
        /// <param name="secret">Secret</param>
        public StamperyClient(string clientId, string secret)
        {
            ClientId = clientId;
            Secret = secret;
        }

        /// <summary>
        /// BuildAuth
        /// </summary>
        /// <returns>Basic Auth header content</returns>
        private string BuildAuth()
        {
            if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(Secret))
                throw new Exception("You must set ClientId and Secret");

            return $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{Secret}"))}";
        }

        /// <summary>
        /// ApiRequest
        /// </summary>
        /// <param name="operation">Operation url</param>
        /// <param name="method">REST Method</param>
        /// <param name="json">Data in json format</param>
        /// <returns></returns>
        private IRestResponse ApiRequest(string operation, Method method, string json = "")
        {
            var restClient = new RestClient(ApiEndpoint);

            var request = new RestRequest(operation, method);

            request.AddHeader("Authorization", BuildAuth());
            request.AddHeader("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(json))
                request.AddParameter("application/json", json, ParameterType.RequestBody);

            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute(request);

            return response;
        }

        /// <summary>
        /// Creates a timestamp for a given SHA-256 hash hexadecimal digest
        /// </summary>
        /// <param name="hash">SHA-256 input hash</param>
        /// <returns>The response an object containing the ID and the time of the stamp. The receipt object gives an estimated time in seconds for the different receipt types (ethereum and bitcoin) to be ready for retrieval.</returns>
        public StampResult Stamp(string hash)
        {
            if (string.IsNullOrEmpty(hash))
                throw new Exception("Hash parameter can't be empty");

            var result = new StampResult();

            string json = JsonConvert.SerializeObject(new StampRequest { Hash = hash });

            var response = ApiRequest("stamps", Method.POST, json);
            result = JsonConvert.DeserializeObject<StampResult>(response.Content);

            return result;
        }

        /// <summary>
        /// Retrieves all receipts (also known as proofs in former Stampery API versions) for a certain stamp.
        /// </summary>
        /// <param name="id">Stamp Id or Hash</param>
        /// <returns>ReceiptResult</returns>
        public ReceiptResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id parameter can't be empty");

            var result = new ReceiptResult();

            var response = ApiRequest($"stamps/{id}", Method.GET);
            result = JsonConvert.DeserializeObject<ReceiptResult>(response.Content);

            return result;
        }

        /// <summary>
        /// Retrieves all stamps made by the requesting client, ordered by date, from newest to oldest, paginated in chunks of 50.
        /// </summary>
        /// <param name="page">Optional page number</param>
        /// <returns>ReceiptResult</returns>
        public ReceiptResult GetAll(int? page = null)
        {
            var result = new ReceiptResult();

            var operation = page.HasValue ? $"stamps?page={page}" : "stamps";

            var response = ApiRequest(operation, Method.GET);
            result = JsonConvert.DeserializeObject<ReceiptResult>(response.Content);

            return result;
        }

        /// <summary>
        /// The Stampery LTS API is compatible with the Opentimestamps (OTS) standard by Peter Todd and contributors.
        /// </summary>
        /// <param name="id">Stamp Id</param>
        /// <returns>The response is a binary application/octet-stream byte array containing the bitcoin receipt in .ots format</returns>
        public byte[] GetOtsFile(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id parameter can't be empty");

            var response = ApiRequest($"stamps/{id}.ots", Method.GET);

            return response.RawBytes;
        }

        /// <summary>
        /// The Stampery LTS API can generate cute PDF human-readable certificates. For environmental reasons we discourage you from printing them unless strictly necessary.
        /// </summary>
        /// <param name="id">Stamp Id</param>
        /// <returns>The response is a binary application/pdf byte array</returns>
        public byte[] GetPdfFile(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id parameter can't be empty");

            var response = ApiRequest($"stamps/{id}.pdf", Method.GET);

            return response.RawBytes;
        }
    }
}
