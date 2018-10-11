using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public BrowserHandler(Bot bot, IScript script)
        {
            _bot = bot;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IAddressChangedListener)
            {
                _bot.botWindow._chromiumBrowser.AddressChanged += ((IAddressChangedListener)_script).AddressChanged;
            }

            if (_script is IDocumentLoadListener)
            {
                _bot.botWindow._chromiumBrowser.FrameLoadStart += ((IDocumentLoadListener)_script).DocumentLoad;
            }

            if (_script is IDocumentReadyListener)
            {
                _bot.botWindow._chromiumBrowser.FrameLoadEnd += ((IDocumentReadyListener)_script).DocumentReady;
            }
        }
    }
}
