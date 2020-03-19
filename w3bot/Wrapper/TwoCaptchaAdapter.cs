using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Util;

namespace w3bot.Wrapper
{
    class TwoCaptchaAdapter : ICaptcha
    {
        private const string API_KEY = "842f78c00ae6a6d941d5d2acdc6bcdf9";
        private const string CAPTCHA_NOT_READY = "CAPCHA_NOT_READY";
        private const string URL = "https://2captcha.com/";
        private const int MAX_REQUESTS = 100;

        private HttpClient _httpClient;
        private int _requests = 0;

        public TwoCaptchaAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CaptchaResult> Solve(string method, int delaySeconds, params KeyValuePair<string, string>[] args)
        {
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("key", API_KEY),
                new KeyValuePair<string, string>("method", method),
                new KeyValuePair<string, string>("json", "1")
            };

            postData.AddRange(args);

            var inResponse = await _httpClient.PostAsync(URL + "in.php", new FormUrlEncodedContent(postData));
            return await Solve(inResponse, delaySeconds);
        }

        public async Task<CaptchaResult> Solve(string method, int delaySeconds, MultipartFormDataContent httpContent)
        {
            httpContent.Add(new StringContent(API_KEY), "key");
            httpContent.Add(new StringContent(method), "method");
            httpContent.Add(new StringContent("1"), "json");

            var inResponse = await _httpClient.PostAsync(URL + "in.php", httpContent);
            return await Solve(inResponse, delaySeconds);
        }

        private async Task<CaptchaResult> Solve(HttpResponseMessage inResponse, int delaySeconds = 5)
        {
            var balance = double.Parse((await GetBalance()).Response);
            if (balance <= 0.0 || _requests >= MAX_REQUESTS)
            {
                throw new Exception("Maximum of requests reached. Please try later again.");
            }

            var inJson = await inResponse.Content.ReadAsStringAsync();

            var @in = JsonConvert.DeserializeObject<CaptchaResponse>(inJson);
            if (@in.Status == 0)
            {
                return new CaptchaResult(false, @in.Request);
            }

            await Task.Delay(delaySeconds * 1000);

            return await GetResponse(@in.Request);
        }

        private async Task<CaptchaResult> GetResponse(string solveId, int delaySeconds = 5)
        {
            var apiKeySafe = Uri.EscapeUriString(API_KEY);

            while (true)
            {
                var resJson = await _httpClient.GetStringAsync(URL + $"res.php?key={apiKeySafe}&id={solveId}&action=get&json=1");

                var res = JsonConvert.DeserializeObject<CaptchaResponse>(resJson);
                if (res.Status == 0)
                {
                    if (res.Request == CAPTCHA_NOT_READY)
                    {
                        await Task.Delay(delaySeconds * 1000);
                        continue;
                    }

                    return new CaptchaResult(false, res.Request);
                }

                _requests++;
                return new CaptchaResult(true, res.Request);
            }
        }

        private async Task<CaptchaResult> GetBalance()
        {
            var getData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("key", API_KEY),
                new KeyValuePair<string, string>("action", "getbalance"),
                new KeyValuePair<string, string>("json", "1")
            };

            var inResponse = await _httpClient.PostAsync(URL + "res.php", new FormUrlEncodedContent(getData));
            var inJson = await inResponse.Content.ReadAsStringAsync();

            var @in = JsonConvert.DeserializeObject<CaptchaResponse>(inJson);
            if (@in.Status == 0)
            {
                return new CaptchaResult(false, @in.Request);
            }

            return new CaptchaResult(true, @in.Request);
        }
    }
}
