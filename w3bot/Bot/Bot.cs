using CefSharp.OffScreen;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using w3bot.Core;
using w3bot.Core.Bot;
using w3bot.Core.Processor;
using w3bot.Input;
using w3bot.Listener;
using w3bot.Wrapper;

namespace w3bot.Bot
{
    public class Bot
    {
        internal delegate void Drawable(Graphics g);
        internal static event Drawable paintings = delegate { };
        internal delegate void EventHandlerDelegate(object sender, EventArgs e);
        internal static event EventHandlerDelegate EvtHandler = delegate { };
        public ChromiumWebBrowser browser { get; set; }
        internal Size ClientSize { get { return _core.mainWindow.Size; } }
        internal Size FrameSize { get; }
        internal TabControl botTab { get { return _core.tabs; } set { } }
        private BotWindow _botWindow;
        internal BotWindow botWindow { get { return _botWindow; } set { _botWindow = value; } }
        private BotSettings _botSettings;
        internal BotSettings botSettings { get { return _botSettings; } set { _botSettings = value; } }
        private static Core.Core _core;
        internal Core.Core core { get { return _core; } set { _core = value; } }

        internal static void AddConfiguration(Core.Core core)
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

        //public BotWindow CreateBrowserWindow(string name = "View")
        //{
        //    return new BotWindow(name, new WebProcessor(null, null));
        //}

        //public BotWindow CreateAppletWindow(string name = "View")
        //{
        //    return new BotWindow(name, new AppletProcessor());
        //}

        /// <summary>
        /// Initializes all necessarily settings for the BotWindow. After initializing you need to use the Open() method to open the window.
        /// </summary>
        /// <param name="botWindow"></param>
        /// @TODO: Remove this method and move code in BotWindow class.
        public void Initialize(BotWindow botWindow)
        {
            _botWindow = botWindow;
            _botSettings = new BotSettings();
            _botSettings.browserAdapter = new BrowserAdapter(this);
            _botSettings.inputAdapter = new InputAdapter(new MouseAdapter(this), new KeyboardAdapter(this));

            // add configuration
            Browser.AddConfiguration(this);
            Mouse.AddConfiguration(this);
            Frame.AddConfiguration(this);
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

        internal void ExecuteUserEvents(object sender, EventArgs e)
        {

        }
    }
}
