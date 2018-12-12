using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Interfaces
{
    /// <summary>
    /// w3bot interface for user agent.
    /// </summary>
    interface IUserAgent
    {
        /// <summary>
        /// The unique identifier of the user agent.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The operating system of user agent.
        /// </summary>
        IOperatingSystem OperatingSystem { get; set; }

        /// <summary>
        /// The software of user agent.
        /// </summary>
        ISoftware Software { get; set; }

        /// <summary>
        /// The User Agent by software and operating system.
        /// </summary>
        string Agent { get; set; }
    }
}
