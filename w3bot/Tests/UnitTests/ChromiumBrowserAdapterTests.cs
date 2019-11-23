using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Wrapper;
using CefSharp;
using CefSharp.OffScreen;
using System.IO;

namespace w3bot.Tests.UnitTests
{
    [TestClass]
    public class ChromiumBrowserAdapterTests
    {
        private ChromiumWebBrowser _cbBrowser;

        [TestMethod]
        public void GetBrowser_WhenBrowserInitializedAndIsReady_ReturnsTrue()
        {
            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                settings.BrowserSubprocessPath = "CefSharp.BrowserSubprocess.exe";

                Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
            }

            _cbBrowser = new ChromiumWebBrowser("https://www.google.de/");
            _cbBrowser.BrowserInitialized += CbBrowser_BrowserInitialized;
        }

        private void CbBrowser_BrowserInitialized(object sender, EventArgs e)
        {
            var cbAdapter = new ChromiumBrowserAdapter(_cbBrowser);
            var browser = cbAdapter.GetBrowser();

            Assert.IsTrue(browser.IsReady);
        }
    }
}
