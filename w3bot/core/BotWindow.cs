using CefSharp;
using CefSharp.WinForms;
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
            _bot = bot;
            _name = name;
            _url = url;
            _processor = processor;
            _chromiumBrowser = _processor.GetBrowser();
            _chromiumBrowser.FrameLoadEnd += ChromiumBrowser_FrameLoadEnd;
            _chromiumBrowser.AddressChanged += ChromiumBrowser_AddressChanged;
            _chromiumBrowser.LoadingStateChanged += ChromiumBrowser_LoadingStateChanged;
            Activate();
        }

        /// <summary>
        /// Reopens the window if it has been hidden before. If the window is already open calling this method has no effect.
        /// </summary>
        public void Open()
        {
            this.Controls.Add(_chromiumBrowser);
            _chromiumBrowser.Dock = DockStyle.Fill;
            _bot.botTab.TabPages.Add(this);
            _bot.botTab.SelectedTab = this;
            _chromiumBrowser.Invalidate();
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
                _processor.ActivateProcessor();
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

        private void ChromiumBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            Status.Log(e.Address);
            _bot.RefreshTabPageThreadSafe(1);
        }
        
        private void ChromiumBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            //if (!e.Browser.IsLoading)
            //{
            //    Core.ExeThreadSafe(delegate
            //    {
            //        var panel = new Panel();

            //        panel.Size = _bot.ClientSize;
            //        panel.Location = new Point(100, 100);
            //        panel.Focus();

            //        PaintEventHandler paintHandler = (senderP, args) =>
            //        {
            //            var g = panel.CreateGraphics();
            //            Font font = new Font("Arial", 8);
            //            g.DrawString("Mouse: " + 0 + ", " + 0, font, Brushes.Green, 200, 200);
            //        };

            //        this.Controls.Add(panel);
            //        panel.Invalidate();
            //        _bot.botTab.SelectedTab = this;
            //    });
            //}
        }
    }
}
