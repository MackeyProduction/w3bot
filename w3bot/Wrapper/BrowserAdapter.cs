using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Bot;
using w3bot.Core;
using w3bot.Evt;
using w3bot.Interfaces;
using w3bot.Interfaces;
using w3bot.Listener;

namespace w3bot.Wrapper
{
    class BrowserAdapter : BotProcessor, w3bot.Interfaces.IBrowser, IWebBrowserEvents
    {
        internal ChromiumWebBrowser _chromeBrowser = null;
        internal BotWindow _botWindow;
        private string url;

        public event EventHandler<FrameLoadStartEventArgs> FrameLoadStart;
        public event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;

        public BrowserAdapter(Bot.Bot bot) : base(bot)
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
            this.url = url;
            _chromeBrowser.FrameLoadEnd += address_change;
        }

        public void Refresh()
        {
            _chromeBrowser.Reload();
        }

        public async Task<object> ExecuteJavascript(string script)
        {
            // Check if the browser can execute JavaScript and the ScriptTextBox is filled
            if (_chromeBrowser.CanExecuteJavascriptInMainFrame && !string.IsNullOrWhiteSpace(script))
            {
                // Evaluate javascript and remember the evaluation result
                JavascriptResponse response = await _chromeBrowser.EvaluateScriptAsync(script);
                
                if (response.Result != null)
                {
                    // Display the evaluation result if it is not empty
                    return response;
                }
            }

            return null;
        }

        private void address_change(object sender, FrameLoadEndEventArgs e)
        {
            if (!url.Contains("://"))
                url = "http://" + url;
            _chromeBrowser.Load(url);
            _chromeBrowser.FrameLoadEnd -= address_change;
        }

        public void SetAddress(Listener.DocumentAddressChangedEventArgs args)
        {
            
        }

        public void OnDocumentLoad(DocumentLoadEventArgs args)
        {
            //FrameLoadStart?.Invoke(this, args);
        }

        public void OnDocumentReady(DocumentReadyEventArgs args)
        {
            
        }
    }
}
