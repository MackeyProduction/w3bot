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
using w3bot.GUI.Service;
using w3bot.Input;
using w3bot.Listener;
using w3bot.Util;
using w3bot.Wrapper;

namespace w3bot.Script
{
    public class Bot
    {
        internal delegate void Drawable(Graphics g);
        internal Size ClientSize { get { return _form.Size; } }
        internal Size FrameSize { get; }
        internal static Form _form;
        private static CoreService _core;
        private static FormService _formService;
        private static IProcessorService _processorService;
        private static IProcessorCreateService _processorCreateService;
        private static IExecutable _executable;
        private IProcessor _processor;

        public static MethodProvider Methods { get; private set; }

        public Bot()
        {

        }

        internal void AddConfiguration(FormService formService, CoreService core, IExecutable executable, MethodProvider methodProvider)
        {
            _core = core;
            _formService = formService;
            _executable = executable;
            _processorService = _core.GetProcessors();
            _processorCreateService = _core.GetCreateService();
            Methods = methodProvider;
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
        /// Gets a service for handling the form controls.
        /// </summary>
        /// <returns>Returns an instance of FormService.</returns>
        internal FormService GetFormService()
        {
            return _formService;
        }

        /// <summary>
        /// Initialize an instance of BotWindow with integrated browser processor.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        public void CreateBrowserWindow(string name = "View")
        {
            CreateWindow(name, ProcessorType.BrowserProcessor).Load();
        }

        /// <summary>
        /// Initialize an instance of BotWindow with integrated applet processor.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        public void CreateAppletWindow(string name = "View")
        {
            CreateWindow(name, ProcessorType.AppletProcessor).Load();
        }

        /// <summary>
        /// Initialize an instance of BotWindow.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        /// <param name="type">The processor type.</param>
        /// <returns>Returns an instance of BotWindow.</returns>
        internal IBotWindow CreateWindow(string name, ProcessorType type)
        {
            if (ProcessorType.AppletProcessor == type)
                throw new InvalidOperationException(String.Format("The {0} isn't supported yet. Please use the {1} instead.", type, ProcessorType.BrowserProcessor));

            if (_processorCreateService.GetAll().Count == 1)
                _processorCreateService.Remove(type);

            _processorCreateService.Add(type);
            _processor = _processorService.GetProcessor(type);

            if (_processor == null)
                throw new InvalidOperationException(String.Format("The processor by the type {0} could not be found.", type.ToString()));

            return new BotWindow(name, _processor, _formService);
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
            var tabs = (TabControl)_formService.GetFormControlByType(typeof(TabControl));
            tabs.TabPages.Clear();
        }
    }
}
