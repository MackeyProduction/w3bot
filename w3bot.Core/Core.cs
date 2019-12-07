using System;
using System.Drawing;
using System.Windows.Forms;

namespace w3bot.Core
{
    public class Core
    {
        public Form mainWindow { get; set; }
        public static Core _core { get; set; }
        public static Form currentWindow { get; set; }
        
        public CoreInformation GetCoreInformation()
        {
            return new CoreInformation();
        }

        /// <summary>
        /// Execute the action in a safe thread to avoid thread crashes.
        /// </summary>
        /// <param name="a">Executes the action.</param>
        public static void ExeThreadSafe(Action a)
        {
            if (_core.mainWindow.InvokeRequired)
                _core.mainWindow.Invoke((MethodInvoker)delegate { a(); });
            else
                a();
        }
    }
}
