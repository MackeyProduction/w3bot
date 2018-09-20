using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using w3bot.wrapper;

namespace w3bot.core
{
    internal class Core : Form
    {
        internal delegate void Drawable(Graphics g);
        public static event Drawable paintings = delegate { };
        internal static Form mainWindow { get; set; }
        internal static CoreInformation coreInformation { get; }
        internal static Bot bot { get { return new Bot(); } set { } }
        internal static RichTextBox logbox { get; set; }
        internal static TabControl tabs { get; set; }
        internal static BackgroundWorker backgroundWorker;

        internal static void ExeThreadSafe(Action a)
        {
            if (mainWindow.InvokeRequired)
                mainWindow.Invoke((MethodInvoker)delegate { a(); });
            else
                a();
        }

        internal static void RefreshPaints(Graphics g)
        {
            paintings(g);
        }

        internal static void ReInit()
        {
            tabs.TabPages.Clear();
        }

        internal static string AppendTextToLog(string msg, Color color)
        {
            string result = "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "]" + "\t\t" + msg + '\n';
            backgroundWorker.DoWork += (delegate
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
