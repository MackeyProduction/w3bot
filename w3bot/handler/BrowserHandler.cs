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

        public BrowserHandler(Bot bot, IScript script)
        {
            _bot = bot;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IAddressChangedListener)
            {
                Bot.DocumentAddressChangedEvent += ((IAddressChangedListener)_script).AddressChanged;
            }

            if (_script is IDocumentLoadListener)
            {
                Bot.DocumentLoadEvent += ((IDocumentLoadListener)_script).DocumentLoad;
            }

            if (_script is IDocumentReadyListener)
            {
                Bot.DocumentReadyEvent += ((IDocumentReadyListener)_script).DocumentReady;
            }
        }
    }
}
