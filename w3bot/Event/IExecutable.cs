using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Event
{
    /// <summary>
    /// w3bot interface for task scheduler.
    /// </summary>
    interface IExecutable
    {
        /// <summary>
        /// Executes event.
        /// </summary>
        void Execute(int id);

        /// <summary>
        /// Destroys an event.
        /// </summary>
        void Destroy();
    }
}
