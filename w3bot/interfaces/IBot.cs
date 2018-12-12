using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core;

namespace w3bot.Interfaces
{
    /// <summary>
    /// w3bot interface for bot.
    /// </summary>
    public interface IBot
    {
        /// <summary>
        /// Creates a new BotWindow which allows you to send input.
        /// </summary>
        /// <param name="name">Bot window name.</param>
        /// <param name="url">Url of the bot window.</param>
        /// <returns>Returns an BotWindow object.</returns>
        BotWindow CreateBrowserWindow(string name = "View", string url = "");

        /// <summary>
        /// Initializes all necessarily settings for the BotWindow. After initializing you need to use the Open() method to open the window.
        /// </summary>
        /// <param name="botWindow"></param>
        void Initialize(BotWindow botWindow);
    }
}
