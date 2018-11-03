using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.interfaces
{
    /// <summary>
    /// w3bot interface for operating system of user agent.
    /// </summary>
    interface IOperatingSystem
    {
        /// <summary>
        /// The name of the operating system.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The version of the operating system.
        /// </summary>
        string Version { get; set; }
    }
}
