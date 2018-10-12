using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.evt;

namespace w3bot.listener
{
    public class ChromiumBrowserEventArgs : EventArgs
    {
        public delegate void ChromiumBrowserDocumentReady(object sender, FrameLoadEndEventArgs e);
        public event ChromiumBrowserDocumentReady DocumentReadyEvent = delegate { };
        public delegate void ChromiumBrowserDocumentLoad(object sender, FrameLoadStartEventArgs e);
        public event ChromiumBrowserDocumentLoad DocumentLoadEvent = delegate { };
        public delegate void ChromiumBrowserAddressChanged(object sender, ChromiumBrowserEventArgs e);
        public event ChromiumBrowserAddressChanged DocumentAddressChangedEvent = delegate { };

        public FrameLoadEndEventArgs DocumentReadyEventArgs { get; set; }
        public FrameLoadStartEventArgs DocumentLoadEventArgs { get; set; }
        public AddressChangedEventArgs DocumentAddressChangedEventArgs { get; set; }

        internal void AddAddressChangedEvent(IAddressChangedListener addressChanged)
        {
            DocumentAddressChangedEvent += addressChanged.AddressChanged;
        }

        internal void ExecuteAddressChangedEvent(object sender, ChromiumBrowserEventArgs e)
        {
            DocumentAddressChangedEvent(sender, e);
        }

        internal void ExecuteDocumentReadyEvent(object sender, FrameLoadEndEventArgs e)
        {
            DocumentReadyEvent(sender, e);
        }
    }
}
