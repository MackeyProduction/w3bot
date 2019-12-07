using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Wrapper
{
    /// <summary>
    /// w3bot interface for Browser.
    /// </summary>
    public interface IBrowser : IDisposable
    {
        /// <summary>
        /// Open source code from current web page.
        /// </summary>
        string SouceCode { get; }

        /// <summary>
        /// Returns true if the website is finished loading. 
        /// </summary>
        bool IsReady { get; }

        /// <summary>
        /// Navigate backwards.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Navigate forward.
        /// </summary>
        void GoForward();

        /// <summary>
        /// Navigate to website.
        /// </summary>
        /// <param name="url">Url to navigate.</param>
        void Navigate(string url);

        /// <summary>
        /// Refresh website.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Executes Javascript.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        Task<object> ExecuteJavascript(string script);
    }
}
