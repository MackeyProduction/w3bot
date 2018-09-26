using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.bot;
using w3bot.evt;
using w3bot.interfaces;
using w3bot.wrapper;

namespace w3bot.core
{
    public class BotWindow : TabPage, IBotWindow
    {
        internal ChromiumWebBrowser _chromiumBrowser;
        internal AbstractBotProcessor _processor;
        internal Bot _bot;
        internal String _name, _url;
        internal String _sourceCode { get; set; }

        /// <summary>
        /// Creates a new BotWindow instance.
        /// </summary>
        /// <param name="bot">The current bot instance.</param>
        /// <param name="name">The name of the bot window.</param>
        /// <param name="processor">The current processor instance.</param>
        internal BotWindow(Bot bot, string name, string url, AbstractBotProcessor processor)
        {
            DoubleBuffered = true;
            _bot = bot;
            _name = name;
            _url = url;
            _processor = processor;
            _chromiumBrowser = _processor.GetBrowser();
            _chromiumBrowser.FrameLoadEnd += ChromiumBrowser_FrameLoadEnd;
        }

        /// <summary>
        /// Reopens the window if it has been hidden before. If the window is already open calling this method has no effect.
        /// </summary>
        public void Open()
        {
            Core.ExeThreadSafe(delegate
            {
                _bot.botTab.TabPages.Add(this);
                _bot.botTab.SelectedTab = this;
                _bot.botTab.SelectedTab.Text = _name;
                _processor.ActivateProcessor(this);

                Activate();
            });
        }

        /// <summary>
        /// Hides the bot window but keeps it open. No input can be sent to this window.
        /// </summary>
        public void Vanish()
        {
            
        }

        /// <summary>
        /// Closes the window completely. The Window can't be reopen.
        /// </summary>
        public void Destroy()
        {
            
        }

        /// <summary>
        /// Marks this window as the current one. All input will be sent to this window. The window will brought to the front.
        /// </summary>
        public void Activate()
        {
            Core.ExeThreadSafe(delegate
            {
                _bot.botTab.SelectedTab = this;
                _processor.ActivateProcessor(this);
            });
        }

        internal AbstractBotProcessor GetProcessor()
        {
            return _processor;
        }

        private void ChromiumBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                _chromiumBrowser.GetSourceAsync().ContinueWith(taskHtml =>
                {
                    // load the source code
                    _sourceCode = taskHtml.Result;
                });
            }
        }
    }
}
