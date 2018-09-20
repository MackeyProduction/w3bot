using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.bot;
using w3bot.core;
using w3bot.wrapper;

namespace w3bot.bot
{
    class Bot : Core
    {
        internal ChromiumWebBrowser browser { get; set; }
        internal Size ClientSize { get { return mainWindow.Size; } }
        internal Size FrameSize { get; }
        internal TabControl botTab { get { return tabs; } set { } }
        private BotWindow _botWindow;
        internal BotWindow botWindow { get { return _botWindow; } set { _botWindow = value; } }
        private delegate void RefreshTabPageDelegate(int tabPage);
        private CoreSettings _coreSettings;
        internal CoreSettings coreSettings { get { return _coreSettings; } set { _coreSettings = value; } }

        /// <summary>
        /// Creates a new BotWindow which allows you to send input.
        /// </summary>
        /// <param name="name">Bot window name.</param>
        /// <param name="url">Url of the bot window.</param>
        /// <returns>Returns an BotWindow object.</returns>
        public BotWindow CreateBrowserWindow(string name = "View", string url = "")
        {
            return new BotWindow(this, name, url, new BotProcessor(this));
        }

        public void Initialize(BotWindow botWindow)
        {
            _botWindow = botWindow;
            _coreSettings = new CoreSettings();
            _coreSettings.browserAdapter = new BrowserAdapter(this);
            _coreSettings.inputAdapter = new InputAdapter(new MouseAdapter(this), new KeyboardAdapter(this));

            // add configuration
            Browser.AddConfiguration(this);

            if (botWindow._url != "")
                Browser.Navigate(botWindow._url);
        }

        public void RefreshTabPageThreadSafe(int tabPage)
        {
            if (tabs.InvokeRequired)
            {
                tabs.Invoke(new RefreshTabPageDelegate(RefreshTabPageThreadSafe), new object[] { tabPage });
            }
            else
            {
                if (tabs.TabPages.Count > tabPage)
                {
                    tabs.TabPages[tabPage].Refresh();
                }
            }
        }
    }
}
