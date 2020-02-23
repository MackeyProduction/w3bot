using System;
using w3bot.Listener;
using w3bot.Script;
using w3bot.Wrapper;

namespace w3bot.Event
{
    public class BrowserEvent
    {
        private IBotBrowser _browser;
        private IScript _script;

        public event EventHandler<DocumentAddressChangedEventArgs> AddressChanged;
        public event EventHandler<DocumentLoadEventArgs> DocumentLoad;
        public event EventHandler<DocumentReadyEventArgs> DocumentReady;

        public BrowserEvent(IBotBrowser browser)
        {
            _browser = browser;
        }

        protected virtual void OnAddressChanged(IBotBrowser browser)
        {
            AddressChanged?.Invoke(this, new DocumentAddressChangedEventArgs(browser.GetBrowser(), ""));
        }

        protected virtual void OnDocumentLoad(IBotBrowser browser)
        {
            DocumentLoad?.Invoke(this, new DocumentLoadEventArgs(browser.GetBrowser(), ""));
        }

        protected virtual void OnDocumentReady(IBotBrowser browser)
        {
            DocumentReady?.Invoke(this, new DocumentReadyEventArgs(browser.GetBrowser(), 200, ""));
        }
    }
}
