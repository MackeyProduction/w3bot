using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        abstract internal ChromiumWebBrowser GetBrowser();
        abstract internal Point MousePos { get; set; }
        abstract internal Bitmap Frame { get; }
    }
}