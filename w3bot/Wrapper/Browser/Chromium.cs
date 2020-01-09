using CefSharp;
using System;
using System.Threading.Tasks;

namespace w3bot.Wrapper.Browser
{
    class Chromium : IBrowser
    {
        private CefSharp.IBrowser _browser;

        public Chromium(CefSharp.IBrowser browser)
        {
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
                return _browser.MainFrame.GetSourceAsync().Result;
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
            return await _browser.MainFrame.EvaluateScriptAsync(script);
        }

        public void GoBack()
        {
            if (_browser.CanGoBack)
            {
                _browser.GoBack();
            }
        }

        public void GoForward()
        {
            if (_browser.CanGoForward)
            {
                _browser.GoForward();
            }
        }

        public void Navigate(string url)
        {
            if (!url.Contains("://"))
                url = "http://" + url;
            _browser.MainFrame.LoadUrl(url);
        }

        public void Refresh()
        {
            _browser.Reload();
        }
    }
}
