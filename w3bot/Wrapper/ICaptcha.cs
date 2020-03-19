using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Util;

namespace w3bot.Wrapper
{
    /// <summary>
    /// w3bot interface for captcha solving.
    /// </summary>
    public interface ICaptcha
    {
        /// <summary>
        /// Sends a solve request to the server.
        /// </summary>
        /// <param name="method">The solve method.</param>
        /// <param name="delaySeconds">The maximum delay in seconds of waiting for a response.</param>
        /// <param name="args">The arguments for the post request.</param>
        /// <returns>Returns an captcha result with the captcha response and success status.</returns>
        Task<CaptchaResult> Solve(string method, int delaySeconds, params KeyValuePair<string, string>[] args);

        /// <summary>
        /// Sends a solve request to the server.
        /// </summary>
        /// <param name="method">The solve method.</param>
        /// <param name="delaySeconds">The maximum delay in seconds of waiting for a response.</param>
        /// <param name="httpContent">The http content for the post request.</param>
        /// <returns>Returns an captcha result with the captcha response and success status.</returns>
        Task<CaptchaResult> Solve(string method, int delaySeconds, MultipartFormDataContent httpContent);
    }
}
