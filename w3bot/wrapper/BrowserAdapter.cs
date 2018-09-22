﻿using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.core;
using w3bot.interfaces;

namespace w3bot.wrapper
{
    class BrowserAdapter : BotProcessor, w3bot.interfaces.IBrowser
    {
        internal ChromiumWebBrowser _chromeBrowser = null;
        internal BotWindow _botWindow;

        public BrowserAdapter(Bot bot) : base(bot)
        {
            _bot = bot;
            if (_bot.botWindow == null) throw new InvalidOperationException("The Botwindow isn't initialized. Please initialize the botwindow with the Initialize() method.");
            _botWindow = _bot.botWindow;
            _chromeBrowser = _botWindow._chromiumBrowser;
        }

        public bool IsReady
        {
            get
            {
                if (!_chromeBrowser.IsLoading)
                    return true;
                return false;
            }
        }

        public string Proxy
        {
            get
            {
                return _proxy;
            }
            set
            {
                _proxy = value;
            }
        }

        public string SouceCode
        {
            get
            {
                return _botWindow._sourceCode;
            }
        }

        public string UserAgent
        {
            get
            {
                return _userAgent;
            }
        }

        public void ClearProxy()
        {
            _proxy = "";
        }

        public void ClearUserAgent()
        {
            _userAgent = "";
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
            if (_chromeBrowser.IsBrowserInitialized)
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
