using System.Threading.Tasks;
using w3bot.Wrapper;

namespace w3bot.Bot
{
    public static class Browser
    {
        private static BrowserAdapter _browserAdapter = null;

        /// <summary>
        /// Returns true when the browser is finished loading.
        /// </summary>
        public static bool IsReady
        {
            get
            {
                return _browserAdapter.IsReady;
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
                return _browserAdapter.SouceCode;
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
            _browserAdapter.ClearProxy();
        }

        /// <summary>
        /// Returns an empty string.
        /// </summary>
        public static void ClearUserAgent()
        {
            _browserAdapter.ClearUserAgent();
        }

        /// <summary>
        /// Opens the previous page.
        /// </summary>
        public static void GoBack()
        {
            _browserAdapter.GoBack();
        }

        /// <summary>
        /// Opens the next page.
        /// </summary>
        public static void GoForward()
        {
            _browserAdapter.GoForward();
        }

        /// <summary>
        /// Loads the specific URL.
        /// </summary>
        /// <param name="url"></param>
        public static void Navigate(string url)
        {
            _browserAdapter.Navigate(url);
        }

        /// <summary>
        /// Reloads the page being displayed.
        /// </summary>
        public static void Refresh()
        {
            _browserAdapter.Refresh();
        }

        /// <summary>
        /// Execute some Javascript code in the context of this WebBrowser.
        /// </summary>
        /// <param name="script">The Javascript code that should be executed.</param>
        /// <returns>Returns an Javascript object.</returns>
        public static async Task<object> ExecuteJavascript(string script)
        {
            return await _browserAdapter.ExecuteJavascript(script);
        }

        /// <summary>
        /// Add configuration to Browser instance.
        /// </summary>
        /// <param name="bot">The bot instance.</param>
        internal static void AddConfiguration(Bot bot)
        {
            _browserAdapter = bot.botSettings.browserAdapter;
        }
    }
}
