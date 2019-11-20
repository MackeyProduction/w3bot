using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Listener;

namespace w3bot.Interfaces
{
    interface IWebBrowserEvents
    {
        void SetAddress(AddressChangedEventArgs args);

        void OnDocumentLoad(DocumentLoadEventArgs args);
        void OnDocumentReady(DocumentReadyEventArgs args);
    }
}
