using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Evt;

namespace w3bot.Listener
{
    public class ChromiumBrowserEventArgs : EventArgs
    {
        public delegate void ChromiumBrowserDocumentReady(object sender, FrameLoadEndEventArgs e);
        public static event ChromiumBrowserDocumentReady DocumentReadyEvent = delegate { };
        public delegate void ChromiumBrowserDocumentLoad(object sender, FrameLoadStartEventArgs e);
        public static event ChromiumBrowserDocumentLoad DocumentLoadEvent = delegate { };
        public delegate void ChromiumBrowserAddressChanged(object sender, CefSharp.AddressChangedEventArgs e);
        public static event ChromiumBrowserAddressChanged DocumentAddressChangedEvent = delegate { };

        public FrameLoadEndEventArgs DocumentReadyEventArgs { get; set; }
        public FrameLoadStartEventArgs DocumentLoadEventArgs { get; set; }
        public AddressChangedEventArgs DocumentAddressChangedEventArgs { get; set; }

        internal void ExecuteAddressChangedEvent(object sender, CefSharp.AddressChangedEventArgs e)
        {
            DocumentAddressChangedEvent(sender, e);
        }

        internal void ExecuteDocumentReadyEvent(object sender, FrameLoadEndEventArgs e)
        {
            DocumentReadyEvent(sender, e);
        }

        internal void ExecuteDocumentLoadEvent(object sender, FrameLoadStartEventArgs e)
        {
            DocumentLoadEvent(sender, e);
        }
    }
}
