using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w3bot.core
{
    internal struct FormControl
    {
        internal Form mainWindow;
        internal RichTextBox logbox;
        internal TabControl tabs;

        internal FormControl(Form mainWindow, RichTextBox logbox, TabControl tabs)
        {
            this.mainWindow = mainWindow;
            this.logbox = logbox;
            this.tabs = tabs;
        }
    }
}
