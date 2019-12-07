using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Linq;
using w3bot.Wrapper;

namespace w3bot.Bot
{
    public class BotWindow : TabPage, IBotWindow
    {
        internal ChromiumWebBrowser _chromiumBrowser;
        internal AbstractBotProcessor _processor;
        internal w3bot.Bot.Bot _bot;
        internal String _name, _url;
        internal String _sourceCode { get; set; }
        internal bool doubleBuffered = true;
        internal bool _doubleBuffered { get { return doubleBuffered; } set { doubleBuffered = false; } }
        internal bool isVanished = false, isClosed = false;
        internal IProcessor _newProcessor;

        /// <summary>
        /// Creates a new BotWindow instance.
        /// </summary>
        /// <param name="bot">The current bot instance.</param>
        /// <param name="name">The name of the bot window.</param>
        /// <param name="processor">The current processor instance.</param>
        [Obsolete("The constructor is deprecated. Use the new constructor with IProcessor integration instead.")]
        internal BotWindow(w3bot.Bot.Bot bot, string name, string url, AbstractBotProcessor processor)
        {
            DoubleBuffered = _doubleBuffered;
            _bot = bot;
            _name = name;
            _url = url;
            _processor = processor;
            _chromiumBrowser = _processor.GetBrowser();
            _chromiumBrowser.FrameLoadEnd += ChromiumBrowser_FrameLoadEnd;
            Activate();
        }

        internal BotWindow(string name, IProcessor processor)
        {
            _name = name;
            _newProcessor = processor;
        }

        /// <summary>
        /// Reopens the window if it has been hidden before. If the window is already open calling this method has no effect.
        /// </summary>
        public void Open()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be reopen.");
            Core.ExeThreadSafe(delegate
            {
                isVanished = false;
                _bot.botTab.TabPages.Add(this);
                _bot.botTab.SelectedTab = this;
                _bot.botTab.SelectedTab.Text = _name;
            });
        }

        /// <summary>
        /// Hides the bot window but keeps it open. No input can be sent to this window.
        /// </summary>
        public void Vanish()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be vanished.");
            if (isVanished) return;
            Core.ExeThreadSafe(delegate
            {
                _bot.botTab.TabPages.Remove(this);
                int bots = _bot.botTab.TabPages.Count;
                if (bots > 0) ((BotWindow)_bot.botTab.TabPages[bots - 1]).Activate();
                isVanished = true;
            });
        }

        /// <summary>
        /// Closes the window completely. The Window can't be reopen.
        /// </summary>
        public void Destroy()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be closed.");
            Core.ExeThreadSafe(delegate
            {
                this.Controls.Remove(_processor);
                _processor.Destroy();
                _processor = null;
                Vanish();
                isClosed = true;
            });
        }

        /// <summary>
        /// Marks this window as the current one. All input will be sent to this window. The window will brought to the front.
        /// </summary>
        public void Activate()
        {
            if (isClosed) throw new InvalidOperationException("The Botwindow is already destroyed. It can't be reactivated.");
            Core.ExeThreadSafe(delegate
            {
                //if (_bot.botWindow != null) _bot.botWindow._processor.BlockInput();
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
