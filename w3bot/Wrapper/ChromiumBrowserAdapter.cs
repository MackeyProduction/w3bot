using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Interfaces;
using w3bot.Wrapper.Helper;

namespace w3bot.Wrapper
{
    class ChromiumBrowserAdapter : IBotBrowser
    {
        private ChromiumWebBrowser _chromiumBrowser;
        private CefSharp.AbstractCefSettings _cefSettings;

        public ChromiumBrowserAdapter(ChromiumWebBrowser chromiumBrowser)
        {
            _chromiumBrowser = chromiumBrowser;
        }

        public ChromiumBrowserAdapter(ChromiumWebBrowser chromiumBrowser, CefSharp.AbstractCefSettings settings)
        {
            _cefSettings = settings;
            _chromiumBrowser = chromiumBrowser;
        }

        public string Proxy
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string UserAgent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBrowser GetBrowser()
        {
            return new ChromiumBrowserHelper(_chromiumBrowser.GetBrowser());
        }
    }
}
