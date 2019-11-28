using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Interfaces;

namespace w3bot.Wrapper.Helper
{
    class ChromiumBrowserHelper : IBrowser
    {
        private CefSharp.IBrowser _browser;

        public ChromiumBrowserHelper(CefSharp.IBrowser browser)
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
