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
using w3bot.enumeration;
using w3bot.interfaces;
using w3bot.wrapper;

namespace w3bot.core
{
    class BotProcessor : AbstractBotProcessor
    {
        public static ChromiumWebBrowser chromiumBrowser { get; set; }
        internal Bot _bot;

        public BotProcessor(Bot bot)
        {
            _bot = bot;

            if (!Cef.IsInitialized)
            {
                // load cef settings
                CefSettings settings = new CefSettings();
                settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";

                // init settings
                Cef.Initialize(settings);
            }

            chromiumBrowser = new ChromiumWebBrowser("https://www.google.com/");
            chromiumBrowser.FrameLoadEnd += ChromiumBrowser_FrameLoadEnd;
            chromiumBrowser.Size = ClientSize;
            _bot.browser = chromiumBrowser;
        }

        private void ChromiumBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                chromiumBrowser.Load("http://github.com");
                chromiumBrowser.FrameLoadEnd -= ChromiumBrowser_FrameLoadEnd;
            }
        }

        internal override void ActivateProcessor()
        {
        }

        internal override void AllowInput()
        {
        }

        internal override void BlockInput()
        {
        }

        internal override void Destroy()
        {
        }

        public ChromiumWebBrowser GetBrowser()
        {
            return chromiumBrowser;
        }
    }
}
