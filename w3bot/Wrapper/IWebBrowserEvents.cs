using w3bot.Evt.Listener;

namespace w3bot.Wrapper
{
    interface IWebBrowserEvents
    {
        void SetAddress(DocumentAddressChangedEventArgs args);

        void OnDocumentLoad(DocumentLoadEventArgs args);
        void OnDocumentReady(DocumentReadyEventArgs args);
    }
}
