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
        internal static string SESSION_ID;

        static Connection()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                Open();
            }
        }

        internal static void Open()
        {
            try
            {
                var result = GetRequest($"{ENDPOINT}");
            }
            catch (Exception) { }
        }

        internal static void Close()
        {

        }

        internal static async Task<string> GetRequest(string endpoint)
        {
            return await _httpClient.GetStringAsync(endpoint);
        }

        internal static async Task<string> PostRequest(string endpoint, Dictionary<string, string> data)
        {
            var content = new FormUrlEncodedContent(data);
            var response = await _httpClient.PostAsync($"{ENDPOINT}/{endpoint}", content);
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}
