using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using w3bot.Core;
using w3bot.Core.Bot;
using w3bot.Core.Processor;
using w3bot.Core.Utilities;
using w3bot.Event;
using w3bot.Input;
using w3bot.Listener;
using w3bot.Util;
using w3bot.Wrapper;

namespace w3bot.Script
{
    public abstract class Bot
    {
        internal delegate void Drawable(Graphics g);
        internal static event Drawable paintings = delegate { };
        internal delegate void EventHandlerDelegate(object sender, EventArgs e);
        internal static event EventHandlerDelegate EvtHandler = delegate { };
        internal Size ClientSize { get { return _form.Size; } }
        internal Size FrameSize { get; }
        private static CoreService _core;
        private static Form _form;
        private static IProcessorService _processorService;
        private static IExecutable _executable;

        internal static void AddConfiguration(Form form, CoreService core, IExecutable executable)
        {
            _core = core;
            _form = form;
            _executable = executable;
            _processorService = _core.GetProcessors();
        }

        /// <summary>
        /// Gets all relevant info by the core.
        /// </summary>
        /// <returns>Returns an instance of CoreService.</returns>
        internal CoreService GetCoreService()
        {
            return _core;
        }

        /// <summary>
        /// Gets all running deamons.
        /// </summary>
        /// <returns>Returns an instance of executable.</returns>
        internal IExecutable GetDaemons()
        {
            return _executable;
        }

        /// <summary>
        /// Initialize an instance of BotWindow with integrated browser processor.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        /// <returns>Returns an instance of BotWindow.</returns>
        public IBotWindow CreateBrowserWindow(string name = "View")
        {
            return CreateWindow(name, ProcessorType.BrowserProcessor);
        }

        /// <summary>
        /// Initialize an instance of BotWindow with integrated applet processor.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        /// <returns>Returns an instance of BotWindow.</returns>
        public IBotWindow CreateAppletWindow(string name = "View")
        {
            return CreateWindow(name, ProcessorType.AppletProcessor);
        }

        /// <summary>
        /// Initialize an instance of BotWindow.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        /// <param name="type">The processor type.</param>
        /// <returns>Returns an instance of BotWindow.</returns>
        private IBotWindow CreateWindow(string name, ProcessorType type)
        {
            return new BotWindow(name, _processorService.GetProcessor(type));
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
