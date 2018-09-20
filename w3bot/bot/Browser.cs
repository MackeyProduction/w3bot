using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.core;
using w3bot.interfaces;
using w3bot.wrapper;

namespace w3bot.bot
{
    public static class Browser
    {
        private static BrowserAdapter _browserAdapter = null;

        static Browser()
        {
            _browserAdapter = new BrowserAdapter(Core.bot);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool IsReady
        {
            get
            {
                return _browserAdapter.IsReady;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Proxy
        {
            get
            {
                return _browserAdapter.Proxy;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SouceCode
        {
            get
            {
                return _browserAdapter.SouceCode;
            }
        }

        public static string UserAgent
        {
            get
            {
                return _browserAdapter.UserAgent;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ClearProxy()
        {
            _browserAdapter.ClearProxy();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ClearUserAgent()
        {
            _browserAdapter.ClearUserAgent();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void GoBack()
        {
            _browserAdapter.GoBack();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void GoForward()
        {
            _browserAdapter.GoForward();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public static void Navigate(string url)
        {
            _browserAdapter.Navigate(url);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Refresh()
        {
            _browserAdapter.Refresh();
        }
    }
}
