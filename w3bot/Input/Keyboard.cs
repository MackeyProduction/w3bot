using System;
using System.Threading;
using w3bot.Wrapper;

namespace w3bot.Input
{
    public static class Keyboard
    {
        private static IKeyboardInput _keyboard;

        /// <summary>
        /// Injects a key press in the bot window.
        /// </summary>
        /// <param name="key">Represents a key.</param>
        public static void PressKey(Keys key)
        {
            PressKey((char)key);
        }

        /// <summary>
        /// Injects a key press in the bot window.
        /// </summary>
        /// <param name="key">Represents a key.</param>
        public static void PressKey(char key)
        {
            _keyboard.KeyEvent(key);
        }

        /// <summary>
        /// Injects a text in the bot window.
        /// </summary>
        /// <param name="keys">Represents a key.</param>
        /// <param name="msPerKeyMin">The minimum delay of key press in miliseconds.</param>
        /// <param name="msPerKeyMax">The maximum delay of key press in miliseconds.</param>
        public static void PressKeys(string keys, int msPerKeyMin = 0, int msPerKeyMax = 0)
        {
            var random = new Random();

            if (msPerKeyMin < 0 || msPerKeyMax < 0)
            {
                throw new ArgumentException("The delay time can't be negative.");
            }

            if (msPerKeyMax < msPerKeyMin)
            {
                throw new ArgumentException("Max delay time can't be smaller than min delay time.");
            }

            if (msPerKeyMin > 0)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    PressKey(keys[i]);
                    Thread.Sleep(random.Next(msPerKeyMin, msPerKeyMax));
                }
            }
            else
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    PressKey(keys[i]);
                }
            }
        }

        /// <summary>
        /// Injects a text in the bot window.
        /// </summary>
        /// <param name="keys">Represents a key.</param>
        /// <param name="msPerKeyMin">The minimum delay of key press in miliseconds.</param>
        /// <param name="msPerKeyMax">The maximum delay of key press in miliseconds.</param>
        public static void PressKeys(Keys[] keys, int msPerKeyMin = 0, int msPerKeyMax = 0)
        {
            char[] array = new char[keys.Length];

            for (int i = 0; i < keys.Length; i++)
            {
                array[i] = (char)keys[i];
            }

            PressKeys(array.ToString(), msPerKeyMin, msPerKeyMax);
        }

        public enum Keys : byte
        {
            ESC = 0x1B,
            TAB = 0x09,
            CAPS_LOCK = 0x14,
            SHIFT = 0x10,
            CONTROL = 0x11,
            ALT = 0x12,
            SPACEBAR = 0x20,
            ENTER = 0x0D,
            BACKSPACE = 0x08,

            INSERT = 0x2D,
            DELETE = 0x2E,

            END = 0x23,
            HOME = 0x24,

            PAGE_UP = 0x21,
            PAGE_DOWN = 0x22,

            LEFT_ARROW = 0x25,
            UP_ARROW = 0x26,
            RIGHT_ARROW = 0x27,
            DOWN_ARROW = 0x28,

            _0 = 0x30,
            _1 = 0x31,
            _2 = 0x32,
            _3 = 0x33,
            _4 = 0x34,
            _5 = 0x35,
            _6 = 0x36,
            _7 = 0x37,
            _8 = 0x38,
            _9 = 0x39,

            A = 0x41,
            B = 0x42,
            C = 0x43,
            D = 0x44,
            E = 0x45,
            F = 0x46,
            G = 0x47,
            H = 0x48,
            I = 0x49,
            J = 0x4A,
            K = 0x4B,
            L = 0x4C,
            M = 0x4D,
            N = 0x4E,
            O = 0x4F,
            P = 0x50,
            Q = 0x51,
            R = 0x52,
            S = 0x53,
            T = 0x54,
            U = 0x55,
            V = 0x56,
            W = 0x57,
            X = 0x58,
            Y = 0x59,
            Z = 0x5A,

            F1 = 0x70,
            F2 = 0x71,
            F3 = 0x72,
            F4 = 0x73,
            F5 = 0x74,
            F6 = 0x75,
            F7 = 0x76,
            F8 = 0x77,
            F9 = 0x78,
            F10 = 0x79,
            F11 = 0x7A,
            F12 = 0x7B
        }

        internal static void AddConfiguration(IKeyboardInput keyboard)
        {
            _keyboard = keyboard;
        }
    }
}
