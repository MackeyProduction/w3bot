using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.enumeration;
using w3bot.interfaces;

namespace w3bot.wrapper
{
    abstract class AbstractBotProcessor : Panel
    {
        abstract internal void ActivateProcessor();
        abstract internal void Destroy();
        abstract internal void AllowInput();
        abstract internal void BlockInput();
    }
}
