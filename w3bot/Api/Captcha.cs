using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace w3bot.Api
{
    public class Captcha
    {
        private string API_KEY = "842f78c00ae6a6d941d5d2acdc6bcdf9";
        private string CAPTCHA_NOT_READY = "CAPCHA_NOT_READY";
        private string _pageUrl = "";
        private Dictionary<string, string> _captchaResponse = new Dictionary<string, string>();

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
        /// Use the IsReady property and the Retrieve method to retrieve the response of the captcha.
        /// </summary>
        /// <param name="captcha">The text captcha for solving.</param>
        public void SolveTextCaptcha(string captcha)
        {

        }

        /// <summary>
        /// Sends a solve request for captchas with an image.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// Use the IsReady property and the Retrieve method to retrieve the response of the captcha.
        /// </summary>
        /// <param name="base64">The base64 path string from the image.</param>
        public void SolveNormalCaptcha(string base64)
        {
            
        }

        /// <summary>
        /// Sends a solve request for captchas with an image.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// Use the IsReady property and the Retrieve method to retrieve the response of the captcha.
        /// </summary>
        /// <param name="captcha">The bitmap for solving.</param>
        public void SolveNormalCaptcha(Bitmap captcha)
        {
            
        }

        /// <summary>
        /// Sends a solve request for google reCAPTCHAs.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// Use the IsReady property and the Retrieve method to retrieve the response of the captcha.
        /// </summary>
        /// <param name="googleKey">The googleKey of the reCAPTCHA.</param>
        /// <param name="pageUrl">The pageUrl of the reCAPTCHA.</param>
        public void SolveRecaptchaV2(string googleKey, string pageUrl)
        {
            // avoid multiple requests
            if (_pageUrl == pageUrl)
                return;

            string requestUrl = "https://2captcha.com/in.php?key=" + API_KEY + "&method=userrecaptcha&googlekey=" + googleKey + "&pageurl=" + pageUrl + "&json=1";

            var captchaRequest = GetCaptchaPayload(requestUrl);
            if (IsReady)
                GetResponse("http://2captcha.com/res.php?key=" + API_KEY + "&action=get&id=" + captchaRequest.Request + "&json=1", "reCaptchaV2", 20000);
            
            _pageUrl = pageUrl;
        }

        /// <summary>
        /// Sends a solve request for rotating captchas.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// Use the IsReady property and the Retrieve method to retrieve the response of the captcha.
        /// </summary>
        /// <param name="base64Urls">The base64 path strings with all rotating images.</param>
        public void SolveRotateCaptcha(string[] base64Urls)
        {

        }

        /// <summary>
        /// Sends a solve request for rotating captchas.
        /// NOTE: The response time for retrieving the result could be between 5 and 10 seconds.
        /// Use the IsReady property and the Retrieve method to retrieve the response of the captcha.
        /// </summary>
        /// <param name="rotatingImages">The bitmaps with rotating images.</param>
        public void SolveRotateCaptcha(Bitmap[] rotatingImages)
        {

        }

        /// <summary>
        /// The response of the solved captchas.
        /// </summary>
        /// <returns>Returns an dictionary of the captcha response, otherwise returns null.</returns>
        public Dictionary<string, string> Retrieve()
        {
            return _captchaResponse;
        }

        private CaptchaPayload GetCaptchaPayload(string requestUrl)
        {
            IsReady = false;
            CaptchaPayload captchaPayload;
            var request = WebRequest.Create(requestUrl);
            var responseStream = request.GetResponse().GetResponseStream();
            dynamic json;

            // request 2captcha for solving the captcha.
            using (var reader = new StreamReader(responseStream))
            {
                var response = reader.ReadToEnd();

                if (!IsValidJson(response))
                    response = "{\"status\":0,\"request\":\"" + response + "\"}";

                try
                {
                    json = JsonConvert.DeserializeObject(response);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                captchaPayload = new CaptchaPayload
                {
                    Status = (string)json.status ?? "",
                    Request = (string)json.request ?? "",
                };
                IsReady = true;
            }

            return captchaPayload;
        }

        private Dictionary<string, string> GetResponse(string url, string type, int waitTimeInMs = 5000)
        {
            IsSolved = false;
            CaptchaPayload captchaResponse = null;
            var tries = 0;

            // retrieve response of 2captcha
            while (tries < 3)
            {
                captchaResponse = GetCaptchaPayload(url);

                // is ready?
                if (captchaResponse.Status == "1" || captchaResponse.Request != CAPTCHA_NOT_READY)
                    break;

                tries++;
                Thread.Sleep(waitTimeInMs);
            }

            if (captchaResponse.Status != "1")
                throw new ArgumentException($"Something went wrong during the solve request. Error Code: {captchaResponse.Request}");

            if (captchaResponse == null)
                return null;

            _captchaResponse.Add(type, captchaResponse.Request);
            IsSolved = true;

            return _captchaResponse;
        }

        private bool IsValidJson(string strInput)
        {
            JSchema schema;
            JObject parsedObject;

            try
            {
                schema = JSchema.Parse(@"{'type': 'object','properties': {'status': {'type':'integer'},'request': {'type': 'string'}}}");
                parsedObject = JObject.Parse(strInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            if (parsedObject.IsValid(schema))
                return true;

            return false;
        }
    }

    public class CaptchaPayload
    {
        public string Status { get; set; }

        public string Request { get; set; }
    }
}
