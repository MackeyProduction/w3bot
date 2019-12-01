using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Interfaces;

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
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            if (!_browser.IsDisposed)
            {
                _browser.Dispose();
            }
        }

        public Task<object> ExecuteJavascript(string script)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            _browser.Reload();
        }
    }
}
