using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using w3bot.Util;
using w3bot.Wrapper;

namespace w3bot.Input
{
    public class Mouse
    {
        private static IMouseInput _mouse;

        /// <summary>
        /// Injects a left mouse click in the bot window.
        /// </summary>
        public static void LeftClick(int x = -1, int y = -1)
        {
            Click(Keys.Button.LEFT, Keys.Event.DOWNUP, x, y);
        }

        /// <summary>
        /// Injects a left mouse click in the bot window.
        /// </summary>
        /// <param name="destination">Point where to click.</param>
        public static void LeftClick(Point destination)
        {
            Click(Keys.Button.LEFT, Keys.Event.DOWNUP, destination.X, destination.Y);
        }

        /// <summary>
        /// Injects a right mouse click in the bot window.
        /// </summary>
        public static void RightClick(int x = -1, int y = -1)
        {
            Click(Keys.Button.RIGHT, Keys.Event.DOWNUP, x, y);
        }

        /// <summary>
        /// Injects a right mouse click in the bot window.
        /// </summary>
        /// <param name="destiation">Point where to click.</param>
        public static void RightClick(Point destiation)
        {
            Click(Keys.Button.RIGHT, Keys.Event.DOWNUP, destiation.X, destiation.Y);
        }

        /// <summary>
        /// Injects a middle mouse click in the bot window.
        /// </summary>
        public static void MiddleClick(int x = -1, int y = -1)
        {
            Click(Keys.Button.MIDDLE, Keys.Event.DOWNUP, x, y);
        }

        /// <summary>
        /// Injects a middle mouse click in the bot window.
        /// </summary>
        /// <param name="destiation">Point where to click.</param>
        public static void MiddleClick(Point destiation)
        {
            Click(Keys.Button.MIDDLE, Keys.Event.DOWNUP, destiation.X, destiation.Y);
        }

        /// <summary>
        /// Injects a left mouse click in the bot window.
        /// </summary>
        public static void Click(Keys.Button button = Keys.Button.LEFT, int x = -1, int y = -1)
        {
            Click(button, Keys.Event.DOWNUP, x, y);
        }

        /// <summary>
        /// Injects a mouse click in the bot window.
        /// </summary>
        /// <param name="button">The button type.</param>
        /// <param name="evt">The key event.</param>
        public static void Click(Keys.Button button, Keys.Event evt, int x = -1, int y = -1)
        {
            Move(x, y);
            _mouse.Click(button, evt);
        }

        /// <summary>
        /// Injects a mouse move in the bot window.
        /// </summary>
        /// <param name="x">X coordinate where to move.</param>
        /// <param name="y">Y coordinate where to move.</param>
        public static void Move(int x, int y, bool generatePath = true, double speed = 2.0)
        {
            if (x < 0 || y < 0)
                return;

            if (generatePath)
            {
                Point start = _mouse.Position;
                Point path = new Point(x - start.X, y - start.Y);
                double time = Math.Sqrt(Math.Pow(path.X, 2) + Math.Pow(path.Y, 2)) * speed; //pathlenght * speed

                Stopwatch sw = new Stopwatch();
                sw.Start();

                double ratio = sw.ElapsedMilliseconds / time;
                do
                {
                    _mouse.Move(start.X + (int)(path.X * ratio), start.Y + (int)(path.Y * ratio)); //follow the path
                    ratio = sw.ElapsedMilliseconds / time;
                    Thread.Sleep(1);
                }
                while (ratio <= 1.0);
                sw.Stop();
            }
            _mouse.Move(x, y);
        }

        /// <summary>
        /// Injects a mouse wheel event in the bot window.
        /// </summary>
        /// <param name="wheel">Wheel key.</param>
        /// <param name="amount">The amount of wheeling.</param>
        public static void Wheel(Keys.Wheel wheel, int amount)
        {
            _mouse.Wheel(wheel, amount);
        }

        /// <summary>
        /// Injects a mouse move in the bot window.
        /// </summary>
        /// <param name="point">Point where to move.</param>
        public static void Move(Point point)
        {
            Move(point.X, point.Y);
        }

        /// <summary>
        /// Injects a mouse wheel event to top in the bot window.
        /// </summary>
        /// <param name="amount">The amount of wheeling.</param>
        public static void ScrollUp(int amount = 1)
        {
            Wheel(Keys.Wheel.UP, amount);
        }

        /// <summary>
        /// Injects a mouse wheel event to bottom in the bot window.
        /// </summary>
        /// <param name="amount">The amount of wheeling.</param>
        public static void ScrollDown(int amount = 1)
        {
            Wheel(Keys.Wheel.DOWN, amount);
        }

        /// <summary>
        /// Injects a mouse wheel event in the bot window.
        /// </summary>
        /// <param name="direction">The direction where to scroll.</param>
        /// <param name="amount">The amount of wheeling.</param>
        public static void Scroll(Keys.Wheel direction = Keys.Wheel.DOWN, int amount = 1)
        {
            _mouse.Wheel(direction, amount);
        }

        internal static void AddConfiguration(IMouseInput mouse)
        {
            _mouse = mouse;
        }
    }
}
