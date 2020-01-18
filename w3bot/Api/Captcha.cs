using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace w3bot.Api
{
    public class Captcha
    {
        private const string API_KEY = "842f78c00ae6a6d941d5d2acdc6bcdf9";
        private const string CAPTCHA_NOT_READY = "CAPCHA_NOT_READY";
        private const string URL = "https://2captcha.com/";
        private const int MAX_REQUESTS = 100;

        private string _pageUrl = "";
        private CaptchaResult _captchaResponse;
        private HttpClient _httpClient;
        private int _requests = 0;

        public Captcha()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Returns true when the captcha is ready, otherwise returns false.
        /// </summary>
        public bool IsReady { get; set; } = false;

        /// <summary>
        /// Returns true when the captcha is solved, otherwise returns false.
        /// </summary>
        public bool IsSolved { get; set; } = false;

        /// <summary>
        /// Sends a solve request for text captcha.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// </summary>
        /// <param name="captcha">The text captcha for solving.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveTextCaptcha(string captcha)
        {
            return await Solve("textcaptcha", 5,
                new KeyValuePair<string, string>("textcaptcha", captcha));
        }

        /// <summary>
        /// Sends a solve request for captchas with an image.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// </summary>
        /// <param name="imageBase64">The base64 path string from the image.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveNormalCaptcha(string imageBase64)
        {
            return await Solve("base64", 5,
                new KeyValuePair<string, string>("body", imageBase64));
        }

        /// <summary>
        /// Sends a solve request for captchas with an image.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// </summary>
        /// <param name="imageStream">The image stream for solving.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveNormalCaptcha(Stream imageStream)
        {
            var httpContent = new MultipartFormDataContent
            {
                { new StreamContent(imageStream), "file" }
            };

            return await Solve("post", 5, httpContent);
        }

        /// <summary>
        /// Sends a solve request for google reCAPTCHAs.
        /// NOTE: The response time for retrieving the result could be between 20 and 40 seconds.
        /// </summary>
        /// <param name="googleKey">The googleKey of the reCAPTCHA.</param>
        /// <param name="pageUrl">The pageUrl of the reCAPTCHA.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveRecaptchaV2(string googleKey, string pageUrl, bool invisible = false)
        {
            // avoid multiple requests
            if (_pageUrl == pageUrl)
                return _captchaResponse;

            _pageUrl = pageUrl;

            return await Solve("userrecaptcha", 10,
                new KeyValuePair<string, string>("googlekey", googleKey),
                new KeyValuePair<string, string>("pageurl", pageUrl),
                new KeyValuePair<string, string>("invisible", invisible ? "1" : "0"));
        }

        /// <summary>
        /// Sends a solve request for google reCAPTCHAs.
        /// NOTE: The response time for retrieving the result could be between 20 and 40 seconds.
        /// </summary>
        /// <param name="googleKey">The googleKey of the reCAPTCHA.</param>
        /// <param name="pageUrl">The pageUrl of the reCAPTCHA.</param>
        /// <param name="action">The action of the reCAPTCHA.</param>
        /// <param name="minScore">The score needed for resolution. Currently it's almost impossible to get token with score higher than 0.3.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveReCaptchaV3(string googleKey, string pageUrl, string action = "verify", double minScore = 0.4)
        {
            return await Solve("userrecaptcha", 10,
                new KeyValuePair<string, string>("googlekey", googleKey),
                new KeyValuePair<string, string>("pageurl", pageUrl),
                new KeyValuePair<string, string>("action", action),
                new KeyValuePair<string, string>("version", "v3"),
                new KeyValuePair<string, string>("min_score", minScore.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Sends a solve request for rotating captchas.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// </summary>
        /// <param name="imageStreams">The image stream with rotating images.</param>
        /// <param name="rotateAngle">The angle for one rotation step in degrees.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveRotateCaptcha(Stream[] imageStreams, string rotateAngle)
        {
            var httpContent = new MultipartFormDataContent
            {
                { new StringContent(rotateAngle), "angle" }
            };

            for (var i = 0; i < imageStreams.Length; i++)
            {
                httpContent.Add(new StreamContent(imageStreams[i]), "file_" + (i + 1));
            }

            return await Solve("rotatecaptcha", 5, httpContent);
        }

        /// <summary>
        /// Sends a solve request for the fun captcha.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// </summary>
        /// <param name="funCaptchaPublicKey">The public key of the fun captcha.</param>
        /// <param name="pageUrl">The page url of the fun captcha.</param>
        /// <param name="noJavaScript">If javascript is disabled the API will return just the first part of token string.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveFunCaptcha(string funCaptchaPublicKey, string pageUrl, bool noJavaScript = false)
        {
            if (_pageUrl == pageUrl)
                return _captchaResponse;

            _pageUrl = pageUrl;

            return await Solve("funcaptcha", 10,
                new KeyValuePair<string, string>("publickey", funCaptchaPublicKey),
                new KeyValuePair<string, string>("pageurl", pageUrl),
                new KeyValuePair<string, string>("nojs", noJavaScript ? "1" : "0"));
        }

        /// <summary>
        /// Sends a solve request for key captchas.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// </summary>
        /// <param name="userId">The s_s_c_user_id of the key captcha.</param>
        /// <param name="sessionId">The s_s_c_session_id of the key captcha.</param>
        /// <param name="webServerSign">The s_s_c_web_server_sign of the key captcha.</param>
        /// <param name="webServerSign2">The s_s_c_web_server_sign2 of the key captcha.</param>
        /// <param name="pageUrl">The page url of the key captcha.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveKeyCaptcha(string userId, string sessionId, string webServerSign, string webServerSign2, string pageUrl)
        {
            if (_pageUrl == pageUrl)
                return _captchaResponse;

            _pageUrl = pageUrl;

            return await Solve("keycaptcha", 15,
                new KeyValuePair<string, string>("s_s_c_user_id", userId),
                new KeyValuePair<string, string>("s_s_c_session_id", sessionId),
                new KeyValuePair<string, string>("s_s_c_web_server_sign", webServerSign),
                new KeyValuePair<string, string>("s_s_c_web_server_sign2", webServerSign2),
                new KeyValuePair<string, string>("pageurl", pageUrl));
        }

        /// <summary>
        /// Sends a solve request for click captchas.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// </summary>
        /// <param name="imageStream">The image stream for solving.</param>
        /// <param name="task">Text with instruction for solving ReCaptcha. For example: Select images with trees.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveClickCaptcha(Stream imageStream, string task)
        {
            var httpContent = new MultipartFormDataContent
            {
                { new StringContent("1"), "coordinatescaptcha" },
                { new StreamContent(imageStream), "file" },
                { new StringContent(task), "textinstructions" }
            };

            return await Solve("post", 5, httpContent);
        }

        /// <summary>
        /// Sends a solve request for click captchas.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// </summary>
        /// <param name="imageBase64">The base64 path string from the image.</param>
        /// <param name="task">Text with instruction for solving ReCaptcha. For example: Select images with trees.</param>
        /// <returns>Returns the captcha response with success status and response message.</returns>
        public async Task<CaptchaResult> SolveClickCaptcha(string imageBase64, string task)
        {
            return await Solve("base64", 5,
                new KeyValuePair<string, string>("coordinatescaptcha", "1"),
                new KeyValuePair<string, string>("body", imageBase64),
                new KeyValuePair<string, string>("textinstructions", task));
        }

        private async Task<CaptchaResult> Solve(string method, int delaySeconds, params KeyValuePair<string, string>[] args)
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

        private async Task<CaptchaResult> Solve(string method, int delaySeconds, MultipartFormDataContent httpContent)
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

            _captchaResponse = await GetResponse(@in.Request);
            IsSolved = true;
            return _captchaResponse;
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

    public struct CaptchaResponse
    {
        public int Status { get; set; }
        public string Request { get; set; }

        public CaptchaResponse(int status, string request)
        {
            Status = status;
            Request = request;
        }
    }

    public struct CaptchaResult
    {
        public bool Success { get; set; }
        public string Response { get; set; }

        public CaptchaResult(bool success, string response)
        {
            Success = success;
            Response = response;
        }
    }
}
