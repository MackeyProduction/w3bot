using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.bot;
using w3bot.evt;
using w3bot.interfaces;
using w3bot.listener;

namespace w3bot.handler
{
    public class BrowserHandler : IEventHandler
    {
        private Bot _bot;
        private IScript _script;
        Bot.ChromiumBrowserDelegate browserEvt;

        public BrowserHandler(Bot bot, IScript script)
        {
            _bot = bot;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IAddressChangedListener)
            {
                //Bot.chromeBrowserEvents.DocumentAddressChangedEvent += ((IAddressChangedListener)_script).AddressChanged;
                Bot.ChromiumBrowserEvent += ((IAddressChangedListener)_script).AddressChanged;
                //_bot.chromeBrowserEvents.DocumentAddressChangedEvent += ((IAddressChangedListener)_script).AddressChanged;
                //_bot.botWindow._chromiumBrowser.AddressChanged += ((IAddressChangedListener)_script).AddressChanged;
            }

            if (_script is IDocumentLoadListener)
            {
                _bot.botWindow._chromiumBrowser.FrameLoadStart += ((IDocumentLoadListener)_script).DocumentLoad;
            }

            if (_script is IDocumentReadyListener)
            {
                Bot.ChromiumBrowserEvent += ((IDocumentReadyListener)_script).DocumentReady;
                //_bot.botWindow._chromiumBrowser.FrameLoadEnd += ((IDocumentReadyListener)_script).DocumentReady;
            }
        }
    }
}
