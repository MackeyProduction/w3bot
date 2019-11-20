using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Bot;
using w3bot.Core;
using w3bot.Enumeration;
using w3bot.Interfaces;

namespace w3bot.Wrapper
{
    abstract class AbstractBotProcessor : Panel
    {
        abstract internal void ActivateProcessor(BotWindow botWindow);
        abstract internal void Destroy();
        abstract internal void AllowInput();
        abstract internal void BlockInput();
        abstract internal ChromiumWebBrowser GetBrowser();
        abstract internal Point MousePos { get; set; }
        abstract internal Bitmap Frame { get; }
        abstract internal void GetFocus();
    }
}