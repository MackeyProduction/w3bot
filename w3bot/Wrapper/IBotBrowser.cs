using System;
using System.Drawing;
using w3bot.Listener;

namespace w3bot.Wrapper
{
    public interface IBotBrowser : IDisposable
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

        /// <summary>
        /// The size of the current browser.
        /// </summary>
        System.Drawing.Size Size { get; set; }

        /// <summary>
        /// Gets the current frame.
        /// </summary>
        Bitmap Frame { get; }

        event EventHandler<DocumentReadyEventArgs> DocumentReady;
        event EventHandler<DocumentLoadEventArgs> DocumentLoad;
        event EventHandler<DocumentAddressChangedEventArgs> AddressChanged;
    }
}
