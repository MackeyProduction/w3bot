using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database
{
    internal static class Connection
    {
        private static HttpClient _httpClient;
        internal const string ENDPOINT = "http://127.0.0.1:8000/api";
        internal static string TOKEN;

        static Connection()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
            }
        }

        internal static async Task<HttpResponseMessage> GetRequest(string endpoint)
        {
            if (Connection.TOKEN != null)
            {
                var values = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + Connection.TOKEN },
                };

                return await SendWithHeader(endpoint, values, HttpMethod.Get);
            }

            return await _httpClient.GetAsync($"{ENDPOINT}/{endpoint}");
        }

        internal static async Task<HttpResponseMessage> PostRequest(string endpoint, Dictionary<string, string> data, bool header = false)
        {
            var content = new FormUrlEncodedContent(data);

            if (header)
            {
                return await SendWithHeader(endpoint, data, HttpMethod.Post);
            }

            var response = await _httpClient.PostAsync($"{ENDPOINT}/{endpoint}", content);
            
            return response;
        }

        private static async Task<HttpResponseMessage> SendWithHeader(string endpoint, Dictionary<string, string> data, HttpMethod method)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage(method, $"{ENDPOINT}/{endpoint}");

            // adding dictionary data to header
            if (data.Count > 0)
            {
                foreach (KeyValuePair<string, string> dictionary in data)
                {
                    request.Headers.Add(dictionary.Key, dictionary.Value);
                }
            }

            return await _httpClient.SendAsync(request);
        }
    }
}
