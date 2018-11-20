using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using w3bot.wrapper;
using System.Threading;
using w3bot.bot;

namespace w3bot.core
{
    internal class Core : Form
    {
        internal Form mainWindow { get; set; }
        internal static CoreInformation coreInformation { get { return new CoreInformation(); } }
        private static Bot _bot;
        internal static Bot bot { get { return _bot; } set { _bot = value; } }
        internal RichTextBox logbox { get; set; }
        internal TabControl tabs { get; set; }
        internal static Core _core { get; set; }
        internal BotStub runningScript { get; set; }
        internal handler.TaskScheduler runningScriptList { get; set; }

        /// <summary>
        /// Initializes the core.
        /// </summary>
        /// <param name="core">The core instance.</param>
        /// <param name="formControl">Form controls like window, logbox and tabs.</param>
        internal static void Initialize(Core core, Bot bot, FormControl formControl)
        {
            _bot = bot;
            _core = core;
            _core.mainWindow = formControl.mainWindow;
            _core.logbox = formControl.logbox;
            _core.tabs = formControl.tabs;
            Bot.AddConfiguration(core);
        }

        /// <summary>
        /// Execute the action in a safe thread to avoid thread crashes.
        /// </summary>
        /// <param name="a">Executes the action.</param>
        internal static void ExeThreadSafe(Action a)
        {
            if (_core.mainWindow.InvokeRequired)
                _core.mainWindow.Invoke((MethodInvoker)delegate { a(); });
            else
                a();
        }

        /// <summary>
        /// Clears all tab pages.
        /// </summary>
        internal static void ReInit()
        {
            _core.tabs.TabPages.Clear();
        }

        /// <summary>
        /// Sends a log message to the logbox.
        /// </summary>
        /// <param name="msg">The message you want to send.</param>
        /// <param name="color">The color of the message.</param>
        /// <returns></returns>
        internal static string AppendTextToLog(string msg, Color color)
        {
            string result = "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "]" + "\t\t" + msg + '\n';
            ExeThreadSafe(delegate
            {
                _core.logbox.SelectionStart = _core.logbox.TextLength;
                _core.logbox.SelectionLength = 0;
                _core.logbox.SelectionColor = color;
                _core.logbox.AppendText(result);
                _core.logbox.SelectionColor = _core.logbox.ForeColor;
                _core.logbox.SelectionStart = _core.logbox.Text.Length;
                _core.logbox.ScrollToCaret();
            });

            return result;
        }
    }
}
