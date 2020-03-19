using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Util
{
    /// <summary>
    /// w3bot captcha response struct.
    /// </summary>
    public struct CaptchaResponse
    {
        /// <summary>
        /// The current status of the captcha.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// The captcha request.
        /// </summary>
        public string Request { get; set; }

        public CaptchaResponse(int status, string request)
        {
            Status = status;
            Request = request;
        }
    }
}
