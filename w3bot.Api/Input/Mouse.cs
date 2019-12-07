﻿using System;
using System.Drawing;
using w3bot.Util;
using w3bot.Wrapper;

namespace w3bot.Input
{
    public static class Mouse
    {
        private static MouseAdapter _mouseAdapter = null;
        private static IMouseInput _mouse = null;

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
            _mouseAdapter.Wheel(direction, amount);
        }

        [Obsolete("The method is deprecated. Use the method with interface implementation instead.")]
        internal static void AddConfiguration(Bot.Bot bot)
        {
            _mouseAdapter = bot.botSettings.inputAdapter.mouseAdapter;
        }

        internal static void AddConfiguration(IMouseInput mouse)
        {
            _mouse = mouse;
        }
    }
}
