using CefSharp.OffScreen;
using System;
using w3bot.Wrapper.Browser;
using CefSharp;
using w3bot.Wrapper.Input;
using w3bot.Core.Database.Entity;
using w3bot.Listener;
using System.Drawing;
using w3bot.Core.Processor;
using w3bot.Script;
using w3bot.Event;

namespace w3bot.Wrapper
{
    class ChromiumBrowserAdapter : IBotBrowser
    {
        const string HOME_URL = "https://www.google.com/";

        private ChromiumWebBrowser _chromiumBrowser;
        private IMouseInput _chromiumMouse;
        private IKeyboardInput _chromiumKeyboard;
        private IBrowser _browser;
        private CefSharp.AbstractCefSettings _cefSettings;
        private Bitmap _browserBitmap;

        public event EventHandler<DocumentReadyEventArgs> DocumentReady
        {
            add
            {
                _chromiumBrowser.FrameLoadEnd += (evt, args) => 
                {
                    var adaptedBrowser = new Chromium(_chromiumBrowser);
                    value.Invoke(this, new DocumentReadyEventArgs(adaptedBrowser, args.HttpStatusCode, args.Url));
                };
            }
            remove
            {
                _chromiumBrowser.FrameLoadEnd -= (evt, args) =>
                {
                    var adaptedBrowser = new Chromium(_chromiumBrowser);
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
                    var adaptedBrowser = new Chromium(_chromiumBrowser);
                    value.Invoke(this, new DocumentLoadEventArgs(adaptedBrowser, args.Url));
                };
            }
            remove
            {
                _chromiumBrowser.FrameLoadStart -= (evt, args) =>
                {
                    var adaptedBrowser = new Chromium(_chromiumBrowser);
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
                    var adaptedBrowser = new Chromium(_chromiumBrowser);
                    value.Invoke(this, new DocumentAddressChangedEventArgs(adaptedBrowser, args.Address));
                };
            }
            remove
            {
                _chromiumBrowser.AddressChanged -= (evt, args) =>
                {
                    var adaptedBrowser = new Chromium(_chromiumBrowser);
                    value.Invoke(this, new DocumentAddressChangedEventArgs(adaptedBrowser, args.Address));
                };
            }
        }

        public ChromiumBrowserAdapter()
        {
            if (!Cef.IsInitialized)
            {
                // load cef settings
                CefSettings settings = new CefSettings();
                settings.CachePath = "Cache";
                settings.PersistSessionCookies = true;
                settings.PersistUserPreferences = true;

                //_cefSettings.UserAgent = settings.UserAgent;

                // placeholder for proxy. TODO: remove placeholder
                var proxy = new Proxy();

                // start proxy server
                if (proxy != null)
                    settings.CefCommandLineArgs.Add($"--proxy-server={proxy.IP}:{proxy.Port}", "1");
                
                // init settings
                Cef.Initialize(settings);
            }
            _chromiumBrowser = new ChromiumWebBrowser(HOME_URL);
            _chromiumBrowser.Size = new Size(994, 582);
        }

        public ChromiumBrowserAdapter(CefSharp.AbstractCefSettings settings)
        {
            _cefSettings = settings;
            Cef.Initialize(_cefSettings);
            _chromiumBrowser = new ChromiumWebBrowser(HOME_URL);
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

        public Size Size 
        { 
            get
            {
                return _chromiumBrowser.Size;
            }

            set
            {
                _chromiumBrowser.Size = value;
            }
        }

        public Bitmap Frame
        {
            get
            {
                try
                {
                    _chromiumBrowser.ScreenshotAsync().ContinueWith(task =>
                    {
                        // load browser bitmap
                        _browserBitmap = task.Result;
                    });
                }
                catch (Exception e)
                {
                    throw e;
                }

                return _browserBitmap;
            }
        }

        public IBrowser GetBrowser()
        {
            return (_browser == null) ? _browser = new Chromium(_chromiumBrowser) : _browser;
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
            return (_chromiumKeyboard == null && _chromiumBrowser.IsBrowserInitialized) ? _chromiumKeyboard = new ChromiumKeyboard(_chromiumBrowser.GetBrowser()) : _chromiumKeyboard;
        }

        public IMouseInput GetMouse()
        {
            return (_chromiumMouse == null && _chromiumBrowser.IsBrowserInitialized) ? _chromiumMouse = new ChromiumMouse(_chromiumBrowser) : _chromiumMouse;
        }
    }
}
