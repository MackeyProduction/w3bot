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

        /// <summary>
        /// Gets the source code of the current page.
        /// </summary>
        string SourceCode { get; }

        /// <summary>
        /// Gets the url of the current page.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Shows the dev tools.
        /// </summary>
        void ShowDevTools();

        event EventHandler<DocumentReadyEventArgs> DocumentReady;
        event EventHandler<DocumentLoadEventArgs> DocumentLoad;
        event EventHandler<DocumentAddressChangedEventArgs> AddressChanged;
    }
}
