using CefSharp;
using System.Threading;
using w3bot.Util;

namespace w3bot.Wrapper.Input
{
    class ChromiumMouse : IMouseInput
    {
        private CefSharp.IBrowser _browser;
        private MouseEvent _mouseEvent;

        internal ChromiumMouse(CefSharp.IBrowser browser)
        {
            _browser = browser;
            _mouseEvent = new MouseEvent();
        }

        /// <summary>
        /// Injects a mouse click in the bot window.
        /// </summary>
        /// <param name="button">The button type.</param>
        /// <param name="evt">The key event.</param>
        public void Click(Keys.Button button, Keys.Event evt)
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
                    down = true;
                    up = true;
                    break;
                default:
                    break;
            }

            // Executes mouse click
            _browser.GetHost().SendMouseClickEvent(_mouseEvent, mouseButtonType, up, 1);
            Thread.Sleep(100);
            _browser.GetHost().SendMouseClickEvent(_mouseEvent, mouseButtonType, down, 1);
        }

        /// <summary>
        /// Injects a mouse move in the bot window.
        /// </summary>
        /// <param name="x">X coordinate where to move.</param>
        /// <param name="y">Y coordinate where to move.</param>
        public void Move(int x, int y)
        {
            _mouseEvent = new MouseEvent(x, y, CefEventFlags.None);
            _browser.GetHost().SendMouseMoveEvent(_mouseEvent, false);
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
            _browser.GetHost().SendMouseWheelEvent(_mouseEvent.X, _mouseEvent.Y, hort, vert, CefEventFlags.None);
        }
    }
}
