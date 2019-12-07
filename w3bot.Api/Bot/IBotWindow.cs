using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Wrapper;

namespace w3bot.Bot
{
    /// <summary>
    /// w3bot interface for BotWindow.
    /// </summary>
    public interface IBotWindow
    {
        /// <summary>
        /// Open a new window.
        /// </summary>
        void Open();

        /// <summary>
        /// Vanish the current window.
        /// </summary>
        void Vanish();

        /// <summary>
        /// Destroy the current window.
        /// </summary>
        void Destroy();

        /// <summary>
        /// Marks this window as the current one.
        /// </summary>
        void Activate();
    }
}
