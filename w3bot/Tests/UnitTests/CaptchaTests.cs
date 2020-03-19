using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using w3bot.Api;
using w3bot.Wrapper;

namespace w3bot.Tests.UnitTests
{
    [TestClass]
    public class CaptchaTests
    {
        [TestMethod]
        public async Task SolveTextCaptcha_Solve_ReturnsTrue()
        {
            var httpClient = new HttpClient();
            var captchaAdapter = new TwoCaptchaAdapter(httpClient);
            var captcha = new Captcha(captchaAdapter);

            var captchaResult = await captcha.SolveTextCaptcha("Twenty one, 7 and 40: the 3rd number is?");

            Assert.IsTrue(captchaResult.Success);
        }

        [TestMethod]
        public async Task SolveImageCaptcha_Solve_ReturnsTrue()
        {
            var httpClient = new HttpClient();
            var captchaAdapter = new TwoCaptchaAdapter(httpClient);
            var captcha = new Captcha(captchaAdapter);

            var captchaResult = await captcha.SolveNormalCaptcha("data:image/jpeg;base64,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");

            Assert.IsTrue(captchaResult.Success);
        }

        [TestMethod]
        public async Task SolveRecaptchaV2_Solve_ReturnsTrue()
        {
            var httpClient = new HttpClient();
            var captchaAdapter = new TwoCaptchaAdapter(httpClient);
            var captcha = new Captcha(captchaAdapter);

            var captchaResult = await captcha.SolveRecaptchaV2("6Le-wvkSAAAAAPBMRTvw0Q4Muexq9bi0DJwx_mJ-", "https://www.google.com/recaptcha/api2/demo");

            Assert.IsTrue(captchaResult.Success);
        }
    }
}
