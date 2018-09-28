using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.bot;
using w3bot.core;
using w3bot.evt;
using w3bot.wrapper;

namespace w3bot.bot
{
    public class Bot
    {
        internal delegate void Drawable(Graphics g);
        internal static event Drawable paintings = delegate { };
        public ChromiumWebBrowser browser { get; set; }
        internal Size ClientSize { get { return _core.mainWindow.Size; } }
        internal Size FrameSize { get; }
        internal TabControl botTab { get { return _core.tabs; } set { } }
        private BotWindow _botWindow;
        internal BotWindow botWindow { get { return _botWindow; } set { _botWindow = value; } }
        private BotSettings _botSettings;
        internal BotSettings botSettings { get { return _botSettings; } set { _botSettings = value; } }
        private static Core _core;
        internal Core core { get { return _core; } set { _core = value; } }

        internal static void AddConfiguration(Core core)
        {
            _core = core;
        }

        /// <summary>
        /// Creates a new BotWindow which allows you to send input.
        /// </summary>
        /// <param name="name">Bot window name.</param>
        /// <param name="url">Url of the bot window.</param>
        /// <returns>Returns an BotWindow object.</returns>
        public BotWindow CreateBrowserWindow(string name = "View", string url = "")
        {
            return new BotWindow(this, name, url, new BotProcessor(this));
        }

        /// <summary>
        /// Initializes all necessarily settings for the BotWindow. After initializing you need to use the Open() method to open the window.
        /// </summary>
        /// <param name="botWindow"></param>
        public void Initialize(BotWindow botWindow)
        {
            _botWindow = botWindow;
            _botSettings = new BotSettings();
            _botSettings.browserAdapter = new BrowserAdapter(this);
            _botSettings.inputAdapter = new InputAdapter(new MouseAdapter(this), new KeyboardAdapter(this));
            
            // add configuration
            Browser.AddConfiguration(this);
            Mouse.AddConfiguration(this);
            Debug.AddConfiguration(this);

            if (botWindow._url != "")
                Browser.Navigate(botWindow._url);
        }

        /// <summary>
        /// Pauses the current running script for 1000 milliseconds (1 second)
        /// </summary>
        public static void Sleep()
        {
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Pauses the current running script for a given time.
        /// </summary>
        /// <param name="delay"></param>
        public static void Sleep(int delay)
        {
            Thread.Sleep(delay);
        }

        /// <summary>
        /// Pauses the current running script for a given time. The time will be a random value between the two given parameters
        /// </summary>
        /// <param name="minDelay">The minimum time in milliseconds to sleep</param>
        /// <param name="maxDelay">The maximum time in milliseconds to sleep</param>
        public static void Sleep(int minDelay, int maxDelay)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            int delay = ran.Next(minDelay, maxDelay + 1);
            Thread.Sleep(delay);
        }

        /// <summary>
        /// Refreshs the paint of the current bot window.
        /// </summary>
        /// <param name="g"></param>
        internal void RefreshPaints(Graphics g)
        {
            paintings(g);
        }
    }
}
