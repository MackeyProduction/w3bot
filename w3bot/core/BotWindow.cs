using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.interfaces;
using w3bot.wrapper;

namespace w3bot.core
{
    public class BotWindow : TabPage
    {
        internal ChromiumWebBrowser _processor;
        internal Bot _bot;

        internal BotWindow(Bot bot, string name, BotProcessor processor)
        {
            _bot = bot;
            _processor = processor.GetBrowser();
            this.Controls.Add(_processor);
            bot.botWindow = this;
            _processor.Dock = DockStyle.Fill;
            bot.botTab.TabPages.Add(this);
        }

        /// <summary>
        /// Reopens the window if it has been hidden before. If the window is already open calling this method has no effect.
        /// </summary>
        public void Open()
        {
            _processor.Dock = DockStyle.Fill;
            _bot.botTab.TabPages.Add(this);
            _bot.botTab.SelectedTab = this;
        }
    }
}
