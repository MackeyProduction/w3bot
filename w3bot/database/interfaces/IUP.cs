using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.interfaces
{
    /// <summary>
    /// w3bot interface for UP entity.
    /// </summary>
    interface IUP
    {
        /// <summary>
        /// The unique identifier of the UP entity.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The proxy.
        /// </summary>
        IProxy Proxy { get; set; }

        /// <summary>
        /// The user.
        /// </summary>
        IUser User { get; set; }
    }
}
