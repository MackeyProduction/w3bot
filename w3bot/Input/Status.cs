using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Core;

namespace w3bot.Input
{
    public static class Status
    {
        private static Form _form;

        public static string Log(string text)
        {
            return AppendTextToLog(text, Color.Black);
        }

        public static string Log(Object obj)
        {
            return AppendTextToLog(obj == null ? "null" : obj.ToString(), Color.Black);
        }

        public static string Warning(string text)
        {
            return AppendTextToLog(text, Color.Red);
        }

        public static string Warning(Object obj)
        {
            return AppendTextToLog(obj == null ? "null" : obj.ToString(), Color.Red);
        }

        public static string HandleException(Action codeToHandle)
        {
            string result = null;
            try
            {
                codeToHandle();
            }
            catch (Exception e)
            {
                result = Warning(e);
            }
            return result;
        }

        internal static void AddConfiguration(Form form)
        {
            _form = form;
        }

        /// <summary>
        /// Sends a log message to the logbox.
        /// </summary>
        /// <param name="msg">The message you want to send.</param>
        /// <param name="color">The color of the message.</param>
        /// <returns></returns>
        internal static string AppendTextToLog(string msg, Color color)
        {
            var logbox = (RichTextBox)_form.Controls.Find("", true)[0];
            string result = "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "]" + "\t\t" + msg + '\n';
            Bot.Bot.ExeThreadSafe(delegate
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
