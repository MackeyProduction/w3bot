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
        internal delegate void Drawable(Graphics g);
        public static event Drawable paintings = delegate { };
        internal static Form mainWindow { get; set; }
        internal static CoreInformation coreInformation { get { return new CoreInformation(); } }
        internal static Bot bot { get { return new Bot(); } set { } }
        internal static RichTextBox logbox { get; set; }
        internal static TabControl tabs { get; set; }

        /// <summary>
        /// Execute the action in a safe thread to avoid thread crashes.
        /// </summary>
        /// <param name="a">Executes the action.</param>
        internal static void ExeThreadSafe(Action a)
        {
            Thread thread;
            if (mainWindow.InvokeRequired)
            {
                thread = new Thread(new ThreadStart(delegate
                {
                    mainWindow.Invoke((MethodInvoker)delegate { a(); });
                }));
                thread.Start();
            }
            else
                a();
        }

        /// <summary>
        /// Refreshs the paint of the current bot window.
        /// </summary>
        /// <param name="g"></param>
        internal static void RefreshPaints(Graphics g)
        {
            paintings(g);
        }

        /// <summary>
        /// Clears all tab pages.
        /// </summary>
        internal static void ReInit()
        {
            tabs.TabPages.Clear();
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
                logbox.SelectionStart = logbox.TextLength;
                logbox.SelectionLength = 0;
                logbox.SelectionColor = color;
                logbox.AppendText(result);
                logbox.SelectionColor = logbox.ForeColor;
                logbox.SelectionStart = logbox.Text.Length;
                logbox.ScrollToCaret();
            });

            return result;
        }
    }
}
