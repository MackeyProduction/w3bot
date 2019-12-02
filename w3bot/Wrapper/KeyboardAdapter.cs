using CefSharp.OffScreen;
using System;
using w3bot.Core.Bot;

namespace w3bot.Wrapper
{
    internal class KeyboardAdapter : IKeyboardInput
    {
        internal w3bot.Bot.Bot _bot;
        internal BotWindow _botWindow;
        internal ChromiumWebBrowser _chromiumBrowser;

        [Obsolete("The class will soon be deprecated. Use the input classes instead.")]
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
