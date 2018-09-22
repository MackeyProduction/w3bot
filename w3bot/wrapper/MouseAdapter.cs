using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.core;
using w3bot.enumeration;
using w3bot.interfaces;

namespace w3bot.wrapper
{
    internal class MouseAdapter : IMouseInput
    {
        internal Bot _bot;
        internal BotWindow _botWindow;
        internal ChromiumWebBrowser _chromiumBrowser;

        /// <summary>
        /// w3bot instance for MouseAdapter.
        /// </summary>
        /// <param name="bot">The current bot instance.</param>
        internal MouseAdapter(Bot bot)
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
            Core.ExeThreadSafe(delegate
            {
                _chromiumBrowser.FrameLoadEnd += (sender, args) =>
                {
                    if (args.Frame.IsMain)
                    {
                        MouseButtonType mouseButtonType = 0;
                        bool up = false;
                        bool down = false;

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
                        
                        if (evt == Keys.Event.DOWN || evt == Keys.Event.DOWNUP)
                        {
                            down = true;
                        }

                        if (evt == Keys.Event.UP || evt == Keys.Event.DOWNUP)
                        {
                            up = true;
                            down = false;
                        }

                        // Executes mouse click
                        args.Browser.GetHost().SendMouseClickEvent(new MouseEvent(), mouseButtonType, up, 1);
                        System.Threading.Thread.Sleep(100);
                        args.Browser.GetHost().SendMouseClickEvent(new MouseEvent(), mouseButtonType, down, 1);
                    }
                };
            });
        }

        /// <summary>
        /// Injects a mouse move in the bot window.
        /// </summary>
        /// <param name="x">X coordinate where to move.</param>
        /// <param name="y">Y coordinate where to move.</param>
        public void Move(int x, int y)
        {
            Core.ExeThreadSafe(delegate
            {
                _chromiumBrowser.FrameLoadEnd += (sender, args) =>
                {
                    if (args.Frame.IsMain)
                    {
                        args.Browser.GetHost().SendMouseMoveEvent(new CefSharp.MouseEvent(x, y, CefSharp.CefEventFlags.None), false);
                    }
                };
            });
        }

        /// <summary>
        /// Injects a wheel in the bot window.
        /// </summary>
        /// <param name="wheel">Wheel key.</param>
        /// <param name="amount">The amount of wheeling.</param>
        public void Wheel(Keys.Wheel wheel, int amount)
        {
            Core.ExeThreadSafe(delegate
            {
                _chromiumBrowser.FrameLoadEnd += (sender, args) =>
                {
                    if (args.Frame.IsMain)
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
                        args.Browser.GetHost().SendMouseWheelEvent(new MouseEvent(), vert, hort);
                    }
                };
            });
        }
    }
}
