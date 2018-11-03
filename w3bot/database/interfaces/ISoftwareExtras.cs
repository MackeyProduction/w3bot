using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.interfaces
{
    /// <summary>
    /// w3bot interface for software extras entity.
    /// </summary>
    interface ISoftwareExtras
    {
        /// <summary>
        /// The unique identifier for software extras.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The software extras info.
        /// </summary>
        string Info { get; set; }
    }
}
