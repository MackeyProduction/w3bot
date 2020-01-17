using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Api;

namespace w3bot.Tests.UnitTests
{
    [TestClass]
    public class CaptchaTests
    {
        [TestMethod]
        public void SolveRecaptchaV2_Request_ReturnsValidCaptchaResponse()
        {
            var captcha = new Captcha();

            captcha.SolveRecaptchaV2("6Le-wvkSAAAAAPBMRTvw0Q4Muexq9bi0DJwx_mJ-", "https://www.google.com/recaptcha/api2/demo");

            Assert.IsTrue(captcha.IsSolved);
        }
    }
}
