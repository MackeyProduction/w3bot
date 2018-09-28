using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.bot;
using w3bot.enumeration;
using w3bot.interfaces;
using w3bot.wrapper;

namespace w3bot.evt
{
    public static class Mouse
    {
        private static MouseAdapter _mouseAdapter = null;

        /// <summary>
        /// Injects a mouse click in the bot window.
        /// </summary>
        /// <param name="button">The button type.</param>
        /// <param name="evt">The key event.</param>
        public static void Click(Keys.Button button, Keys.Event evt)
        {
            _mouseAdapter.Click(button, evt);
        }

        /// <summary>
        /// Injects a mouse move in the bot window.
        /// </summary>
        /// <param name="x">X coordinate where to move.</param>
        /// <param name="y">Y coordinate where to move.</param>
        public static void Move(int x, int y)
        {
            _mouseAdapter.Move(x, y);
        }

        /// <summary>
        /// Injects a mouse wheel event in the bot window.
        /// </summary>
        /// <param name="wheel">Wheel key.</param>
        /// <param name="amount">The amount of wheeling.</param>
        public static void Wheel(Keys.Wheel wheel, int amount)
        {
            _mouseAdapter.Wheel(wheel, amount);
        }

        /// <summary>
        /// Injects a mouse move in the bot window.
        /// </summary>
        /// <param name="point">Point where to move.</param>
        public static void Move(Point point)
        {
            Move(point.X, point.Y);
        }

        internal static void AddConfiguration(Bot bot)
        {
            _mouseAdapter = bot.botSettings.inputAdapter.mouseAdapter;
        }
    }
}
