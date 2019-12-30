using w3bot.Listener;
using w3bot.Script;
using w3bot.Wrapper;

namespace w3bot.Event
{
    public class BrowserEvent : IEventListener
    {
        private IBotBrowser _browser;
        private IScript _script;

        public BrowserEvent(IBotBrowser browser, IScript script)
        {
            _browser = browser;
            _script = script;
        }

        public void Apply()
        {
            if (_script is IAddressChangedListener)
            {
                _browser.AddressChanged += ((IAddressChangedListener)_script).AddressChanged;
            }

            if (_script is IDocumentLoadListener)
            {
                _browser.DocumentLoad += ((IDocumentLoadListener)_script).DocumentLoad;
            }

            if (_script is IDocumentReadyListener)
            {
                _browser.DocumentReady += ((IDocumentReadyListener)_script).DocumentReady;
            }
        }

        public void Destroy()
        {
            if (_script is IAddressChangedListener)
            {
                _browser.AddressChanged -= ((IAddressChangedListener)_script).AddressChanged;
            }

            if (_script is IDocumentLoadListener)
            {
                _browser.DocumentLoad -= ((IDocumentLoadListener)_script).DocumentLoad;
            }

            if (_script is IDocumentReadyListener)
            {
                _browser.DocumentReady -= ((IDocumentReadyListener)_script).DocumentReady;
            }
        }
    }
}
