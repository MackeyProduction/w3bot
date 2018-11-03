using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.interfaces
{
    /// <summary>
    /// w3bot interface for software from user agent.
    /// </summary>
    interface ISoftware
    {
        /// <summary>
        /// The unique identifier of the software.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The name of the used software from user agent.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The version of the used software from user agent.
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// The used layout engine name from user agent.
        /// </summary>
        string LEName { get; set; }

        /// <summary>
        /// The used layout engine version from user agent.
        /// </summary>
        string LEVersion { get; set; }

        /// <summary>
        /// The software extras from user agent.
        /// </summary>
        ISoftwareExtras Extas { get; set; }
    }
}
