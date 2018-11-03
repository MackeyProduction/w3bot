using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.interfaces
{
    /// <summary>
    /// w3bot interface for user agent.
    /// </summary>
    interface IUserAgent
    {
        /// <summary>
        /// The operating system of user agent.
        /// </summary>
        IOperatingSystem OperatingSystem { get; set; }

        /// <summary>
        /// The software of user agent.
        /// </summary>
        ISoftware Software { get; set; }
    }
}
