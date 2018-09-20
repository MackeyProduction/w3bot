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
using w3bot.wrapper;

namespace w3bot.core
{
    class Bot : Core
    {
        internal ChromiumWebBrowser browser { get; set; }
        internal Size ClientSize { get { return mainWindow.Size; } }
        internal Size FrameSize { get; }
        internal BotWindow botWindow { get { return new BotWindow(this, "View", new BotProcessor(this)); } set { } }
        internal TabControl botTab { get { return tabs; } set { } }

        /// <summary>
        /// Creates a new BotWindow which allows you to send input.
        /// </summary>
        /// <param name="name">Bot window name.</param>
        /// <param name="url">Url of the bot window.</param>
        /// <returns>Returns an BotWindow object.</returns>
        public BotWindow CreateBrowserWindow(string name = "View", string url = "")
        {
            botWindow = new BotWindow(this, name, new BotProcessor(this));
            if (url != "")
                Browser.Navigate(url);

            return botWindow;
        }
    }
}
