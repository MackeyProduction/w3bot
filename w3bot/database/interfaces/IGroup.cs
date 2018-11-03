using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.database.interfaces
{
    /// <summary>
    /// w3bot interface for group entity.
    /// </summary>
    interface IGroup
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The group name.
        /// </summary>
        string Name { get; set; }
    }
}
