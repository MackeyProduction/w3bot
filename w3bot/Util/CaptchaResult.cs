using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Util
{
    /// <summary>
    /// w3bot captcha result struct.
    /// </summary>
    public struct CaptchaResult
    {
        /// <summary>
        /// Returns true if the solve process is successful, otherwise returns false.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The response code of the captcha.
        /// </summary>
        public string Response { get; set; }

        public CaptchaResult(bool success, string response)
        {
            Success = success;
            Response = response;
        }
    }
}
