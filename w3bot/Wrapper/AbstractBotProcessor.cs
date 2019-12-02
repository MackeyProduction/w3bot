using CefSharp.OffScreen;
using System.Drawing;
using System.Windows.Forms;
using w3bot.Core.Bot;

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