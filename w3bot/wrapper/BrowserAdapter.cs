using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.core;
using w3bot.interfaces;

namespace w3bot.wrapper
{
    class BrowserAdapter : BotProcessor, w3bot.interfaces.IBrowser
    {
        internal ChromiumWebBrowser _chromeBrowser = null;
        internal Bot _bot = null;

        public BrowserAdapter(Bot bot) : base(bot)
        {
            _bot = bot;
            _chromeBrowser = _bot.botWindow._processor;
        }

        public bool IsReady
        {
            get
            {
                if (_chromeBrowser.IsDisposed)
                    return true;
                return false;
            }
        }

        public string Proxy
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string SouceCode
        {
            get
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

        public void ClearProxy()
        {
            throw new NotImplementedException();
        }

        public void ClearUserAgent()
        {
            
        }

        public void GoBack()
        {
            if (_chromeBrowser.CanGoBack)
            {
                _chromeBrowser.Back();
            }
        }

        public void GoForward()
        {
            if (_chromeBrowser.CanGoForward)
            {
                _chromeBrowser.Forward();
            }
        }

        public void Navigate(string url)
        {
            if (_chromeBrowser != null)
            {
                if (!url.Contains("://"))
                    url = "http://" + url;
                _chromeBrowser.Load(url);
            }
        }

        public void Refresh()
        {
            _chromeBrowser.Reload();
        }
    }
}
