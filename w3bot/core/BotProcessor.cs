using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.bot;
using w3bot.enumeration;
using w3bot.interfaces;
using w3bot.wrapper;
using System.Drawing;
using w3bot.evt;

namespace w3bot.core
{
    class BotProcessor : AbstractBotProcessor
    {
        public static ChromiumWebBrowser chromiumBrowser { get; set; }
        internal Bot _bot;
        internal String _userAgent { get; set; }
        internal String _proxy { get; set; }
        internal BotProcessor botProcessor { get; set; }
        internal Point mouse = new Point(0, 0);
        bool input = false;

        /// <summary>
        /// Initialize a new BotProcessor to configure cef browser settings and chromium browser.
        /// </summary>
        /// <param name="bot">Bot instance.</param>
        /// <param name="proxyOptions">Proxy settings.</param>
        public BotProcessor(Bot bot, ProxyOptions proxyOptions = null)
        {
            _bot = bot;

            if (!Cef.IsInitialized)
            {
                // load cef settings
                CefSettings settings = new CefSettings();
                settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
                _userAgent = settings.UserAgent;

                // start proxy server
                if (proxyOptions != null)
                    settings.CefCommandLineArgs.Add($"--proxy-server={proxyOptions.IP}:{proxyOptions.Port}", "1");

                // init settings
                Cef.Initialize(settings);
            }
            
            chromiumBrowser = new ChromiumWebBrowser("https://www.google.com/");
            chromiumBrowser.Size = ClientSize;
            _bot.browser = chromiumBrowser;

            chromiumBrowser.LoadingStateChanged += ChromiumBrowser_LoadingStateChanged;
        }

        private void ChromiumBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            //if (!e.Browser.IsLoading)
            //{
            //    Core.ExeThreadSafe(delegate
            //    {
            //        var panel = new Panel();

            //        panel.Size = _bot.ClientSize;
            //        panel.Location = new Point(0, 0);
            //        panel.BorderStyle = BorderStyle.None;
            //        panel.Dock = DockStyle.Fill;
            //        var g = panel.CreateGraphics();
            //        Font font = new Font("Arial", 8);
            //        g.DrawString("Mouse: " + 0 + ", " + 0, font, Brushes.Green, 200, 200);
            //        Core.mainWindow.Controls.Add(panel);
            //        panel.Focus();
            //        panel.Invalidate();
            //    });
            //}
        }

        internal override void ActivateProcessor()
        {
            if (!chromiumBrowser.IsDisposed)
                botProcessor = this;
        }

        internal override void AllowInput()
        {
            if (!input)
            {
                //_bot.core.mainWindow.Activated += MainWindow_Activated;

                _bot.core.mainWindow.MouseMove += MainWindow_MouseMove;
                MouseUp += MainWindow_MouseUp;
                MouseDown += MainWindow_MouseDown;
                MouseClick += BotProcessor_MouseClick;
                input = true;
            }
        }

        private void BotProcessor_MouseClick(object sender, MouseEventArgs e)
        {
            chromiumBrowser.FrameLoadEnd += (fSender, args) =>
            {
                args.Browser.GetHost().SendMouseClickEvent(e.X, e.Y, (MouseButtonType)e.Button, false, 1, CefEventFlags.None);
            };
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            chromiumBrowser.Focus();
        }

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            chromiumBrowser.FrameLoadEnd += (fSender, args) =>
            {
                args.Browser.GetHost().SendMouseClickEvent(e.X, e.Y, (MouseButtonType)e.Button, false, 1, CefEventFlags.None);
            };
        }

        private void MainWindow_MouseUp(object sender, MouseEventArgs e)
        {
            chromiumBrowser.FrameLoadEnd += (fSender, args) =>
            {
                args.Browser.GetHost().SendMouseClickEvent(e.X, e.Y, (MouseButtonType)e.Button, true, 1, CefEventFlags.None);
            };
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            chromiumBrowser.FrameLoadEnd += (fSender, args) =>
            {
                args.Browser.GetHost().SendMouseMoveEvent(e.X, e.Y, false, CefEventFlags.None);
            };
            _bot.core.mainWindow.Invalidate();
        }

        internal override void BlockInput()
        {
            if (!input)
            {
                _bot.core.mainWindow.MouseMove -= MainWindow_MouseMove;
                _bot.core.mainWindow.MouseUp -= MainWindow_MouseUp;
                _bot.core.mainWindow.MouseDown -= MainWindow_MouseDown;
                input = false;
            }
        }

        internal override void Destroy()
        {
            if (chromiumBrowser != null)
            {
                chromiumBrowser.Dispose();
            }
        }

        internal override ChromiumWebBrowser GetBrowser()
        {
            return chromiumBrowser;
        }

        internal override Point MousePos
        {
            get
            {
                return mouse;
            }

            set
            {
                mouse = value;
            }
        }

        internal override Bitmap Frame
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal override void GetFocus()
        {
            Core.ExeThreadSafe(delegate
            {
                chromiumBrowser.Focus();
            });
        }
    }
}
