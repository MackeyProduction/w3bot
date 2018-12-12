using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Bot;
using w3bot.Core;
using w3bot.Interfaces;

namespace w3bot.Wrapper
{
    internal class KeyboardAdapter : IKeyboardInput
    {
        internal Bot.Bot _bot;
        internal BotWindow _botWindow;
        internal ChromiumWebBrowser _chromiumBrowser;

        internal KeyboardAdapter(Bot.Bot bot)
        {
            _bot = bot;
            if (_bot.botWindow == null) throw new InvalidOperationException("The Botwindow isn't initialized. Please initialize the botwindow with the Initialize() method.");
            _botWindow = _bot.botWindow;
            _chromiumBrowser = _botWindow._chromiumBrowser;
        }

        public void KeyEvent(char c)
        {
            Core.Core.ExeThreadSafe(delegate
            {
                _chromiumBrowser.FrameLoadEnd += (sender, args) =>
                {
                    args.Browser.GetHost().SendKeyEvent(new CefSharp.KeyEvent());
                };
            });
        }
    }
}
