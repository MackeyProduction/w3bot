using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Repository
{
    abstract class AbstractHttpRepository
    {
        private HttpClient _httpClient;
        protected const string ENDPOINT = "http://127.0.0.1:8000/api";

        protected bool IsReady { get; }

        protected AbstractHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<HttpResponseMessage> Fetch(string endpoint)
        {
            HttpResponseMessage result;
            try
            {
                result = await _httpClient.GetAsync($"{endpoint}");
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        protected async Task<HttpResponseMessage> Post(string endpoint, Dictionary<string, string> data)
        {
            return null;
        }

        protected async Task<HttpResponseMessage> Pull(string endpoint)
        {
            return null;
        }

        protected async Task<string> HttpContentAsString(HttpContent content)
        {
            return await content.ReadAsStringAsync();
        }

        protected async Task<object> HttpContentAsJsonObject(HttpContent content)
        {
            var result = await content.ReadAsStringAsync();
            dynamic proxyResult = JsonConvert.DeserializeObject(result);
            
            return proxyResult;
        }
    }
}
