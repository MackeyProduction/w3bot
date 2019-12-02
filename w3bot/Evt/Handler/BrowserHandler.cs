using w3bot.Bot;
using w3bot.Evt.Listener;

namespace w3bot.Evt.Handler
{
    public class BrowserHandler : IEventHandler
    {
        private Bot.Bot _bot;
        private IScript _script;

        public BrowserHandler(Bot.Bot bot, IScript script)
        {
            _bot = bot;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IAddressChangedListener)
            {
                Bot.Bot.DocumentAddressChangedEvent += ((IAddressChangedListener)_script).AddressChanged;
            }

            if (_script is IDocumentLoadListener)
            {
                Bot.Bot.DocumentLoadEvent += ((IDocumentLoadListener)_script).DocumentLoad;
            }

            if (_script is IDocumentReadyListener)
            {
                Bot.Bot.DocumentReadyEvent += ((IDocumentReadyListener)_script).DocumentReady;
            }
        }

        public void Destroy()
        {
            if (_script is IAddressChangedListener)
            {
                Bot.Bot.DocumentAddressChangedEvent -= ((IAddressChangedListener)_script).AddressChanged;
            }

            if (_script is IDocumentLoadListener)
            {
                Bot.Bot.DocumentLoadEvent -= ((IDocumentLoadListener)_script).DocumentLoad;
            }

            if (_script is IDocumentReadyListener)
            {
                Bot.Bot.DocumentReadyEvent -= ((IDocumentReadyListener)_script).DocumentReady;
            }
        }
    }
}
