﻿using CefSharp.OffScreen;
using System;
using w3bot.Wrapper.Browser;
using CefSharp;
using w3bot.Wrapper.Input;
using w3bot.Listener;

namespace w3bot.Wrapper
{
    class ChromiumBrowserAdapter : IBotBrowser
    {
        private ChromiumWebBrowser _chromiumBrowser;
        private CefSharp.AbstractCefSettings _cefSettings;

        public event EventHandler<DocumentReadyEventArgs> DocumentReady
        {
            add
            {
                _chromiumBrowser.FrameLoadEnd += (evt, args) => 
                {
                    var adaptedBrowser = new Chromium(args.Browser);
                    value.Invoke(this, new DocumentReadyEventArgs(adaptedBrowser, args.HttpStatusCode, args.Url));
                };
            }
            remove
            {
                _chromiumBrowser.FrameLoadEnd -= (evt, args) =>
                {
                    var adaptedBrowser = new Chromium(args.Browser);
                    value.Invoke(this, new DocumentReadyEventArgs(adaptedBrowser, args.HttpStatusCode, args.Url));
                };
            }
        }

        public event EventHandler<DocumentLoadEventArgs> DocumentLoad
        {
            add
            {
                _chromiumBrowser.FrameLoadStart += (evt, args) =>
                {
                    var adaptedBrowser = new Chromium(args.Browser);
                    value.Invoke(this, new DocumentLoadEventArgs(adaptedBrowser, args.Url));
                };
            }
            remove
            {
                _chromiumBrowser.FrameLoadStart -= (evt, args) =>
                {
                    var adaptedBrowser = new Chromium(args.Browser);
                    value.Invoke(this, new DocumentLoadEventArgs(adaptedBrowser, args.Url));
                };
            }
        }

        public event EventHandler<DocumentAddressChangedEventArgs> AddressChanged
        {
            add
            {
                _chromiumBrowser.AddressChanged += (evt, args) =>
                {
                    var adaptedBrowser = new Chromium(args.Browser);
                    value.Invoke(this, new DocumentAddressChangedEventArgs(adaptedBrowser, args.Address));
                };
            }
            remove
            {
                _chromiumBrowser.AddressChanged -= (evt, args) =>
                {
                    var adaptedBrowser = new Chromium(args.Browser);
                    value.Invoke(this, new DocumentAddressChangedEventArgs(adaptedBrowser, args.Address));
                };
            }
        }

        public ChromiumBrowserAdapter(ChromiumWebBrowser chromiumBrowser)
        {
            if (!Cef.IsInitialized)
            {
                // load cef settings
                CefSettings settings = new CefSettings();
                //settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
                settings.CachePath = "Cache";
                settings.PersistSessionCookies = true;
                settings.PersistUserPreferences = true;

                _cefSettings.UserAgent = settings.UserAgent;

                // placeholder for proxy. TODO: remove placeholder
                var proxy = new Proxy();

                // start proxy server
                if (proxy != null)
                    settings.CefCommandLineArgs.Add($"--proxy-server={proxy.IP}:{proxy.Port}", "1");

                // init settings
                Cef.Initialize(settings);
            }
            _chromiumBrowser = chromiumBrowser;
        }

        public ChromiumBrowserAdapter(ChromiumWebBrowser chromiumBrowser, CefSharp.AbstractCefSettings settings)
        {
            _cefSettings = settings;
            Cef.Initialize(_cefSettings);
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
                return _cefSettings.UserAgent;
            }
        }

        public IBrowser GetBrowser()
        {
            return new Chromium(_chromiumBrowser.GetBrowser());
        }

        public void Dispose()
        {
            if (!_chromiumBrowser.IsDisposed)
            {
                _chromiumBrowser.Dispose();
            }
        }

        public IKeyboardInput GetKeyboard()
        {
            throw new NotImplementedException();
        }

        public IMouseInput GetMouse()
        {
            return new ChromiumMouse(_chromiumBrowser.GetBrowser());
        }
    }
}
