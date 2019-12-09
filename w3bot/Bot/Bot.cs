using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using w3bot.Core.Bot;
using w3bot.Core.Processor;
using w3bot.Core.Utilities;
using w3bot.Input;
using w3bot.Listener;
using w3bot.Util;
using w3bot.Wrapper;

namespace w3bot.Bot
{
    public abstract class Bot
    {
        internal delegate void Drawable(Graphics g);
        internal static event Drawable paintings = delegate { };
        internal delegate void EventHandlerDelegate(object sender, EventArgs e);
        internal static event EventHandlerDelegate EvtHandler = delegate { };
        internal Size ClientSize { get { return _form.Size; } }
        internal Size FrameSize { get; }
        internal BotWindow botWindow { get; set; }
        private static Core.Core _core;
        internal Core.Core core { get { return _core; } set { _core = value; } }
        private static Form _form;
        private static IProcessorService _processorService;

        internal static void AddConfiguration(Core.Core core, Form form)
        {
            _core = core;
            _form = form;
            _processorService = _core.GetProcessors();
        }

        /// <summary>
        /// Initialize an instance of BotWindow with integrated browser processor.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        /// <returns>Returns an instance of BotWindow.</returns>
        public BotWindow CreateBrowserWindow(string name = "View")
        {
            return CreateWindow(name, ProcessorType.BrowserProcessor);
        }

        /// <summary>
        /// Initialize an instance of BotWindow with integrated applet processor.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        /// <returns>Returns an instance of BotWindow.</returns>
        public BotWindow CreateAppletWindow(string name = "View")
        {
            return CreateWindow(name, ProcessorType.AppletProcessor);
        }

        private BotWindow CreateWindow(string name, ProcessorType type)
        {
            return new BotWindow(name, _processorService.GetProcessor(type));
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

        /// <summary>
        /// Execute the action in a safe thread to avoid thread crashes.
        /// </summary>
        /// <param name="a">Executes the action.</param>
        internal static void ExeThreadSafe(Action a)
        {
            if (_form.InvokeRequired)
                _form.Invoke((MethodInvoker)delegate { a(); });
            else
                a();
        }

        /// <summary>
        /// Clears all tab pages.
        /// </summary>
        internal static void ReInit()
        {
            var tabs = (TabControl)_form.Controls.Find("", true)[0];
            tabs.TabPages.Clear();
        }
    }
}
