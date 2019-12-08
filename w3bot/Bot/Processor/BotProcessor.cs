using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Windows.Forms;
using w3bot.Wrapper;
using System.Drawing;
using w3bot.Core.Bot;

namespace w3bot.Core.Processor
{
    class BotProcessor : AbstractBotProcessor
    {
        private ChromiumWebBrowser chromiumBrowser { get; set; }
        internal w3bot.Bot.Bot _bot;
        internal String _userAgent { get; set; }
        internal String _proxy { get; set; }
        internal BotProcessor botProcessor { get; set; }
        private Point mouse = new Point(0, 0);
        private bool input = false;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private BotWindow _botWindow;
        private bool initialized = false;
        private Bitmap browserBitmap;
        private IBrowserHost browserHost;

        /// <summary>
        /// Initialize a new BotProcessor to configure cef browser settings and chromium browser.
        /// </summary>
        /// <param name="bot">Bot instance.</param>
        /// <param name="proxyOptions">Proxy settings.</param>
        [Obsolete("This constructor will soon be deprecated. Use the web processor instead.")]
        public BotProcessor(w3bot.Bot.Bot bot, ProxyOptions proxyOptions = null)
        {
            _bot = bot;
            Size = new Size(1024, 600);

            if (!Cef.IsInitialized)
            {
                // load cef settings
                CefSettings settings = new CefSettings();
                //settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
                settings.CachePath = "Cache";
                settings.PersistSessionCookies = true;
                settings.PersistUserPreferences = true;

                _userAgent = settings.UserAgent;

                // start proxy server
                if (proxyOptions != null)
                    settings.CefCommandLineArgs.Add($"--proxy-server={proxyOptions.IP}:{proxyOptions.Port}", "1");

                // init settings
                Cef.Initialize(settings);
            }
            
            chromiumBrowser = new ChromiumWebBrowser("https://www.google.com/");
            chromiumBrowser.Size = this.ClientSize;
            //_bot.browser = chromiumBrowser;

            chromiumBrowser.BrowserInitialized += ChromiumBrowser_BrowserInitialized;
        }

        private void ChromiumBrowser_BrowserInitialized(object sender, EventArgs e)
        {
            browserHost = chromiumBrowser.GetBrowserHost();
            initialized = true;
        }

        internal override void ActivateProcessor(BotWindow botWindow)
        {
            timer.Tick += Timer_Tick;
            timer.Interval = 25;
            timer.Start();

            if (botWindow == null) return;
            _botWindow = botWindow;
            _botWindow._chromiumBrowser.FrameLoadEnd += _chromiumBrowser_FrameLoadEnd;
        }

        private void _botWindow_MouseMove(object sender, MouseEventArgs e)
        {
            mouse = new Point(e.X, e.Y);
            browserHost.SendMouseMoveEvent(e.X, e.Y, false, CefEventFlags.None);
        }

        private void _chromiumBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (initialized)
            {
                if (e.Frame.IsMain)
                {
                    _botWindow.Paint += Bot_Paint;
                }
            }
        }

        private void FetchBitmap()
        {
            _botWindow._chromiumBrowser.ScreenshotAsync().ContinueWith(task =>
            {
                // load browser bitmap
                browserBitmap = task.Result;
            });
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _botWindow.Invalidate();
        }

        private void Bot_Paint(object sender, PaintEventArgs e)
        {
            FetchBitmap();
            if (browserBitmap == null) return;
            if (!initialized) return;

            Pen greenPen = new Pen(Color.Green);

            var g = e.Graphics;
            g.DrawImage(browserBitmap, 0, 0);

            // load user paint
            _bot.RefreshPaints(g);
        }

        internal override void AllowInput()
        {
            if (!input)
            {
                _botWindow.MouseMove += _botWindow_MouseMove;
                _botWindow.MouseUp += _botWindow_MouseUp;
                _botWindow.MouseDown += _botWindow_MouseDown;
                _bot.core.mainWindow.KeyPress += MainWindow_KeyPress;
                _botWindow.MouseWheel += _botWindow_MouseWheel;
                input = true;
            }
        }

        private void _botWindow_MouseWheel(object sender, MouseEventArgs e)
        {
            int deltaX = 0, deltaY = 0;
            deltaY = e.Delta;

            browserHost.SendMouseWheelEvent(e.X, e.Y, deltaX, deltaY, CefEventFlags.None);
        }

        private void MainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyEvent keyEvent = new KeyEvent();
            keyEvent.Type = KeyEventType.Char;
            keyEvent.WindowsKeyCode = e.KeyChar;
            browserHost.SendKeyEvent(keyEvent);
        }

        private void _botWindow_MouseDown(object sender, MouseEventArgs e)
        {
            browserHost.SendMouseClickEvent(e.X, e.Y, MouseEvent(e), true, 1, CefEventFlags.None);
        }

        private void _botWindow_MouseUp(object sender, MouseEventArgs e)
        {
            browserHost.SendMouseClickEvent(e.X, e.Y, MouseEvent(e), false, 1, CefEventFlags.None);
        }

        private MouseButtonType MouseEvent(MouseEventArgs e)
        {
            MouseButtonType mType = MouseButtonType.Left;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    mType = MouseButtonType.Left;
                    break;
                case MouseButtons.Right:
                    mType = MouseButtonType.Right;
                    break;
                case MouseButtons.Middle:
                    mType = MouseButtonType.Middle;
                    break;
                default:
                    break;
            }

            return mType;
        }

        internal override void BlockInput()
        {
            if (input)
            {
                _botWindow.MouseMove -= _botWindow_MouseMove;
                _botWindow.MouseUp -= _botWindow_MouseUp;
                _botWindow.MouseDown -= _botWindow_MouseDown;
                _bot.core.mainWindow.KeyPress -= MainWindow_KeyPress;
                _botWindow.MouseWheel -= _botWindow_MouseWheel;
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
                return browserBitmap;
            }
        }

        internal override void GetFocus()
        {
            Core.ExeThreadSafe(delegate
            {
                this.Focus();
            });
        }
    }
}
