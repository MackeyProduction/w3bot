using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.interfaces
{
    /// <summary>
    /// w3bot interface for UUA entity.
    /// </summary>
    interface IUUA
    {
        /// <summary>
        /// The unique identifier for user agent.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The user of the user agent.
        /// </summary>
        IUser User { get; }

        /// <summary>
        /// The user agent.
        /// </summary>
        IUserAgent UserAgent { get; }
    }
}
