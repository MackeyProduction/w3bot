using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Interfaces;
using w3bot.Listener;

namespace w3bot.Wrapper
{
    interface IBotBrowser : IDisposable
    {
        IBrowser GetBrowser();

        /// <summary>
        /// Open new proxy connection.
        /// </summary>
        string Proxy { get; set; }

        /// <summary>
        /// Show user agent.
        /// </summary>
        string UserAgent { get; }

        event EventHandler<DocumentReadyEventArgs> DocumentReady;
        event EventHandler<DocumentLoadEventArgs> DocumentLoad;
        event EventHandler<DocumentAddressChangedEventArgs> AddressChanged;
    }
}
