﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using w3bot.Listener;
using w3bot.Wrapper;

namespace w3bot.Api
{
    public class Browser
    {
        private static IBotBrowser _browserAdapter;

        /// <summary>
        /// Gets the current frame.
        /// </summary>
        public Bitmap Frame
        {
            get
            {
                return _browserAdapter.Frame;
            }
        }

        /// <summary>
        /// Event handler that will get called when the browser is done loading a frame.
        /// </summary>
        public static event EventHandler<DocumentReadyEventArgs> DocumentReady
        {
            add
            {
                _browserAdapter.DocumentReady += (evt, args) =>
                {
                    value.Invoke(evt, args);
                };
            }

            remove
            {
                _browserAdapter.DocumentReady -= (evt, args) =>
                {
                    value.Invoke(evt, args);
                };
            }
        }

        /// <summary>
        /// Event handler that will get called when the browser begins loading a frame.
        /// </summary>
        public static event EventHandler<DocumentLoadEventArgs> DocumentLoad
        {
            add
            {
                _browserAdapter.DocumentLoad += (evt, args) =>
                {
                    value.Invoke(evt, args);
                };
            }

            remove
            {
                _browserAdapter.DocumentLoad -= (evt, args) =>
                {
                    value.Invoke(evt, args);
                };
            }
        }

        /// <summary>
        /// Event handler that will get called when the browser is changing the address.
        /// </summary>
        public static event EventHandler<DocumentAddressChangedEventArgs> AddressChanged
        {
            add
            {
                _browserAdapter.AddressChanged += (evt, args) =>
                {
                    value.Invoke(evt, args);
                };
            }

            remove
            {
                _browserAdapter.AddressChanged -= (evt, args) =>
                {
                    value.Invoke(evt, args);
                };
            }
        }

        /// <summary>
        /// Returns true when the browser is finished loading.
        /// </summary>
        public static bool IsReady
        {
            get
            {
                return _browserAdapter.GetBrowser().IsReady;
            }
        }

        /// <summary>
        /// Returns the configured proxy.
        /// </summary>
        public static string Proxy
        {
            get
            {
                return _browserAdapter.Proxy;
            }
        }

        /// <summary>
        /// Returns the source code from the current website.
        /// </summary>
        public static string SouceCode
        {
            get
            {
                return _browserAdapter.GetBrowser().SouceCode;
            }
        }

        /// <summary>
        /// Returns the user agent from the current BotWindow.
        /// </summary>
        public static string UserAgent
        {
            get
            {
                return _browserAdapter.UserAgent;
            }
        }

        /// <summary>
        /// Returns an empty string.
        /// </summary>
        public static void ClearProxy()
        {
            //_browserAdapter.GetBrowser().ClearProxy();
        }

        /// <summary>
        /// Returns an empty string.
        /// </summary>
        public static void ClearUserAgent()
        {
            //_browserAdapter.ClearUserAgent();
        }

        /// <summary>
        /// Opens the previous page.
        /// </summary>
        public static void GoBack()
        {
            _browserAdapter.GetBrowser().GoBack();
        }

        /// <summary>
        /// Opens the next page.
        /// </summary>
        public static void GoForward()
        {
            _browserAdapter.GetBrowser().GoForward();
        }

        /// <summary>
        /// Loads the specific URL.
        /// </summary>
        /// <param name="url"></param>
        public static void Navigate(string url)
        {
            _browserAdapter.GetBrowser().Navigate(url);
        }

        /// <summary>
        /// Reloads the page being displayed.
        /// </summary>
        public static void Refresh()
        {
            _browserAdapter.GetBrowser().Refresh();
        }

        /// <summary>
        /// Execute some Javascript code in the context of this WebBrowser.
        /// </summary>
        /// <param name="script">The Javascript code that should be executed.</param>
        /// <returns>Returns an Javascript object.</returns>
        public static async Task<object> ExecuteJavascript(string script)
        {
            return await _browserAdapter.GetBrowser().ExecuteJavascript(script);
        }

        /// <summary>
        /// Add configuration to Browser instance.
        /// </summary>
        /// <param name="browser">The browser instance.</param>
        internal static void AddConfiguration(IBotBrowser browser)
        {
            _browserAdapter = browser;
        }
    }
}
