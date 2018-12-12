using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using w3bot.Bot;
using w3bot.Core;
using w3bot.Enumeration;
using w3bot.Evt;
using w3bot.Interfaces;

namespace w3bot.Wrapper
{
    internal class MouseAdapter : IMouseInput
    {
        internal Bot.Bot _bot;
        internal BotWindow _botWindow;
        internal ChromiumWebBrowser _chromiumBrowser;
        internal MouseEvent _mouseEvent;

        /// <summary>
        /// w3bot instance for MouseAdapter.
        /// </summary>
        /// <param name="bot">The current bot instance.</param>
        internal MouseAdapter(Bot.Bot bot)
        {
            _bot = bot;
            if (_bot.botWindow == null) throw new InvalidOperationException("The Botwindow isn't initialized. Please initialize the botwindow with the Initialize() method.");
            _botWindow = _bot.botWindow;
            _chromiumBrowser = _botWindow._chromiumBrowser;
        }

        /// <summary>
        /// Injects a mouse click in the bot window.
        /// </summary>
        /// <param name="button">The button type.</param>
        /// <param name="evt">The key event.</param>
        public void Click(Keys.Button button, Keys.Event evt)
        {
            Core.Core.ExeThreadSafe(delegate
            {
                if (_chromiumBrowser.GetMainFrame().IsMain)
                {
                    MouseButtonType mouseButtonType = 0;
                    bool up = false;
                    bool down = false;

                    // get button type
                    switch (button)
                    {
                        case Keys.Button.LEFT:
                            mouseButtonType = MouseButtonType.Left;
                            break;
                        case Keys.Button.MIDDLE:
                            mouseButtonType = MouseButtonType.Middle;
                            break;
                        case Keys.Button.RIGHT:
                            mouseButtonType = MouseButtonType.Right;
                            break;
                    }
                    
                    // get button event
                    switch (evt)
                    {
                        case Keys.Event.NULL:
                            break;
                        case Keys.Event.DOWN:
                            down = true;
                            break;
                        case Keys.Event.UP:
                            up = true;
                            down = false;
                            break;
                        case Keys.Event.DOWNUP:
                            down = true;
                            up = true;
                            break;
                        default:
                            break;
                    }

                    // Executes mouse click
                    _chromiumBrowser.GetBrowserHost().SendMouseClickEvent(_mouseEvent, mouseButtonType, up, 1);
                    Thread.Sleep(100);
                    _chromiumBrowser.GetBrowserHost().SendMouseClickEvent(_mouseEvent, mouseButtonType, down, 1);
                }
            });
        }

        /// <summary>
        /// Injects a mouse move in the bot window.
        /// </summary>
        /// <param name="x">X coordinate where to move.</param>
        /// <param name="y">Y coordinate where to move.</param>
        public void Move(int x, int y)
        {
            Core.Core.ExeThreadSafe(delegate
            {
                if (_chromiumBrowser.GetMainFrame().IsMain)
                {
                    _mouseEvent = new MouseEvent(x, y, CefEventFlags.None);
                    _chromiumBrowser.GetBrowserHost().SendMouseMoveEvent(_mouseEvent, false);
                }
            });
        }

        /// <summary>
        /// Injects a wheel in the bot window.
        /// </summary>
        /// <param name="wheel">Wheel key.</param>
        /// <param name="amount">The amount of wheeling.</param>
        public void Wheel(Keys.Wheel wheel, int amount)
        {
            Core.Core.ExeThreadSafe(delegate
            {
                if (_chromiumBrowser.GetMainFrame().IsMain)
                {
                    int vert = 0, hort = 0;
                    switch (wheel)
                    {
                        case Keys.Wheel.DOWN:
                            vert += amount;
                            break;
                        case Keys.Wheel.LEFT:
                            hort -= amount;
                            break;
                        case Keys.Wheel.RIGHT:
                            hort += amount;
                            break;
                        case Keys.Wheel.UP:
                            vert -= amount;
                            break;
                    }
                    _chromiumBrowser.GetBrowserHost().SendMouseWheelEvent(new MouseEvent(), vert, hort);
                }
            });
        }
    }
}
