using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using w3bot.Bot.Processor;
using w3bot.Core.Bot;
using w3bot.Input;
using w3bot.Listener;
using w3bot.Util;
using w3bot.Wrapper;

namespace w3bot.Bot
{
    public class Bot
    {
        internal delegate void Drawable(Graphics g);
        internal static event Drawable paintings = delegate { };
        internal delegate void EventHandlerDelegate(object sender, EventArgs e);
        internal static event EventHandlerDelegate EvtHandler = delegate { };
        internal Size ClientSize { get { return _core.mainWindow.Size; } }
        internal Size FrameSize { get; }
        internal TabControl botTab { get { return _core.tabs; } set { } }
        private BotWindow _botWindow;
        internal BotWindow botWindow { get { return _botWindow; } set { _botWindow = value; } }
        private BotSettings _botSettings;
        internal BotSettings botSettings { get { return _botSettings; } set { _botSettings = value; } }
        private static Core.Core _core;
        internal Core.Core core { get { return _core; } set { _core = value; } }
        private IEnumerable<IProcessor> _processors;

        internal static void AddConfiguration(Core.Core core)
        {
            _core = core;
        }

        public Bot(IEnumerable<IProcessor> processors)
        {
            _processors = processors;
        }

        public BotWindow CreateWindow(string name = "View", ProcessorType type = ProcessorType.BrowserProcessor)
        {
            return new BotWindow(name, _processors.Single(item => item.GetType().ToString() == type.ToString()));
        }

        public BotWindow CreateBrowserWindow(string name = "View")
        {
            return CreateWindow(name, ProcessorType.BrowserProcessor);
        }

        public BotWindow CreateAppletWindow(string name = "View")
        {
            return CreateWindow(name, ProcessorType.AppletProcessor);
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
