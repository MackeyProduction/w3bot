using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Interfaces
{
    /// <summary>
    /// w3bot interface for proxy.
    /// </summary>
    interface IProxy
    {
        /// <summary>
        /// The unique identifier of the proxy.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The name of the proxy.
        /// </summary>
        string ProxyName { get; set; }

        /// <summary>
        /// The ip address of the proxy.
        /// </summary>
        string IP { get; set; }

        /// <summary>
        /// The port of the proxy.
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// The username of the proxy.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The password of the proxy.
        /// </summary>
        string Password { get; set; }
    }
}
