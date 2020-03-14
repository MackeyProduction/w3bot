using System;
using w3bot.Listener;
using w3bot.Script;
using w3bot.Wrapper;

namespace w3bot.Event
{
    public class BrowserEvent
    {
        public EventHandler<DocumentAddressChangedEventArgs> AddressChanged { get; set; }
        public EventHandler<DocumentLoadEventArgs> DocumentLoad { get; set; }
        public EventHandler<DocumentReadyEventArgs> DocumentReady { get; set; }

        public BrowserEvent()
        {
        }

        protected virtual void OnAddressChanged(object sender, DocumentAddressChangedEventArgs e)
        {
            AddressChanged?.Invoke(sender, e);
        }

        protected virtual void OnDocumentLoad(object sender, DocumentLoadEventArgs e)
        {
            DocumentLoad?.Invoke(sender, e);
        }

        protected virtual void OnDocumentReady(object sender, DocumentReadyEventArgs e)
        {
            DocumentReady?.Invoke(sender, e);
        }
    }
}
