using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Drawing;
using System.Threading;
using w3bot.Core.Processor;
using w3bot.Event;
using w3bot.Input;
using w3bot.Script;
using w3bot.Util;

namespace w3bot.Wrapper.Input
{
    internal class ChromiumMouse : IMouseInput
    {
        private ChromiumWebBrowser _browser;
        private CefSharp.MouseEvent _mouseEvent;
        private static Point _position;

        internal ChromiumMouse(ChromiumWebBrowser browser)
        {
            _browser = browser;
            _position = new Point(0, 0);
            _mouseEvent = new CefSharp.MouseEvent();
        }

        /// <summary>
        /// The current mouse position.
        /// </summary>
        public Point Position
        { 
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        /// <summary>
        /// Injects a mouse click in the bot window.
        /// </summary>
        /// <param name="button">The button type.</param>
        /// <param name="evt">The key event.</param>
        public void Click(Keys.Button button, Keys.Event evt)
        {
            Bot.ExeThreadSafe(delegate
            {
                if (_browser.GetMainFrame().IsMain)
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
                            up = false;
                            break;
                        case Keys.Event.UP:
                            up = true;
                            down = false;
                            break;
                        case Keys.Event.DOWNUP:
                            down = false;
                            up = true;
                            break;
                        default:
                            break;
                    }

                    // Executes mouse click
                    _browser.GetBrowserHost().SendMouseClickEvent(_mouseEvent, mouseButtonType, up, 1);
                    Thread.Sleep(100);
                    _browser.GetBrowserHost().SendMouseClickEvent(_mouseEvent, mouseButtonType, down, 1);
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
            Bot.ExeThreadSafe(delegate
            {
                _position = new Point(x, y);
                _mouseEvent = new CefSharp.MouseEvent(x, y, CefEventFlags.None);

                if (_browser.GetMainFrame().IsMain)
                {
                    _browser.GetBrowserHost().SendMouseMoveEvent(_mouseEvent, false);
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

            _browser.GetBrowserHost().SendMouseWheelEvent(_mouseEvent.X, _mouseEvent.Y, hort, vert, CefEventFlags.None);
        }
    }
}
