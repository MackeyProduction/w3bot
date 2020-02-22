using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Drawing;
using System.Threading.Tasks;
using w3bot.Core.Processor;
using w3bot.Event;
using w3bot.Script;

namespace w3bot.Wrapper.Browser
{
    class Chromium : IBrowser
    {
        private ChromiumWebBrowser _browser;
        private Bitmap _browserBitmap;
        private string _url;
        private IProcessor processor;
        internal static IBrowser Browser;
        internal Action BrowserAction = delegate { };

        public Chromium(ChromiumWebBrowser browser)
        {
            Browser = this;
            _browser = browser;
        }

        public bool IsReady
        {
            get
            {
                if (!_browser.IsLoading)
                    return true;
                
                return false;
            }
        }

        public string SouceCode
        {
            get
            {
                return _browser.GetMainFrame().GetSourceAsync().Result;
            }
        }

        public Bitmap Frame
        {
            get
            {
                return _browserBitmap;
            }
        }

        public void Dispose()
        {
            if (!_browser.IsDisposed)
            {
                _browser.Dispose();
            }
        }

        public async Task<object> ExecuteJavascript(string script)
        {
            return await _browser.GetMainFrame().EvaluateScriptAsync(script);
        }

        public void GoBack()
        {
            if (_browser.CanGoBack)
            {
                _browser.GetBrowser().GoBack();
            }
        }

        public void GoForward()
        {
            if (_browser.CanGoForward)
            {
                _browser.GetBrowser().GoForward();
            }
        }

        public void Navigate(string url)
        {
            _url = url;
            if (!_url.Contains("://"))
                _url = "http://" + _url;
            _browser.Load(_url);
        }

        public void Refresh()
        {
            _browser.Reload();
        }
    }
}
