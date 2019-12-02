using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Core.Database.Repository
{
    abstract class AbstractHttpRepository
    {
        private HttpClient _httpClient;
        private Dictionary<string, string> headers = new Dictionary<string, string>();

        protected const string ENDPOINT = "http://127.0.0.1:8000/api";

        protected bool IsReady { get; }
        protected string Token { get; set; }
        protected bool IsTokenAvailable { get; set; }
        protected bool IsTokenExpired { get; set; }

        protected AbstractHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected void AddHeader(string headerType, string headerValue)
        {
            headers.Add(headerType, headerValue);
        }

        protected void RemoveHeader(string headerType)
        {
            headers.Remove(headerType);
        }

        protected KeyValuePair<string, string> GetHeader(string headerType)
        {
            return headers.Where(type => type.Key == headerType).FirstOrDefault();
        }

        protected async Task<HttpResponseMessage> Fetch(string endpoint)
        {
            return await SendRequest(endpoint, HttpMethod.Get);
        }

        protected async Task<HttpResponseMessage> Post(string endpoint, Dictionary<string, string> content = null)
        {
            return await SendRequest(endpoint, HttpMethod.Post, content);
        }

        protected async Task<HttpResponseMessage> Put(string endpoint, Dictionary<string, string> content = null)
        {
            return await SendRequest(endpoint, HttpMethod.Put, content);
        }

        protected async Task<HttpResponseMessage> SendRequest(string endpoint, HttpMethod method, Dictionary<string, string> content = null)
        {
            // set application json header for request
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage result;
            try
            {
                var request = new HttpRequestMessage(method, $"{endpoint}");

                // send data with content
                if (content != null)
                {
                    var encodedContent = new FormUrlEncodedContent(content);
                    request.Content = encodedContent;
                }

                if (headers.Count > 0)
                {
                    foreach (KeyValuePair<string, string> dictionary in headers)
                    {
                        request.Headers.Add(dictionary.Key, dictionary.Value);
                    }
                }

                result = await _httpClient.SendAsync(request);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        internal bool CheckTokenStatus(string token)
        {
            if (token.Equals(""))
            {
                throw new ArgumentException("The token string is empty. Please set a valid token.");
            }

            var bearerHeader = GetBearerHeader(token);

            if (GetHeader("Authorization").Key == null)
            {
                AddHeader(bearerHeader.FirstOrDefault().Key, bearerHeader.FirstOrDefault().Value);
            }

            var receivedData = Post($"{ENDPOINT}/user/status");

            if (receivedData.Result.IsSuccessStatusCode && receivedData.IsCompleted)
            {
                if (receivedData.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    IsTokenAvailable = true;
                    IsTokenExpired = false;

                    return true;
                }

                if (receivedData.Result.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    IsTokenAvailable = false;
                    IsTokenExpired = true;
                }
            }

            return false;
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

        private Dictionary<string, string> GetBearerHeader(string token)
        {
            var values = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + token },
                };

            return values;
        }
    }
}
