using System;
using w3bot.Evt.Listener;

namespace w3bot.Wrapper
{
    interface IBotBrowser : IDisposable
    {
        IBrowser GetBrowser();
        IKeyboardInput GetKeyboard();
        IMouseInput GetMouse();

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
